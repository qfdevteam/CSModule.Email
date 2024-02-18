using System.Net;
using MailKit.Net.Smtp;
using MimeKit;

namespace CSModule.Email.EmailSender.MailKit;

public class MailKitSmtpEmailSender(string host, int port, bool useSsl, ICredentials credentials) : IEmailSender
{
    private readonly string _smtpServerHost = host;
    private readonly int _smtpServerPort = port;
    private readonly bool _useSsl = useSsl;
    private readonly ICredentials _credentials = credentials;
    private readonly SemaphoreSlim _connectSemaphore = new(1, 1);

    private bool _disposed = false;
    private SmtpClient? _smtpClient = null;

    /// <inheritdoc/>
    public async Task<bool> SendEmailAsync(IEmail email, CancellationToken cancellationToken)
    {
        ObjectDisposedException.ThrowIf(_disposed, this);

        try
        {
            var client = await GetInitializedSmtpClientAsync(cancellationToken);
            var message = CreateMimeMessage(email);
            await client.SendAsync(message, cancellationToken);

            return true;
        }
        catch (OperationCanceledException)
        {
            return false;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Unable to complete sending of an email.", ex);
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            _smtpClient?.Dispose();
        }

        _smtpClient = null;

        _disposed = true;
    }

    private static MimeMessage CreateMimeMessage(IEmail email)
    {
        var message = new MimeMessage();
        message.From.Add(CreateMailboxAddress(email.From));
        message.To.Add(CreateMailboxAddress(email.To));
        message.Subject = email.Subject;
        message.Body = new TextPart("html")
        {
            Text = email.Body
        };

        return message;
    }

    private static MailboxAddress CreateMailboxAddress(IEmailAddress emailAddress)
    {
        var address = new MailboxAddress(
            name: emailAddress.Name ?? emailAddress.Address,
            address: emailAddress.Address);

        return address;
    }

    private async Task<SmtpClient> GetInitializedSmtpClientAsync(CancellationToken cancellationToken)
    {
        bool hasEnteredConnectSemaphore = false;
        try
        {
            await _connectSemaphore.WaitAsync(cancellationToken);
            hasEnteredConnectSemaphore = true;

            _smtpClient ??= new SmtpClient();
            if (!_smtpClient.IsConnected)
            {
                await _smtpClient.ConnectAsync(_smtpServerHost, _smtpServerPort, _useSsl, cancellationToken);
            }
            if (!_smtpClient.IsAuthenticated)
            {
                await _smtpClient.AuthenticateAsync(_credentials, cancellationToken);
            }
        }
        finally
        {
            if (hasEnteredConnectSemaphore)
            {
                _connectSemaphore.Release();
            }
        }

        return _smtpClient;
    }
}
