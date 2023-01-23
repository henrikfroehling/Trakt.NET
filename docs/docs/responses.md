## Responses

Trakt.NET has a response system with four different response types.

- [`TraktNoContentResponse`](xref:TraktNet.Responses.TraktNoContentResponse) for Trakt responses without content (HTTP Code 204)
- [`TraktResponse<TContentType>`](xref:TraktNet.Responses.TraktResponse`1) for Trakt responses that return only a single object, where `TContentType` is the type of that object
- [`TraktListResponse<TContentType>`](xref:TraktNet.Responses.TraktListResponse`1) for Trakt responses that return a list of objects, where `TContentType` is the type of a list item object
- [`TraktPagedResponse<TContentType>`](xref:TraktNet.Responses.TraktPagedResponse`1) for Trakt responses that return a list and pagination headers, where `TContentType` is the type of a list item object

### Response Properties

- `bool IsSuccess`, indicating whether a request was successful
- `Exception Exception`, containing the exception which was thrown on failure (only assigned, if [`client.Configuration.ThrowResponseExceptions`](xref:TraktNet.Core.TraktConfiguration.ThrowResponseExceptions) is set to `false`

[`TraktResponse<TContentType>`](xref:TraktNet.Responses.TraktResponse`1), [`TraktListResponse<TContentType>`](xref:TraktNet.Responses.TraktListResponse`1) and [`TraktPagedResponse<TContentType>`](xref:TraktNet.Responses.TraktPagedResponse`1) also have the following properties:

- `bool HasValue`, indicating whether a response contains a value (single object or list of objects)
- `TContentType Value`, the actual response value (single object for [`TraktResponse<TContentType>`](xref:TraktNet.Responses.TraktResponse`1) and `IEnumerable<TContentType>` for [`TraktListResponse<TContentType>`](xref:TraktNet.Responses.TraktListResponse`1) and [`TraktPagedResponse<TContentType>`](xref:TraktNet.Responses.TraktPagedResponse`1))

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

Following headers are available in [`TraktResponse<TContentType>`](xref:TraktNet.Responses.TraktResponse`1) and [`TraktListResponse<TContentType>`](xref:TraktNet.Responses.TraktListResponse`1):

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

Following headers are available in [`TraktPagedResponse<TContentType>`](xref:TraktNet.Responses.TraktPagedResponse`1)additionally:

- `int? PageCount`
- `int? ItemCount`

[`TraktNoContentResponse`](xref:TraktNet.Responses.TraktNoContentResponse) doesn't contain any headers.

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
