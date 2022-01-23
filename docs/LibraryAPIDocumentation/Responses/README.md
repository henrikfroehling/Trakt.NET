## Responses

Trakt.NET has a response system with four different response types.

- `TraktNoContentResponse` for Trakt responses without content (HTTP Code 204)
- `TraktResponse<TContentType>` for Trakt responses that return only a single object, where `TContentType` is the type of that object
- `TraktListResponse<TContentType>` for Trakt responses that return a list of objects, where `TContentType` is the type of a list item object
- `TraktPagedResponse<TContentType>` for Trakt responses that return a list and pagination headers, where `TContentType` is the type of a list item object

### Response Properties

- `bool IsSuccess`, indicating whether a request was successful
- `Exception Exception`, containing the exception which was thrown on failure (only assigned, if `client.Configuration.ThrowResponseExceptions` is set to `false`

`TraktResponse<TContentType>`, `TraktListResponse<TContentType>` and `TraktPagedResponse<TContentType>` also have the following properties:

- `bool HasValue`, indicating whether a response contains a value (single object or list of objects)
- `TContentType Value`, the actual response value (single object for `TraktResponse` and `IEnumerable<TContentType>` for `TraktListResponse` and `TraktPagedResponse`)

### Exceptions

By default, the library throws an exception, when a request fails.
This means, you should wrap each request in a `try`-`catch`-block.

You can disable this behaviour with the following setting:

```csharp
client.Configuration.ThrowResponseExceptions = false;
```

If you disable exceptions, they are still thrown, but will be catched internally.

You should then check if a request succeded by wrapping it in an `if`-statement, since each response type is implicitly converted to `bool`:

```csharp
var response = await client.Shows.GetShowAsync("game-of-thrones");

if (response) // or if (response.IsSuccess && response.HasValue)
{
    // process response
    ITraktShow show = response.Value;
}
else
{
    // get the exception, if request failed
    Exception exception = response.Exception;
}
```

### Response Headers

Every response type (see above) contains response headers returned by the Trakt API.

Following headers are available in `TraktResponse<TContentType>` and `TraktListResponse<TContentType>`:

- `string SortBy`
- `string SortHow`
- `string AppliedSortBy`
- `string AppliedSortHow`
- `DateTime? StartDate`
- `DateTime? EndDate`
- `int? TrendingUserCount`
- `uint? Page`
- `uint? Limit`
- `bool? IsPrivateUser`
- `int? ItemId`
- `string ItemType`

Following headers are available in `TraktPagedResponse<TContentType>` additionally:

- `int? PageCount`
- `int? ItemCount`

`TraktNoContentResponse` doesn't contain any headers.

### Example Usage

```csharp
using TraktNet;
using TraktNet.Objects.Get.Shows;
using TraktNet.Responses;
using TraktNet.Requests.Parameters;

var client = new TraktClient("client-id", "client-secret");

// set this to false, if requests shouldn't throw any exceptions
// enabled by default
// client.Configuration.ThrowResponseExceptions = false;

try
{
    TraktPagedResponse<ITraktTrendingShow> trendingShowsResponse = await client.Shows.GetTrendingShowsAsync(new TraktExtendedInfo() { Full = true }, 1, 10);

    // implicit conversion to bool
    // check for success not really necessary since exceptions are enabled
    if (trendingShowsResponse) // IsSuccess == true && HasValue == true
    {
        Console.WriteLine($"Current Page: {trendingShowsResponse.Page}");
        Console.WriteLine($"Current Page Limit: {trendingShowsResponse.Limit}");
        Console.WriteLine($"Page Count: {trendingShowsResponse.PageCount}");
        Console.WriteLine($"Total Item Count: {trendingShowsResponse.ItemCount}");

        // TraktPagedResponse and TraktListResponse implement IEnumerable<TContentType>
        foreach (ITraktTrendingShow trendingShow in trendingShowsResponse)
        {
            Console.WriteLine($"Show: {trendingShow.Title} / Watchers: {trendingShow.Watchers}");
        }

        List<ITraktTrendingShow> trendingShows = trendingShowsResponse; // implicit conversion
    }
}
catch (Exception ex)
{
    // ...
}

// ------------------------------------------------------
// same request with throwing exceptions disabled
client.Configuration.ThrowResponseExceptions = false;

TraktPagedResponse<ITraktTrendingShow> trendingShowsResponse = await client.Shows.GetTrendingShowsAsync(new TraktExtendedInfo() { Full = true }, 1, 10);

// implicit conversion to bool
if (trendingShowsResponse) // IsSuccess == true && HasValue == true
{
    Console.WriteLine($"Current Page: {trendingShowsResponse.Page}");
    Console.WriteLine($"Current Page Limit: {trendingShowsResponse.Limit}");
    Console.WriteLine($"Page Count: {trendingShowsResponse.PageCount}");
    Console.WriteLine($"Total Item Count: {trendingShowsResponse.ItemCount}");

    // TraktPagedResponse and TraktListResponse implement IEnumerable<TContentType>
    foreach (ITraktTrendingShow trendingShow in trendingShowsResponse)
    {
        Console.WriteLine($"Show: {trendingShow.Title} / Watchers: {trendingShow.Watchers}");
    }

    List<ITraktTrendingShow> trendingShows = trendingShowsResponse; // implicit conversion
}
else
{
    // on failure,
    // get the exception from the response
    Console.WriteLine(trendingShowsResponse.Exception);
}
```
