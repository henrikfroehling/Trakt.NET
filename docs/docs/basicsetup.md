# Basic Setup

The main entry point to the library is a [`TraktClient`](xref:TraktNet.TraktClient) instance. There are three different ways to create a new instance of it and which way to choose depends on how you want to use the library.

```csharp
using TraktNet;
```

### Cliend-ID

If you just want to use requests, which do not require the OAuth authorization of [Trakt.tv](https://trakt.tv/), you will only have to provide the client id of your [Trakt application](https://trakt.tv/oauth/applications):

```csharp
var client = new TraktClient("Your Trakt Client Id");

// or

var client = new TraktClient
{
    ClientId = "Your Trakt Client Id"
};
```

The following snippet shows the status flags, when the client's Client-Secret is not set.

```csharp
Console.WriteLine($"Requests without Authorization possible: {client.IsValidForUseWithoutAuthorization}");
Console.WriteLine($"Authentication possible: {client.IsValidForAuthenticationProcess}");
Console.WriteLine($"Requests with Authorization possible: {client.IsValidForUseWithAuthorization}");
```

Output:
```
Requests without Authorization possible: true
Authentication possible: false
Requests with Authorization possible: false
```

### Client-ID and Client-Secret

If you also want to [authenticate](auth.md) your application users, the client secret of your [Trakt application](https://trakt.tv/oauth/applications) will also be needed additionally:

```csharp
var client = new TraktClient("Your Trakt Client Id", "Your Trakt Client Secret");

// or

var client = new TraktClient
{
    ClientId = "Your Trakt Client Id",
    ClientSecret = "Your Trakt Client Secret"
};
```

The following snippet shows the status flags, when the client's Client-Secret is not set.

```csharp
Console.WriteLine($"Requests without Authorization possible: {client.IsValidForUseWithoutAuthorization}");
Console.WriteLine($"Authentication possible: {client.IsValidForAuthenticationProcess}");
Console.WriteLine($"Requests with Authorization possible: {client.IsValidForUseWithAuthorization}");
```

Output:
```
Requests without Authorization possible: true
Authentication possible: true
Requests with Authorization possible: false
```

### Client-ID, Client-Secret and Authorization

If you want to use requests, which do require OAuth authorization, you will also have to provide an OAuth access token. Read the [Authentication section](auth.md) on how to get a new [Trakt.tv](https://trakt.tv/) OAuth authorization, including access token and the refresh token, or provide an existing access token:

```csharp
var client = new TraktClient("Your Trakt Client Id", "Your Trakt Client Secret")
{
    Authorization = TraktAuthorization.CreateWith("An existing access token")
};

// or

var client = new TraktClient
{
    ClientId = "Your Trakt Client Id",
    ClientSecret = "Your Trakt Client Secret",
    Authorization = TraktAuthorization.CreateWith("An existing access token")
};
```

The following snippet shows the status flags, when the client's Client-Secret is not set.

```csharp
Console.WriteLine($"Requests without Authorization possible: {client.IsValidForUseWithoutAuthorization}");
Console.WriteLine($"Authentication possible: {client.IsValidForAuthenticationProcess}");
Console.WriteLine($"Requests with Authorization possible: {client.IsValidForUseWithAuthorization}");
```

Output:
```
Requests without Authorization possible: true
Authentication possible: true
Requests with Authorization possible: true
```

---
> [!NOTE]
> A client id for your [Trakt application](https://trakt.tv/oauth/applications) will always be needed.
