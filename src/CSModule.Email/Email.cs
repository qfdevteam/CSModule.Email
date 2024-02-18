namespace CSModule.Email;

/// <summary>
/// An email.
/// </summary>
public sealed class Email : IEmail
{
    /// <summary>
    /// Creates an email builder.
    /// </summary>
    /// <returns>The email builder instance.</returns>
    public static EmailBuilder Create()
    {
        return new EmailBuilder();
    }

    /// <inheritdoc/>
    public IEmailAddress From { get; init; }

    /// <inheritdoc/>
    public IEmailAddress To { get; init; }

    /// <inheritdoc/>
    public string Subject { get; init; }

    /// <inheritdoc/>
    public string Body { get; init; }

    internal Email(IEmailAddress from, IEmailAddress to, string subject, string body)
    {
        From = from;
        To = to;
        Subject = subject;
        Body = body;
    }
}
