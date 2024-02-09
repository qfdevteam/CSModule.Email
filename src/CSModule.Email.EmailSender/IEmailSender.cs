namespace CSModule.Email.EmailSender;

/// <summary>
/// An email sender.
/// </summary>
public interface IEmailSender : IDisposable
{
    /// <summary>
    /// Sends provided email to recipients.
    /// </summary>
    /// <param name="email">The email information.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    /// True if operation completed successfully;
    /// False if operation was cancelled before completion.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// When unable to complete sending of an email.
    /// </exception>
    Task<bool> SendEmailAsync(IEmail email, CancellationToken cancellationToken);
}
