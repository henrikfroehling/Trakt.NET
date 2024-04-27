# Device Authentication

In this example we authenticate our Trakt.NET client with the Device Authentication method to get Trakt authorization, which is required for OAuth requests.

For authentication and authorization requests the Client-ID and Client-Secret are both required.

[!code-csharp[](../../codesnippets/examples/auth/DeviceAuthenticationExample.cs#L13-L19)]

We can now request authorization by authenticating with the Device Authentication method.

The following lines show the steps which are required to get an authorization.

## Create a new device

[!code-csharp[](../../codesnippets/examples/auth/DeviceAuthenticationExample.cs#L24-L26)]

The created device has a verification URL

[!code-csharp[](../../codesnippets/examples/auth/DeviceAuthenticationExample.cs#L40-L40)]

which the user needs to visit.

Secondly, the created device has a user code

[!code-csharp[](../../codesnippets/examples/auth/DeviceAuthenticationExample.cs#L41-L41)]

which the user needs to enter on the verification website.

The user needs to visit the verification website and enter the user code.

[!code-csharp[](../../codesnippets/examples/auth/DeviceAuthenticationExample.cs#L39-L41)]

## Poll for Authorization

We poll for authorization.

[!code-csharp[](../../codesnippets/examples/auth/DeviceAuthenticationExample.cs#L43-L63)]

The time window is a few minutes long before the polling fails.

[!code-csharp[](../../codesnippets/examples/auth/DeviceAuthenticationExample.cs#L34-L34)]

There are some additional steps in this example, which are not required for authenticating. They only show the usage in the context of this example.

## Refresh Authorization

Refreshing an already existing authorization

[!code-csharp[](../../codesnippets/examples/auth/DeviceAuthenticationExample.cs#L65-L84)]

## Revoke Authorization

Revoking an already existing authorization

[!code-csharp[](../../codesnippets/examples/auth/DeviceAuthenticationExample.cs#L86-L97)]

__The complete code for this example can be found at: [Trakt.NET/docs/codesnippets/examples/auth/DeviceAuthenticationExample.cs](https://github.com/henrikfroehling/Trakt.NET/tree/release-1.4.0/docs/codesnippets/examples/auth/DeviceAuthenticationExample.cs)__
