namespace CSModule.Email.EmailSender.Tests.IntegrationTests.MailKitSmtp;

public class SendEmailAsyncTests : TestBase
{
    [TestCaseSource(nameof(GetSendEmailOptions))]
    public async Task SendsEmail(string smtpHost, int smtpPort, bool useSsl, ICredentials credentials, string from, string to)
    {
        // Arrange.
        var sut = new MailKitSmtpEmailSender(smtpHost, smtpPort, useSsl, credentials);
        var subject = fx.Create<string>();
        var body = fx.Create<string>();

        // Act.
        var email = Email.Create().AddFrom(from).AddTo(to).SetSubject(subject).SetBody(body).Build();
        var result = await sut.SendEmailAsync(email, CancellationToken.None);

        // Assert.
        result.Should().BeTrue();
    }

    private static object[] GetSendEmailOptions()
    {
        var servers = env.ReadJsonFromEnvironmentVariable<List<TestEmailServer>>(TestEmailServer.EnvironmentVariableCollectionName);
        var addresses = env.ReadJsonFromEnvironmentVariable<List<TestEmailAddress>>(TestEmailAddress.EnvironmentVariableCollectionName);

        var serversWithAtLeastTwoEmails = servers.Where(s => addresses.Count(a => a.Server == s.Name) >= 2).ToList();
        return serversWithAtLeastTwoEmails
            .Select(s =>
            {
                var from = addresses.Where(a => a.Server == s.Name).First();
                var to = addresses.Where(a => a.Server == s.Name).Skip(1).First();
                return new object[]
                {
                    s.SmtpHost,
                    s.SmtpPort,
                    s.SmtpUseSsl,
                    new NetworkCredential(from.Username, from.AppPassword),
                    from.Email,
                    to.Email,
                };
            })
            .ToArray();
    }
}
