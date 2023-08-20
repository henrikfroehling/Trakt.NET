# Streams

Streams provide a way to get multiple single objects, like movies, shows, etc. in a "single" requests.
"Single" request means that under the hood the library makes a single request for each object, but the user only has to make one library request.

Each object request is stored in a collection which is then passed into the library.
The library requests the data for each object from the API and returns an [`IAsyncEnumerable`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iasyncenumerable-1?view=net-7.0) with the responses for each object.

## Example

```csharp
using TraktNet.Parameters;

var extendedInfo = new TraktExtendedInfo { Full = true };

// Store the ids of each object in a collection.
var parameters = new TraktMultipleObjectsQueryParams
{
    "game-of-thrones", // For this show we want only the minimal information.

    // The following shows will have full information.
    { "breaking-bad", extendedInfo },
    { "the-last-of-us", extendedInfo }
};

// Get the responses for each show in an async stream.
// NOTE: DO NOT "await" here.
IAsyncEnumerable<TraktResponse<ITraktShow>> mutlipleShowsResponse = client.Shows.GetShowsStreamAsync(parameters);

// NOTE: Instead "await" the loop.
await foreach (TraktResponse<ITraktShow> showResponse in mutlipleShowsResponse)
{
    // Do something with the response.
}
```

This feature depends heavily on multiple object parameters. An overview of all can be found in the [references section](../references/requestparameters.md#multiple-ids).
