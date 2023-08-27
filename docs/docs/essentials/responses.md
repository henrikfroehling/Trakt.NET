# Responses

**Trakt.NET** has a response system with four different response types.

## Response Types

- [`TraktNoContentResponse`](xref:TraktNet.Responses.TraktNoContentResponse) for Trakt responses without content (HTTP Code 20x)
- [`TraktResponse<TContentType>`](xref:TraktNet.Responses.TraktResponse`1) for Trakt responses that return only a single object, where `TContentType` is the type of that object
- [`TraktListResponse<TContentType>`](xref:TraktNet.Responses.TraktListResponse`1) for Trakt responses that return a list of objects, where `TContentType` is the type of a list item object
- [`TraktPagedResponse<TContentType>`](xref:TraktNet.Responses.TraktPagedResponse`1) for Trakt responses that return a list and pagination headers, where `TContentType` is the type of a list item object

## Response Properties

- `bool IsSuccess`, indicating whether a request was successful
- `Exception Exception`, containing the exception which was thrown on failure (only assigned, if [`client.Configuration.ThrowResponseExceptions`](xref:TraktNet.Core.TraktConfiguration.ThrowResponseExceptions) is set to `false`

[`TraktResponse<TContentType>`](xref:TraktNet.Responses.TraktResponse`1), [`TraktListResponse<TContentType>`](xref:TraktNet.Responses.TraktListResponse`1) and [`TraktPagedResponse<TContentType>`](xref:TraktNet.Responses.TraktPagedResponse`1) also have the following properties:

- `bool HasValue`, indicating whether a response contains a value (single object or list of objects)
- `TContentType Value`, the actual response value (single object for [`TraktResponse<TContentType>`](xref:TraktNet.Responses.TraktResponse`1) and `IList<TContentType>` for [`TraktListResponse<TContentType>`](xref:TraktNet.Responses.TraktListResponse`1) and [`TraktPagedResponse<TContentType>`](xref:TraktNet.Responses.TraktPagedResponse`1))

## Exceptions

By default, the library throws an exception, when a request fails.
This means, you should wrap each request in a `try`-`catch`-block.

You can [disable this behaviour](exceptionhandling.md#disabling-exceptions).

## Response Headers

Every [response type](responses.md#response-types), except [`TraktNoContentResponse`](xref:TraktNet.Responses.TraktNoContentResponse), contains response headers returned by the Trakt API.

Following headers are available in [`TraktResponse<TContentType>`](xref:TraktNet.Responses.TraktResponse`1), [`TraktListResponse<TContentType>`](xref:TraktNet.Responses.TraktListResponse`1) and [`TraktPagedResponse<TContentType>`](xref:TraktNet.Responses.TraktPagedResponse`1):

Which of the following headers is set depends on the request.

- `TraktSortBy SortBy`
- `TraktSortHow SortHow`
- `TraktSortBy AppliedSortBy`
- `TraktSortHow AppliedSortHow`
- `DateTime? StartDate`
- `DateTime? EndDate`
- `int? TrendingUserCount`
- `uint? Page`
- `uint? Limit`
- `bool? IsPrivateUser`
- `int? ItemId`
- `string ItemType`
- `string RateLimit`
- `int? RetryAfter`
- `string UpgradeURL`
- `bool? IsVIPUser`
- `int? AccountLimit`

Following headers are only available in [`TraktPagedResponse<TContentType>`](xref:TraktNet.Responses.TraktPagedResponse`1):

- `int? ItemCount`
- `int? PageCount`

## Example Usage

### Exceptions Enabled
```csharp
using TraktNet;
using TraktNet.Exceptions;
using TraktNet.Objects.Get.Shows;
using TraktNet.Parameters;
using TraktNet.Responses;

var client = new TraktClient("client-id");

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

    // Built in paging for paged responses
    if (trendingShowsResponse.HasNextPage)
    {
        trendingShowsResponse = await trendingShowsResponse.GetNextPageAsync();

        // Get back to previous page
        trendingShowsResponse = await trendingShowsResponse.GetPreviousPageAsync();
    }
}
catch (TraktException ex)
{
    // ...
}
catch (Exception ex)
{
    // ...
}
```

### Exceptions Disabled
```csharp
using TraktNet;
using TraktNet.Objects.Get.Shows;
using TraktNet.Parameters;
using TraktNet.Responses;

var client = new TraktClient("client-id");
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

    // Built in paging for paged responses
    if (trendingShowsResponse.HasNextPage)
    {
        trendingShowsResponse = await trendingShowsResponse.GetNextPageAsync();

        if (trendingShowsResponse)
        {
            // Get back to previous page
            trendingShowsResponse = await trendingShowsResponse.GetPreviousPageAsync();
        }
    }
}
else
{
    // on failure,
    // get the exception from the response
    Console.WriteLine(trendingShowsResponse.Exception);
}
```
