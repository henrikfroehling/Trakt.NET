# Paging

[`TraktPagedResponse<TContentType>`](xref:TraktNet.Responses.TraktPagedResponse`1)s have a builtin feature for navigating through pages.

A paged response has two properties which return whether there are additional pages available.

- `HasPreviousPage`: Returns whether you can navigate to a previous page.
- `HasNextPage`: Returns whether you can navigate to a next page.

For navigating through pages, a paged response provides the following methods:

- `GetPreviousPageAsync()`: Navigate to a previous page, if there is one. Otherwise, it just returns the current page.
- `GetNextPageAsync()`: Navigate to a next page, if there is one. Otherwise, it just returns the current page.

These methods use the same item count per page as the original paged response.

## Example
### Get all trending shows
```csharp
using TraktNet;
using TraktNet.Exceptions;
using TraktNet.Objects.Get.Shows;
using TraktNet.Parameters;
using TraktNet.Responses;

var client = new TraktClient("client-id");

try
{
    const int itemCountPerPage = 40;

    var limitItemsPerPage = new TraktPagedParameters
    {
        Limit = itemCountPerPage
    };

    // Get the first page with 40 items
    TraktPagedResponse<ITraktTrendingShow> trendingShowsResponse = await client.Shows.GetTrendingShowsAsync(pagedParameters: limitItemsPerPage);

    // Do something with the first page of trending shows response...

    // Basically, load all pages of trending shows.
    // Each page with 40 items.
    while (trendingShowsResponse.HasNextPage)
    {
        // Get the next page
        trendingShowsResponse = await trendingShowsResponse.GetNextPageAsync();

        // Do something with the current page of trending shows response...
    }
}
catch (TraktException ex)
{
    // ...
}
```

### Get the first 10 pages of trending shows backwards
```csharp
using TraktNet;
using TraktNet.Exceptions;
using TraktNet.Objects.Get.Shows;
using TraktNet.Parameters;
using TraktNet.Responses;

var client = new TraktClient("client-id");

try
{
    const int itemCountPerPage = 40;

    var limitItemsPerPage = new TraktPagedParameters
    {
        Page = 10, // Start with 10th page
        Limit = itemCountPerPage
    };

    // Get the 10th page with 40 items
    TraktPagedResponse<ITraktTrendingShow> trendingShowsResponse = await client.Shows.GetTrendingShowsAsync(pagedParameters: limitItemsPerPage);

    // Do something with the 10th page of trending shows response...

    // Load all previous pages of trending shows.
    // Each page with 40 items.
    while (trendingShowsResponse.HasPreviousPage)
    {
        // Get the previous page
        trendingShowsResponse = await trendingShowsResponse.GetPreviousPageAsync();

        // Do something with the current page of trending shows response...
    }
}
catch (TraktException ex)
{
    // ...
}
```
