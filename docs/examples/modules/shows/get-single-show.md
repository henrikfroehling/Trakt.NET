# Get Show Details

In this example we get the details of a single show.

Since we do not need authentication or authorization for this example, only the Client-ID is required.

[!code-csharp[](../../../codesnippets/examples/modules/shows/SingleShowExample.cs#L12-L15)]

Set the Trakt-ID or -Slug for the show.

[!code-csharp[](../../../codesnippets/examples/modules/shows/SingleShowExample.cs#L17-L20)]

The following lines show how to get minimal information about a show.

[!code-csharp[](../../../codesnippets/examples/modules/shows/SingleShowExample.cs#L24-L41)]

The following lines show how to get full information about a show. The only difference to the previous example is the [`new TraktExtendedInfo().SetFull()`](xref:TraktNet.Parameters.TraktExtendedInfo.SetFull) in line 10.

[!code-csharp[](../../../codesnippets/examples/modules/shows/SingleShowExtendedExample.cs#L25-L42)]

Here are the complete codes.

Single Show without extended info:
[Trakt.NET/docs/codesnippets/examples/modules/shows/SingleShowExample.cs](https://github.com/henrikfroehling/Trakt.NET/tree/release-1.4.0/docs/codesnippets/examples/modules/shows/SingleShowExample.cs)

Single Show with extended info:
[Trakt.NET/docs/codesnippets/examples/modules/shows/SingleShowExtendedExample.cs](https://github.com/henrikfroehling/Trakt.NET/tree/release-1.4.0/docs/codesnippets/examples/modules/shows/SingleShowExtendedExample.cs)
