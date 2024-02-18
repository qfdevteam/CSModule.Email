# CSModule.Email

[![Build and Test](https://github.com/qfdevteam/CSModule.Email/actions/workflows/build_and_test.yml/badge.svg)](https://github.com/qfdevteam/CSModule.Email/actions/workflows/build_and_test.yml)
![NuGet Version](https://img.shields.io/nuget/v/CSModule.Email)

Implements common abstractions and composing tools for Email communications.

## NuGet package

```
dotnet add package CSModule.Email
```

## Common Abstractions

`CSModule.Email.IEmailAddress` - represents an email owner.

`CSModule.Email.IEmail` - represents a composed email instance that can be inspected or sent.

`CSModule.Email.EmailSender.IEmailSender` - represents instance that responsive to send email messages.

## Common Implementations

`CSModule.Email.EmailAddress` - an email owner instance.

`CSModule.Email.Email` - a composed email instance that implements `CSModule.Email.IEmail`. Static method `Create()` should be used to create `CSModule.Email.EmailBuilder` instance.

`CSModule.Email.EmailBuilder` - an email builder that should be used to create an instance of `CSModule.Email.IEmail`.

## Email Sender Implementations

[MailKit Email Sender](./src/CSModule.Email.EmailSender.MailKit/README.md)
