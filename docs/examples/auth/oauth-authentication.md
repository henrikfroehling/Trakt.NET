# OAuth Authentication

In this example we authenticate our Trakt.NET client with the OAuth Authentication method to get Trakt authorization, which is required for OAuth requests.

For authentication and authorization requests the Client-ID and Client-Secret are both required.

[!code-csharp[](../../codesnippets/examples/auth/OAuthAuthentication.cs#L6-L12)]

We can now request authorization by authenticating with the OAuth Authentication method.

The following lines show the steps which are required to get an authorization.

## Create Authorization URL

Create an authorization URL:

[!code-csharp[](../../codesnippets/examples/auth/OAuthAuthentication.cs#L38-L38)]

The user needs to visit the authorization URL website

[!code-csharp[](../../codesnippets/examples/auth/OAuthAuthentication.cs#L42-L44)]

## Get Authorization

Trakt.tv returns a code which is needed to get the Trakt authorization

[!code-csharp[](../../codesnippets/examples/auth/OAuthAuthentication.cs#L51-L69)]

There are some additional steps in this example, which are not required for authenticating. They only show the usage in the context of this example.

## Refresh Authorization

Refreshing an already existing authorization

[!code-csharp[](../../codesnippets/examples/auth/OAuthAuthentication.cs#L71-L88)]

## Revoke Authorization

Revoking an already existing authorization

[!code-csharp[](../../codesnippets/examples/auth/OAuthAuthentication.cs#L90-L101)]

__The complete code for this example can be found at: [Trakt.NET/docs/codesnippets/examples/auth/OAuthAuthentication.cs](https://github.com/henrikfroehling/Trakt.NET/tree/release-1.4.0/docs/codesnippets/examples/auth/OAuthAuthentication.cs)__
