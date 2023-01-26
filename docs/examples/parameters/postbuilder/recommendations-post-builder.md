# Recommendations Post Builder

In this example we use the post builder methods to create a [`ITraktSyncRecommendationsPost`](xref:TraktNet.Objects.Post.Syncs.Recommendations.ITraktSyncRecommendationsPost).

First, we create a new Trakt.NET client.

[!code-csharp[](../../../codesnippets/examples/auth/ClientSetup.cs)]

```csharp
// For this example we do not want to manipulate the production API
client.Configuration.UseSandboxEnvironment = true;
```

The following lines show how to create a recommendations post with its post builder.

We get some sample data.

[!code-csharp[](../../../codesnippets/examples/parameters/postbuilder/RecommendationsPostBuilder.cs#L12-L13)]

We use the post builder to create a recommendations post.

[!code-csharp[](../../../codesnippets/examples/parameters/postbuilder/RecommendationsPostBuilder.cs#L16-L19)]

Then we use the created recommendations post in a request.

[!code-csharp[](../../../codesnippets/examples/parameters/postbuilder/RecommendationsPostBuilder.cs#L23-L23)]

Here is the complete code:

[!code-csharp[](../../../codesnippets/examples/parameters/postbuilder/RecommendationsPostBuilder.cs)]
