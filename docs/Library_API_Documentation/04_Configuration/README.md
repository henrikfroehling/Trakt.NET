## Configuration

```csharp
using TraktNet;

var client = new TraktClient("ClientID", "OptionalClientSecret");
```

The library allows you to use the sandbox environment of the Trakt API, which is disabled by default.

You can enable the usage of the sandbox environment with the following setting:

```csharp
client.Configuration.UseSandboxEnvironment = true;
```

Some API requests support optional OAuth authorization. The library calls these requests without OAuth authorization.

But you can enforce the library to call these requests with OAuth authorization with the following setting:

```csharp
client.Configuration.ForceAuthorization = true;
```

By default, the library throws exceptions when a request fails. See [Exception Handling section](https://github.com/henrikfroehling/Trakt.NET/wiki/07-Exception-Handling) for more information.

You can toggle this behaviour with the following setting:

```csharp
client.Configuration.ThrowResponseExceptions = true;
```
