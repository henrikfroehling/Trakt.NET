# Authentication and Authorization

Authentication is necessary if you need to call Trakt API requests, that require authorization. Every method in the library, that requires authorization, indicates this in its method documentation.

The Trakt API provides two methods for authenticating users and both are supported by the library. See [here](auth.md#oauth-authentication) and [here](auth.md#device-authentication) for more information.

## Authorization

Authorization information for the Trakt API contains not only the access token but also a refresh token, that makes it possible to retrieve new authorization information without authenticating the user again and without the need of the user to interact.

The [`TraktAuthorization`](xref:TraktNet.Objects.Authentication.TraktAuthorization) class represents such authorization information. It also contains the UTC DateTime, when it was created and can tell you if it is expired and if the containing authorization information can be [refreshed](auth.md#refresh-authorization). You can get a new TraktAuthorization instance by authenticating the user either with [OAuth](auth.md#oauth-authentication)- or [Device](auth.md#device-authentication)-Authentication.

If you already have an access token (and optionally a refresh token), you can create a new [`ITraktAuthorization`](xref:TraktNet.Objects.Authentication.ITraktAuthorization) instance in one of the following ways:

```csharp
using TraktNet.Objects.Authentication;

ITraktAuthorization authorization = TraktAuthorization.CreateWith("existing access token");

// or

ITraktAuthorization authorization = TraktAuthorization.CreateWith("existing access token", "existing refresh token");

// or,
// if you also have the DateTime, when the authorization was created
// and the value, after which the authorization expires

DateTime createdAt = DateTime.Now.AddDays(-30); // 30 days ago
uint expiresInSeconds = 3600 * 24 * 90; // 90 days (default value), has to be in seconds

ITraktAuthorization authorization = TraktAuthorization.CreateWith(createdAt, expiresInSeconds, "existing access token");
ITraktAuthorization authorization = TraktAuthorization.CreateWith(createdAt, expiresInSeconds, "existing access token", "existing refresh token");

// or

ITraktAuthorization authorization = TraktAuthorization.CreateWith(expiresInSeconds, "existing access token");
ITraktAuthorization authorization = TraktAuthorization.CreateWith(expiresInSeconds, "existing access token", "existing refresh token");

// or

ITraktAuthorization authorization = TraktAuthorization.CreateWith(createdAt, "existing access token");
ITraktAuthorization authorization = TraktAuthorization.CreateWith(createdAt, "existing access token", "existing refresh token")
```

And then just pass it to your [`TraktClient`](xref:TraktNet.TraktClient) instance:

```csharp
client.Authorization = authorization;
```

## OAuth Authentication

The workflow for authenticating users with the [traditional OAuth method](https://trakt.docs.apiary.io/#reference/authentication-oauth) is the following:

1. Create an authorization URL: `string authorizationUrl = client.Authentication.CreateAuthorizationUrl();` [Reference](xref:TraktNet.Modules.TraktAuthenticationModule.CreateAuthorizationUrl)
2. Your users need to visit the `authorizationUrl`'s webpage.
3. Your users need to provide you a PIN code that they get from Trakt.tv.
4. Get authorization with the PIN code provided by your users:

```csharp
using TraktNet.Objects.Authentication;

string code = "12345678"; // PIN code from your users
ITraktAuthorization authorization = await client.Authentication.GetAuthorizationAsync(code);

// or

client.Authentication.OAuthAuthorizationCode = code;
ITraktAuthorization authorization = await client.Authentication.GetAuthorizationAsync();
```

> [!NOTE]
> You don't need to pass the returned [`ITraktAuthorization`](xref:TraktNet.Objects.Authentication.ITraktAuthorization) to your [`TraktClient`](xref:TraktNet.TraktClient) instance. This happens automatically inside the library.

> [!NOTE]
> A [`TraktAuthenticationOAuthException`](xref:TraktNet.Exceptions.TraktAuthenticationOAuthException) will be thrown if the code provided by your users is invalid.

[Here](../examples/auth/oauth-authentication.md) is an example of how to authenticate a user with OAuth Authentication.

## Device Authentication

The workflow for authenticating users with the [Device method](https://trakt.docs.apiary.io/#reference/authentication-devices) is the following:

1. Create a new [`ITraktDevice`](xref:TraktNet.Objects.Authentication.ITraktDevice): `ITraktDevice device = await client.Authentication.GenerateDeviceAsync();` ([Reference](xref:TraktNet.Modules.TraktAuthenticationModule.GenerateDeviceAsync(System.String,System.Threading.CancellationToken))) The returned [`ITraktDevice`](xref:TraktNet.Objects.Authentication.ITraktDevice) is valid for about ten minutes and contains a device code and a verification URL.
2. Your users need to visit the [`device.VerificationUrl`](xref:TraktNet.Objects.Authentication.ITraktDevice.VerificationUrl)'s web page and to enter the [`device.UserCode`](xref:TraktNet.Objects.Authentication.ITraktDevice.UserCode) on that web page.
3. Simultaneously you need to poll for the new authorization. This process will stop as soon as your users have authenticated your application. But the process will not take any longer than 10 minutes. If your users have not authenticated your application after the given time period, you need to start over the whole process as of step (1).

```csharp
using TraktNet.Objects.Authentication;

ITraktAuthorization authorization = await client.Authentication.PollForAuthorizationAsync();
```

> [!NOTE]
> You don't need to pass the returned [`ITraktAuthorization`](xref:TraktNet.Objects.Authentication.ITraktAuthorization) to your [`TraktClient`](xref:TraktNet.TraktClient) instance. This happens automatically inside the library.

> [!NOTE]
> A [`TraktAuthenticationDeviceException`](xref:TraktNet.Exceptions.TraktAuthenticationDeviceException) will be thrown, if [`PollForAuthorizationAsync()`](xref:TraktNet.Modules.TraktAuthenticationModule.PollForAuthorizationAsync(System.Threading.CancellationToken)) fails.

[Here](../examples/auth/device-authentication.md) is an example of how to authenticate a user with Device Authentication.

## Refresh Authorization

The Trakt authorization information will be valid for 90 days for each one of your users. You need to refresh the authorization before the current one expires. Your [`ITraktAuthorization`](xref:TraktNet.Objects.Authentication.ITraktAuthorization) needs to have a valid refresh token set. You can check this with its property [`IsRefreshPossible`](xref:TraktNet.Objects.Authentication.ITraktAuthorization.IsRefreshPossible). The [`ITraktAuthorization`](xref:TraktNet.Objects.Authentication.ITraktAuthorization) interface has the property [`IsExpired`](xref:TraktNet.Objects.Authentication.ITraktAuthorization.IsExpired), that tells you if it is expired. To check, if an authorization was revoked by the user, you can call the following method:

```csharp
using TraktNet.Objects.Authentication;

// Precondition: client.Authorization is already set
bool expiredOrRevoked = await client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync();

// or

ITraktAuthorization yourAuthorization = TraktAuthorization.CreateWith("access token");
bool expiredOrRevoked = await client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync(yourAuthorization);
```

Alternatively, you can directly check an access token:

```csharp
string myAccessToken = "access token";
bool revoked = await client.Authentication.CheckIfAccessTokenWasRevokedOrIsNotValidAsync(myAccessToken);
```

To actually refresh the current authorization, simply call the following method:

```csharp
using TraktNet.Objects.Authentication;

// Precondition: client.Authorization is already set
ITraktAuthorization newAuthorization = await client.Authentication.RefreshAuthorizationAsync();
```

> [!NOTE]
> You don't need to pass the returned [`ITraktAuthorization`](xref:TraktNet.Objects.Authentication.ITraktAuthorization) to your [`TraktClient`](xref:TraktNet.TraktClient) instance. This happens automatically inside the library.

## Revoke Authorization

Revoking the current authorization is also very simple:

```csharp
await client.Authentication.RevokeAuthorizationAsync();
```

> [!NOTE]
> After a successful call to [`RevokeAuthorizationAsync()`](xref:TraktNet.Modules.TraktAuthenticationModule.RevokeAuthorizationAsync(System.Threading.CancellationToken)), [`client.Authorization`](xref:TraktNet.TraktClient.Authorization) will return a default and invalid [`ITraktAuthorization`](xref:TraktNet.Objects.Authentication.ITraktAuthorization) instance.
