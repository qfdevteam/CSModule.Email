namespace CSModule.Email;

/// <summary>
/// An email.
/// </summary>
public interface IEmail
{
    /// <summary>
    /// The email sender address.
    /// </summary>
    public IEmailAddress From { get; }

    /// <summary>
    /// The email recipient address.
    /// </summary>
    public IEmailAddress To { get; }

    /// <summary>
    /// The email subject.
    /// </summary>
    public string Subject { get; }

    /// <summary>
    /// The email body.
    /// </summary>
    /// <remarks>
    /// Can be represented either as HTML or plain text.
    /// </remarks>
    public string Body { get; }
}
