# Favorites Post Builder

In this example we use the post builder methods to create a [`ITraktSyncFavoritesPost`](xref:TraktNet.Objects.Post.Syncs.Favorites.ITraktSyncFavoritesPost).

First, we create a new Trakt.NET client.

[!code-csharp[](../../../codesnippets/examples/parameters/postbuilder/FavoritesPostBuilderExample.cs#L19-L25)]

[!code-csharp[](../../../codesnippets/examples/parameters/postbuilder/FavoritesPostBuilderExample.cs#L27-L28)]

The following lines show how to create a favorites post with its post builder.

We get some sample data.

[!code-csharp[](../../../codesnippets/examples/parameters/postbuilder/FavoritesPostBuilderExample.cs#L33-L34)]

We use the post builder to create a favorites post.

[!code-csharp[](../../../codesnippets/examples/parameters/postbuilder/FavoritesPostBuilderExample.cs#L37-L40)]

Then we use the created favorites post in a request.

[!code-csharp[](../../../codesnippets/examples/parameters/postbuilder/FavoritesPostBuilderExample.cs#L44-L44)]

__The complete code for this example can be found at: [Trakt.NET/docs/codesnippets/examples/parameters/postbuilder/FavoritesPostBuilderExample.cs](https://github.com/henrikfroehling/Trakt.NET/tree/v1.4.0/docs/codesnippets/examples/parameters/postbuilder/FavoritesPostBuilderExample.cs)__
