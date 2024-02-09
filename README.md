# CSModule.Email
[![Build and Test](https://github.com/qfdevteam/CSModule.Email/actions/workflows/build_and_test.yml/badge.svg)](https://github.com/qfdevteam/CSModule.Email/actions/workflows/build_and_test.yml)

Implements common abstractions and composing tools for Email communications.

## Common Abstractions

`CSModule.Email.IEmailAddress` - represents an email owner.

`CSModule.Email.IEmail` - represents a composed email instance that can be inspected or sent.

## Common Implementations

`CSModule.Email.EmailBuilder` - an email builder that should be used to create an instance of `CSModule.Email.IEmail`.

`CSModule.Email.EmailAddress` - an email owner instance.

`CSModule.Email.Email` - a composed email instance that implements `CSModule.Email.IEmail`. Static method `Create()` should be used to create `CSModule.Email.EmailBuilder` instance.

## Email Sender Abstractions

`CSModule.Email.EmailSender.IEmailSender` - represents instance that responsive to send email messages.

## Email Sender Implementations

`CSModule.Email.EmailSender.MailKitSmtpEmailSender` - an [MailKit](https://github.com/jstedfast/MailKit)-based SMTP email sender that implements `CSModule.Email.EmailSender.IEmailSender`.

## MailKit SMTP Email Sender usage example
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
