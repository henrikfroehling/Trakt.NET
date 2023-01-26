try
{
    var pagedParameters = new TraktPagedParameters { Page = 2 };

    TraktPagedResponse<ITraktTrendingShow> trendingShowsResponse = await client.Shows.GetTrendingShowsAsync(
        new TraktExtendedInfo { Full = true },
        pagedParameters: pagedParameters
    );

    foreach (ITraktTrendingShow trendingShow in trendingShowsResponse)
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