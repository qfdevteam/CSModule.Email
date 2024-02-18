# GitHub secrets configuration example

## TEST_EMAIL_SERVERS

```json
[
  {
    "name": "gmail.com",
    "smtpHost": "smtp.gmail.com",
    "smtpPort": 465,
    "smtpUseSsl": true
  }
]
```

## TEST_EMAIL_ADDRESSES

```json
[
  {
    "server": "gmail.com",
    "email": "...@gmail.com",
    "username": "...",
    "password": "...",
    "appPassword": "..."
  },
  {
    "server": "gmail.com",
    "email": "...@gmail.com",
    "username": "...",
    "password": "...",
    "appPassword": "..."
  }
]
```
