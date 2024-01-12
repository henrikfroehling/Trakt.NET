# Get Details For Multiple Single Shows

In this example we get the details of multiple single shows simultaneously.

Since we do not need authentication or authorization for this example, only the Client-ID is required.

[!code-csharp[](../../../codesnippets/examples/modules/shows/GetShowsStream.cs#L7-L10)]

Set the Trakt-IDs or -Slugs for the shows.

[!code-csharp[](../../../codesnippets/examples/modules/shows/GetShowsStream.cs#L12-L24)]

The following lines show how we can get the details of multiple shows in one library call.

We create a [TraktMultipleObjectsQueryParams](xref:TraktNet.Parameters.TraktMultipleObjectsQueryParams) instance, which holds the ids of the shows.

[!code-csharp[](../../../codesnippets/examples/modules/shows/GetShowsStream.cs#L30-L37)]

We use the [TraktMultipleObjectsQueryParams](xref:TraktNet.Parameters.TraktMultipleObjectsQueryParams) for the request.

[!code-csharp[](../../../codesnippets/examples/modules/shows/GetShowsStream.cs#L39-L101)]

__The complete code for this example can be found at: [Trakt.NET/docs/codesnippets/examples/modules/shows/GetShowsStream.cs](https://github.com/henrikfroehling/Trakt.NET/tree/release-1.4.0/docs/codesnippets/examples/modules/shows/GetShowsStream.cs)__
