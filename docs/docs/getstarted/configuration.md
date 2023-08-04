# Configuration

The **Trakt.NET** library has some default behaviour, which you can configure to your needs.

```csharp
using TraktNet;

var client = new TraktClient("ClientID", "ClientSecret");
```

## Sandbox Environment

The library allows you to use the [sandbox environment](https://trakt.docs.apiary.io/#introduction/api-url) of the Trakt API, which is disabled by default.

You can enable the usage of the sandbox environment with the following setting:

```csharp
client.Configuration.UseSandboxEnvironment = true;
```

## Forced Authorization

Some API requests support optional OAuth authorization.
In most cases, this means that you can get more information if you provide an OAuth authorization.

By default, the library calls these requests without OAuth authorization.

But you can enforce the library to call these requests with OAuth authorization by enabling the following setting:

```csharp
client.Configuration.ForceAuthorization = true;
```

## Response Exceptions

By default, the library throws exceptions when a request fails.

See [Exception Handling section](../essentials/exceptionhandling.md) for more information.

You can toggle this behaviour with the following setting:

```csharp
client.Configuration.ThrowResponseExceptions = true;
```

## API Version

The following property determines the used Trakt API version.

The default value is currently 2.

```csharp
Console.WriteLine($"API Version: {client.Configuration.ApiVersion}");
```
