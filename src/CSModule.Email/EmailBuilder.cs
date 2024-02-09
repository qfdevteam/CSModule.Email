namespace CSModule.Email.EmailSender;

/// <summary>
/// An email instance builder.
/// </summary>
public sealed class EmailBuilder
{
    private EmailAddress? _from;
    private EmailAddress? _to;
    private string? _subject;
    private string? _body;

    internal EmailBuilder()
    {
    }

    /// <summary>
    /// Adds from email address to email.
    /// </summary>
    /// <param name="address">The email address.</param>
    /// <returns>This builder instance.</returns>
    public EmailBuilder AddFrom(string address)
    {
        _from = new EmailAddress(null, address);
        return this;
    }

    /// <summary>
    /// Adds from email address to email.
    /// </summary>
    /// <param name="name">The email owner name.</param>
    /// <param name="address">The email address.</param>
    /// <returns>This builder instance.</returns>
    public EmailBuilder AddFrom(string name, string address)
    {
        _from = new EmailAddress(name, address);
        return this;
    }

    /// <summary>
    /// Adds to email address to email.
    /// </summary>
    /// <param name="address">The email address.</param>
    /// <returns>This builder instance.</returns>
    public EmailBuilder AddTo(string address)
    {
        _to = new EmailAddress(null, address);
        return this;
    }

    /// <summary>
    /// Adds to email address to email.
    /// </summary>
    /// <param name="name">The email owner name.</param>
    /// <param name="address">The email address.</param>
    /// <returns>This builder instance.</returns>
    public EmailBuilder AddTo(string name, string address)
    {
        _to = new EmailAddress(name, address);
        return this;
    }

    /// <summary>
    /// Sets email subject.
    /// </summary>
    /// <param name="subject">The email subject.</param>
    /// <returns>This builder instance.</returns>
    public EmailBuilder SetSubject(string subject)
    {
        _subject = subject;
        return this;
    }

    /// <summary>
    /// Sets email body.
    /// </summary>
    /// <param name="subject">The email body.</param>
    /// <returns>This builder instance.</returns>
    public EmailBuilder SetBody(string body)
    {
        _body = body;
        return this;
    }

    /// <summary>
    /// Creates email instance with configured properties.
    /// </summary>
    /// <returns>An email instance.</returns>
    /// <exception cref="InvalidOperationException">
    /// When not all required email properties configured/
    /// </exception>
    public IEmail Build()
    {
        if (_from == null)
        {
            throw new InvalidOperationException($"Unable to build email: '{nameof(IEmail.From)}' is not set.");
        }
        if (_to == null)
        {
            throw new InvalidOperationException($"Unable to build email: '{nameof(IEmail.To)}' is not set.");
        }
        if (_subject == null)
        {
            throw new InvalidOperationException($"Unable to build email: '{nameof(IEmail.Subject)}' is not set.");
        }
        if (_body == null)
        {
            throw new InvalidOperationException($"Unable to build email: '{nameof(IEmail.Body)}' is not set.");
        }

        return new Email(_from, _to, _subject, _body);
    }
}
