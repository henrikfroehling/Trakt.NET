using TraktNet;
using TraktNet.Exceptions;
using TraktNet.Objects.Get.Shows;
using TraktNet.Responses;

namespace Trakt.NET.Examples.Modules.Shows;

internal static class SingleShowExample
{
    internal static async Task RunAsync()
    {
        Console.WriteLine("Trakt.NET - Get Single Show Example");
        Console.WriteLine();

        Console.WriteLine("Please enter your Trakt Client-ID:");
        string? clientID = Console.ReadLine();

        var client = new TraktClient(clientID);

        Console.WriteLine("Enter the Trakt-Id or -Slug of the Show:");
        string? showIdOrSlug = Console.ReadLine();

        showIdOrSlug = string.IsNullOrEmpty(showIdOrSlug) ? "game-of-thrones" : showIdOrSlug; // Game of Thrones as fallback

        try
        {
            TraktResponse<ITraktShow> showResponse = await client.Shows.GetShowAsync(showIdOrSlug);

            ITraktShow show = showResponse.Value;

            Console.WriteLine($"Title: {show.Title}");
            Console.WriteLine($"Year: {show.Year ?? 0}");

            ITraktShowIds ids = show.Ids;

            if (ids != null)
            {
                Console.WriteLine($"Trakt-Id: {ids.Trakt}");
                Console.WriteLine($"Slug: {ids.Slug}");
                Console.WriteLine($"ImDB-Id: {ids.Imdb}");
                Console.WriteLine($"TmDB-Id: {ids.Tmdb ?? 0}");
                Console.WriteLine($"TVDB-Id: {ids.Tvdb ?? 0}");
                Console.WriteLine($"TVRage-Id: {ids.TvRage ?? 0}");
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

        Console.WriteLine();
    }
}
