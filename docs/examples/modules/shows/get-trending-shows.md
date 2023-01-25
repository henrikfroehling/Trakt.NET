# Get trending shows

In this example we get the first two pages of trending shows.

Since we do not need authentication or authorization for this example, only the Client-ID is required.

```csharp
using TraktNet;

Console.ReadLine("Please enter your Trakt Client-ID:");
string clientID = Console.ReadLine();

var client = new TraktClient(clientID);
```

The following lines show how to get the first page of trending shows.

If no [`TraktPagedParameters`](xref:TraktNet.Parameters.TraktPagedParameters) are given, the default page is the first page and the default limit per page is 10 items.

```csharp
using TraktNet.Exceptions;
using TraktNet.Parameters;
using TraktNet.Responses;

try
{
    TraktPagedResponse<ITraktTrendingShow> trendingShowsResponse = await client.Shows.GetTrendingShowsAsync(new TraktExtendedInfo { Full = true });

    for (ITraktTrendingShow trendingShow in trendingShowsResponse)
    {
        Console.WriteLine($"Watchers: {trendingShow.Watchers}, Title: {trendingShow.Title}, Year: {trendingShow.Year}, Rating: {trendingShow.Rating}");
    }
}
catch (TraktException ex)
{
    Console.WriteLine("-------------- Trakt Exception --------------");
    Console.WriteLine($"Exception message: {ex.Message}");
    Console.WriteLine($"Status code: {ex.StatusCode}");
    Console.WriteLine($"Request URL: {ex.RequestUrl}");
    Console.WriteLine($"Request message: {ex.RequestBody}");
    Console.WriteLine($"Request response: {ex.Response}");
    Console.WriteLine($"Server Reason Phrase: {ex.ServerReasonPhrase}");
    Console.WriteLine("---------------------------------------------");
}
```

For getting the second page, we use the [`TraktPagedParameters`](xref:TraktNet.Parameters.TraktPagedParameters) for setting the page we want to get.

```csharp
try
{
    var pagedParameters = new TraktPagedParameters { Page = 2 };

    TraktPagedResponse<ITraktTrendingShow> trendingShowsResponse = await client.Shows.GetTrendingShowsAsync(
        new TraktExtendedInfo { Full = true },
        pagedParameters: pagedParameters
    );

    for (ITraktTrendingShow trendingShow in trendingShowsResponse)
    {
        Console.WriteLine($"Watchers: {trendingShow.Watchers}, Title: {trendingShow.Title}, Year: {trendingShow.Year}, Rating: {trendingShow.Rating}");
    }
}
catch (TraktException ex)
{
    Console.WriteLine("-------------- Trakt Exception --------------");
    Console.WriteLine($"Exception message: {ex.Message}");
    Console.WriteLine($"Status code: {ex.StatusCode}");
    Console.WriteLine($"Request URL: {ex.RequestUrl}");
    Console.WriteLine($"Request message: {ex.RequestBody}");
    Console.WriteLine($"Request response: {ex.Response}");
    Console.WriteLine($"Server Reason Phrase: {ex.ServerReasonPhrase}");
    Console.WriteLine("---------------------------------------------");
}
```
