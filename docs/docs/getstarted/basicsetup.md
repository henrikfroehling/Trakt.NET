# Basic Setup

The main entry point to the library is a [`TraktClient`](xref:TraktNet.TraktClient) instance.

There are three different ways to create a new instance of it and which way to choose depends on how you want to use the library.

## Key Points
- Client-ID is always necessary
- Client-Secret is optional, but necessary for [authentication](../essentials/auth.md)
- Authentication is the way to get an OAuth authorization
- Authorization is mostly necessary for user- and sync-related requests

> [!NOTE]
> All library methods have documented, if OAuth authorization is necessary or optional.

## Client-ID

If you just want to use requests, which do not require the OAuth authorization of [Trakt.tv](https://trakt.tv/), you will only have to provide the Client-ID of your [Trakt application](https://trakt.tv/oauth/applications):

```csharp
using TraktNet;

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

## Client-ID and Client-Secret

If you also want to [authenticate](../essentials/auth.md) your application users, the Client-Secret of your [Trakt application](https://trakt.tv/oauth/applications) will also be needed additionally:

```csharp
using TraktNet;

var client = new TraktClient("Your Trakt Client Id", "Your Trakt Client Secret");

// or

var client = new TraktClient
{
    ClientId = "Your Trakt Client Id",
    ClientSecret = "Your Trakt Client Secret"
};
```

The following snippet shows the status flags, when the client's Client-ID and Client-Secret are both set.

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

## Client-ID, Client-Secret and Authorization

If you want to use requests, which do require OAuth authorization, you will also have to provide an OAuth access token.

Read the [Authentication section](../essentials/auth.md) on how to get a new [Trakt.tv](https://trakt.tv/) OAuth authorization, including access token and refresh token, or provide an existing access token:

```csharp
using TraktNet;

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

The following snippet shows the status flags, when the client's Client-ID, Client-Secret and an authorization token are set.

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

> [!NOTE]
> A Client-ID for your [Trakt application](https://trakt.tv/oauth/applications) will always be needed.
