namespace CSModule.Email.EmailSender;

/// <summary>
/// An email address.
/// </summary>
public interface IEmailAddress
{
    /// <summary>
    /// Optional email owner name.
    /// </summary>
    public string? Name { get; }

    /// <summary>
    /// Email address.
    /// </summary>
    public string Address { get; }
}
