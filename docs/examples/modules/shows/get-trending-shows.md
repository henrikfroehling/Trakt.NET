# Get Trending Shows

In this example we get the first two pages of trending shows.

Since we do not need authentication or authorization for this example, only the Client-ID is required.

[!code-csharp[](../../../codesnippets/examples/ClientSetup.cs)]

The following lines show how to get the first page of trending shows.

If no [`TraktPagedParameters`](xref:TraktNet.Parameters.TraktPagedParameters) are given, the default page is the first page and the default limit per page is 10 items.

[!code-csharp[](../../../codesnippets/examples/modules/shows/TrendingShows.cs#L7-L12)]

For getting the second page, we use the [`TraktPagedParameters`](xref:TraktNet.Parameters.TraktPagedParameters) for setting the page we want to get.

[!code-csharp[](../../../codesnippets/examples/modules/shows/TrendingShowsPaged.cs#L3-L3)]

[!code-csharp[](../../../codesnippets/examples/modules/shows/TrendingShowsPaged.cs#L5-L13)]

Here are the complete codes.

Trending Shows with default first page:
[!code-csharp[](../../../codesnippets/examples/modules/shows/TrendingShows.cs)]

Trending Shows with second page:
[!code-csharp[](../../../codesnippets/examples/modules/shows/TrendingShowsPaged.cs)]
