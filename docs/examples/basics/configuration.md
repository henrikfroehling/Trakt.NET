### Configuration

In this example we take a look at the possible configuration settings.

First, we create a new Trakt.NET client.

```csharp
using TraktNet;

Console.WriteLine("Please enter your Trakt Client-ID:");
string clientID = Console.ReadLine();

var client = new TraktClient(clientID);
```

The following snippet shows the status flags, when the client's Client-Secret is not set.

```csharp
Console.WriteLine($"Client Id: {client.ClientId}");
Console.WriteLine($"Client Secret: {client.ClientSecret}\n");

Console.WriteLine($"Requests without Authorization possible: {client.IsValidForUseWithoutAuthorization}");
Console.WriteLine($"Authentication possible: {client.IsValidForAuthenticationProcess}");
Console.WriteLine($"Requests with Authorization possible: {client.IsValidForUseWithAuthorization}");
```

Here, we set the Client-Secret and take another look the status flags.

```csharp
Console.WriteLine("Please enter your Trakt Client-Secret:");
client.ClientSecret = Console.ReadLine();

Console.WriteLine($"Client Id: {client.ClientId}");
Console.WriteLine($"Client Secret: {client.ClientSecret}\n");

Console.WriteLine($"Requests without Authorization possible: {client.IsValidForUseWithoutAuthorization}");
Console.WriteLine($"Authentication possible: {client.IsValidForAuthenticationProcess}");
Console.WriteLine($"Requests with Authorization possible: {client.IsValidForUseWithAuthorization}");
```

It is possible to create an authorization instance manually, if we have the Access Token and Refresh Token values.

```csharp
using TraktNet.Objects.Authentication;

// We create a new authorization instance with already existing access token and refresh token.
client.Authorization = TraktAuthorization.CreateWith(DateTime.Now, 90 * 24 * 3600, "FakeAccessToken", "FakeRefreshToken");

Console.WriteLine($"Client Id: {client.ClientId}");
Console.WriteLine($"Client Secret: {client.ClientSecret}\n");

Console.WriteLine($"Access Token: {client.Authorization.AccessToken}");
Console.WriteLine($"Refresh Token: {client.Authorization.RefreshToken}\n");

Console.WriteLine($"Requests without Authorization possible: {client.IsValidForUseWithoutAuthorization}");
Console.WriteLine($"Authentication possible: {client.IsValidForAuthenticationProcess}");
Console.WriteLine($"Requests with Authorization possible: {client.IsValidForUseWithAuthorization}");
```

The following property determines the used Trakt API version. The default value is currently 2.

```csharp
Console.WriteLine($"API Version: {client.Configuration.ApiVersion}");
```

It is possible to use the staging environment for testing purposes.

With `client.Configuration.UseSandboxEnvironment` we can enable this environment, which changes the API's base URL.

```csharp
Console.WriteLine($"API Base Url (UseStagingUrl == false): {client.Configuration.BaseUrl}");
client.Configuration.UseSandboxEnvironment = true;
Console.WriteLine($"API Base Url (UseStagingUrl == true): {client.Configuration.BaseUrl}");
```
