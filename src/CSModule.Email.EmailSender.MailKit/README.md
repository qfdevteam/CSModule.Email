# CSModule.EMail.EmailSender.MailKit

![NuGet Version](https://img.shields.io/nuget/v/CSModule.Email.EmailSender.MailKit)

## NuGet package

```
dotnet install CSModule.Email.EmailSender.MailKit
```

## API

`CSModule.Email.EmailSender.MailKitSmtpEmailSender` - an [MailKit](https://github.com/jstedfast/MailKit)-based SMTP email sender that implements `CSModule.Email.EmailSender.IEmailSender`.

## Usage example

```c#
ICredentials credentials = new NetworkCredential("username", "password");
IEmailSender sender = new MailKitSmtpEmailSender("smtp.mail.service.com", 465, true, credentials);
IEmail email = Email.Create()
    .AddFrom("from@mail.service.com")
    .AddTo("to@mail.service.com")
    .SetSubject("Advertising")
    .SetBody("You have an special offer...")
    .Build();

await sender.SendEmailAsync(email, CancellationToken.None);
```
