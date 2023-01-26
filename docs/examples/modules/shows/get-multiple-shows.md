# Get details for multiple single shows

In this example we get the details of multiple single shows simultaneously.

Since we do not need authentication or authorization for this example, only the Client-ID is required.

[!code-csharp[](../../../codesnippets/examples/ClientSetup.cs)]

Set the Trakt-IDs or -Slugs for the shows.

```csharp
Console.WriteLine("Enter the Trakt-Id or -Slug of Show 1:");
string showIdOrSlug1 = Console.ReadLine();

Console.WriteLine("Enter the Trakt-Id or -Slug of Show 2:");
string showIdOrSlug2 = Console.ReadLine();

Console.WriteLine("Enter the Trakt-Id or -Slug of Show 3:");
string showIdOrSlug3 = Console.ReadLine();

// Default fallback slugs.
showIdOrSlug1 = string.IsNullOrEmpty(showIdOrSlug1) ? "game-of-thrones" : showIdOrSlug1;
showIdOrSlug2 = string.IsNullOrEmpty(showIdOrSlug2) ? "mr-robot" : showIdOrSlug2;
showIdOrSlug3 = string.IsNullOrEmpty(showIdOrSlug3) ? "breaking-bad" : showIdOrSlug3;
```

The following lines show how we can get the details of multiple shows in one library call.

We create a [TraktMultipleObjectsQueryParams](xref:TraktNet.Modules.TraktMultipleObjectsQueryParams) instance, which holds the ids of the shows.

[!code-csharp[](../../../codesnippets/examples/modules/shows/MultipleShows.cs#L9-L18)]

We use the [TraktMultipleObjectsQueryParams](xref:TraktNet.Modules.TraktMultipleObjectsQueryParams) for the request.

[!code-csharp[](../../../codesnippets/examples/modules/shows/MultipleShows.cs#L20-L82)]

Here is the complete code:

[!code-csharp[](../../../codesnippets/examples/modules/shows/MultipleShows.cs)]
