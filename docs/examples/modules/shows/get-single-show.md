# Get Show Details

In this example we get the details of a single show.

Since we do not need authentication or authorization for this example, only the Client-ID is required.

[!code-csharp[](../../../codesnippets/examples/modules/shows/SingleShow.cs#L6-L9)]

Set the Trakt-ID or -Slug for the show.

[!code-csharp[](../../../codesnippets/examples/modules/shows/SingleShow.cs#L11-L15)]

The following lines show how to get minimal information about a show.

[!code-csharp[](../../../codesnippets/examples/modules/shows/SingleShow.cs#L18-L34)]

The following lines show how to get full information about a show. The only difference to the previous example is the [`new TraktExtendedInfo().SetFull()`](xref:TraktNet.Parameters.TraktExtendedInfo.SetFull) in line 10.

[!code-csharp[](../../../codesnippets/examples/modules/shows/SingleShowExtended.cs#L17-L34)]

Here are the complete codes.

Single Show without extended info:
[Trakt.NET/docs/codesnippets/examples/modules/shows/SingleShow.cs](https://github.com/henrikfroehling/Trakt.NET/tree/release-1.4.0/docs/codesnippets/examples/modules/shows/SingleShow.cs)

Single Show with extended info:
[Trakt.NET/docs/codesnippets/examples/modules/shows/SingleShowExtended.cs](https://github.com/henrikfroehling/Trakt.NET/tree/release-1.4.0/docs/codesnippets/examples/modules/shows/SingleShowExtended.cs)
