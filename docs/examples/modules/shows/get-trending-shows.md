# Get Trending Shows

In this example we get the first two pages of trending shows.

Since we do not need authentication or authorization for this example, only the Client-ID is required.

[!code-csharp[](../../../codesnippets/examples/modules/shows/TrendingShowsExample.cs#L13-L16)]

The following lines show how to get the first page of trending shows.

If no [`TraktPagedParameters`](xref:TraktNet.Parameters.TraktPagedParameters) are given, the default page is the first page and the default limit per page is 10 items.

[!code-csharp[](../../../codesnippets/examples/modules/shows/TrendingShowsExample.cs#L20-L25)]

For getting the second page, we use the [`TraktPagedParameters`](xref:TraktNet.Parameters.TraktPagedParameters) for setting the page we want to get.

[!code-csharp[](../../../codesnippets/examples/modules/shows/TrendingShowsPagedExample.cs#L20-L20)]

[!code-csharp[](../../../codesnippets/examples/modules/shows/TrendingShowsPagedExample.cs#L22-L30)]

Here are the complete codes.

Trending Shows with default first page:
[Trakt.NET/docs/codesnippets/examples/modules/shows/TrendingShowsExample.cs](https://github.com/henrikfroehling/Trakt.NET/tree/release-1.4.0/docs/codesnippets/examples/modules/shows/TrendingShowsExample.cs)

Trending Shows with second page:
[Trakt.NET/docs/codesnippets/examples/modules/shows/TrendingShowsPagedExample.cs](https://github.com/henrikfroehling/Trakt.NET/tree/release-1.4.0/docs/codesnippets/examples/modules/shows/TrendingShowsPagedExample.cs)
