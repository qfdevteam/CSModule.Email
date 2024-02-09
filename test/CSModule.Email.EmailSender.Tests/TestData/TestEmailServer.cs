namespace CSModule.Email.EmailSender.Tests.TestData;

public class TestEmailServer
{
    public const string EnvironmentVariableCollectionName = "TEST_EMAIL_SERVERS";

    public required string Name { get; init; }
    public required string SmtpHost { get; init; }
    public required int SmtpPort { get; init; }
    public required bool SmtpUseSsl { get; init; }
}
