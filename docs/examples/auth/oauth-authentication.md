# OAuth Authentication

In this example we authenticate our Trakt.NET client with the OAuth Authentication method to get Trakt authorization, which is required for OAuth requests.

For authentication and authorization requests the Client-ID and Client-Secret are both required.

[!code-csharp[](../../codesnippets/examples/auth/OAuthAuthenticationExample.cs#L16-L22)]

We can now request authorization by authenticating with the OAuth Authentication method.

The following lines show the steps which are required to get an authorization.

## Create Authorization URL

Create an authorization URL:

[!code-csharp[](../../codesnippets/examples/auth/OAuthAuthenticationExample.cs#L26-L26)]

The user needs to visit the authorization URL website

[!code-csharp[](../../codesnippets/examples/auth/OAuthAuthenticationExample.cs#L30-L35)]

## Get Authorization

Trakt.tv returns a code which is needed to get the Trakt authorization

[!code-csharp[](../../codesnippets/examples/auth/OAuthAuthenticationExample.cs#L39-L59)]

There are some additional steps in this example, which are not required for authenticating. They only show the usage in the context of this example.

## Refresh Authorization

Refreshing an already existing authorization

[!code-csharp[](../../codesnippets/examples/auth/OAuthAuthenticationExample.cs#L61-L80)]

## Revoke Authorization

Revoking an already existing authorization

[!code-csharp[](../../codesnippets/examples/auth/OAuthAuthenticationExample.cs#L82-L93)]

__The complete code for this example can be found at: [Trakt.NET/docs/codesnippets/examples/auth/OAuthAuthenticationExample.cs](https://github.com/henrikfroehling/Trakt.NET/tree/v1.4.0/docs/codesnippets/examples/auth/OAuthAuthenticationExample.cs)__
