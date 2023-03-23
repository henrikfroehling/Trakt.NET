# Device Authentication

In this example we authenticate our Trakt.NET client with the Device Authentication method to get Trakt authorization, which is required for OAuth requests.

For authentication and authorization requests the Client-ID and Client-Secret are both required.

[!code-csharp[](../../codesnippets/examples/auth/ClientSetup.cs)]

We can now request authorization by authenticating with the Device Authentication method.

The following lines show the steps which are required to get an authorization.

Create a new device

[!code-csharp[](../../codesnippets/examples/auth/DeviceAuthentication.cs#L30-L32)]

The created device has a verification URL

[!code-csharp[](../../codesnippets/examples/auth/DeviceAuthentication.cs#L46-L46)]

which the user needs to visit.

Secondly, the created device has a user code

[!code-csharp[](../../codesnippets/examples/auth/DeviceAuthentication.cs#L47-L47)]

which the user needs to enter on the verification website.

The user needs to visit the verification website and enter the user code.

[!code-csharp[](../../codesnippets/examples/auth/DeviceAuthentication.cs#L45-L47)]

We poll for authorization.

[!code-csharp[](../../codesnippets/examples/auth/DeviceAuthentication.cs#L49-L67)]

The time window is a few minutes long before the polling fails.

[!code-csharp[](../../codesnippets/examples/auth/DeviceAuthentication.cs#L40-L40)]

There are some additional steps in this example, which are not required for authenticating. They only show the usage in the context of this example.

Refreshing an already existing authorization

[!code-csharp[](../../codesnippets/examples/auth/DeviceAuthentication.cs#L69-L86)]

Revoking an already existing authorization

[!code-csharp[](../../codesnippets/examples/auth/DeviceAuthentication.cs#L88-L99)]

Here is the complete code:

[!code-csharp[](../../codesnippets/examples/auth/DeviceAuthentication.cs)]
