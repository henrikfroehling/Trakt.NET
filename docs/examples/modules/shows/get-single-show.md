# Get Show Details

In this example we get the details of a single show.

Since we do not need authentication or authorization for this example, only the Client-ID is required.

[!code-csharp[](../../../codesnippets/examples/ClientSetup.cs)]

Set the Trakt-ID or -Slug for the show.

```csharp
Console.WriteLine("Enter the Trakt-Id or -Slug of the Show:");
string showIdOrSlug = Console.ReadLine();

if (string.IsNullOrEmpty(showIdOrSlug))
    showIdOrSlug = "game-of-thrones"; // Game of Thrones as fallback
```

The following lines show how to get minimal information about a show.

[!code-csharp[](../../../codesnippets/examples/modules/shows/SingleShow.cs#L7-L24)]

The following lines show how to get full information about a show. The only difference to the previous example is the [`new TraktExtendedInfo().SetFull()`](xref:TraktNet.Parameters.TraktExtendedInfo.SetFull) in line 10.

[!code-csharp[](../../../codesnippets/examples/modules/shows/SingleShowExtended.cs#L5-L22)]

Here are the complete codes.

Single Show without extended info:
[!code-csharp[](../../../codesnippets/examples/modules/shows/SingleShow.cs)]

Single Show with extended info:
[!code-csharp[](../../../codesnippets/examples/modules/shows/SingleShowExtended.cs)]
