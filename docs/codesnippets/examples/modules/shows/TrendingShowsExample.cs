using TraktNet;
using TraktNet.Exceptions;
using TraktNet.Objects.Get.Shows;
using TraktNet.Parameters;
using TraktNet.Responses;

namespace Trakt.NET.Examples.Modules.Shows;

internal static class TrendingShowsExample
{
    internal static async Task RunAsync()
    {
        Console.WriteLine("Please enter your Trakt Client-ID:");
        string? clientID = Console.ReadLine();

        var client = new TraktClient(clientID);

        try
        {
            TraktPagedResponse<ITraktTrendingShow> trendingShowsResponse = await client.Shows.GetTrendingShowsAsync(new TraktExtendedInfo { Full = true });

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
    }
}
