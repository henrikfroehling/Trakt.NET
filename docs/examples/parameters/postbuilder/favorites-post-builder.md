# Favorites Post Builder

In this example we use the post builder methods to create a [`ITraktSyncFavoritesPost`](xref:TraktNet.Objects.Post.Syncs.Favorites.ITraktSyncFavoritesPost).

First, we create a new Trakt.NET client.

[!code-csharp[](../../../codesnippets/examples/parameters/postbuilder/FavoritesPostBuilder.cs#L10-L14)]

[!code-csharp[](../../../codesnippets/examples/parameters/postbuilder/FavoritesPostBuilder.cs#L18-L19)]

The following lines show how to create a favorites post with its post builder.

We get some sample data.

[!code-csharp[](../../../codesnippets/examples/parameters/postbuilder/FavoritesPostBuilder.cs#L24-L25)]

We use the post builder to create a favorites post.

[!code-csharp[](../../../codesnippets/examples/parameters/postbuilder/FavoritesPostBuilder.cs#L28-L31)]

Then we use the created favorites post in a request.

[!code-csharp[](../../../codesnippets/examples/parameters/postbuilder/FavoritesPostBuilder.cs#L35-L35)]

__The complete code for this example can be found at: [Trakt.NET/docs/codesnippets/examples/parameters/postbuilder/FavoritesPostBuilder.cs](https://github.com/henrikfroehling/Trakt.NET/tree/release-1.4.0/docs/codesnippets/examples/parameters/postbuilder/FavoritesPostBuilder.cs)__
