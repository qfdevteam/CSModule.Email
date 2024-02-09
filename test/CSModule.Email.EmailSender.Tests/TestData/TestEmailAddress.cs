namespace CSModule.Email.EmailSender.Tests.TestData;

public class TestEmailAddress
{
    public const string EnvironmentVariableCollectionName = "TEST_EMAIL_ADDRESSES";

    public required string Server { get; init; }
    public required string Email { get; init; }
    public required string Username { get; init; }
    public required string Password { get; init; }
    public required string AppPassword { get; init; }
}
