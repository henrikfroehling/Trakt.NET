# Favorites Post Builder

In this example we use the post builder methods to create a [`ITraktSyncFavoritesPost`](xref:TraktNet.Objects.Post.Syncs.Favorites.ITraktSyncFavoritesPost).

First, we create a new Trakt.NET client.

[!code-csharp[](../../../codesnippets/examples/auth/ClientSetup.cs)]

```csharp
// For this example we do not want to manipulate the production API
client.Configuration.UseSandboxEnvironment = true;
```

The following lines show how to create a favorites post with its post builder.

We get some sample data.

[!code-csharp[](../../../codesnippets/examples/parameters/postbuilder/FavoritesPostBuilder.cs#L12-L13)]

We use the post builder to create a favorites post.

[!code-csharp[](../../../codesnippets/examples/parameters/postbuilder/FavoritesPostBuilder.cs#L16-L19)]

Then we use the created favorites post in a request.

[!code-csharp[](../../../codesnippets/examples/parameters/postbuilder/FavoritesPostBuilder.cs#L23-L23)]
