namespace CSModule.Email.EmailSender;

/// <summary>
/// An email address.
/// </summary>
public class EmailAddress : IEmailAddress
{
    /// <inheritdoc/>
    public string? Name { get; set; }

    /// <inheritdoc/>
    public string Address { get; set; }

    /// <summary>
    /// Creates an instance with initialized properties.
    /// </summary>
    /// <param name="address">The email address.</param>
    public EmailAddress(string address) : this(null, address)
    {
    }

    /// <summary>
    /// Creates an instance with initialized properties.
    /// </summary>
    /// <param name="name">The optional email owner name.</param>
    /// <param name="address">The email address.</param>
    public EmailAddress(string? name, string address)
    {
        Name = name;
        Address = address;
    }
}
