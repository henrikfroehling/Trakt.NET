using TraktNet;
using TraktNet.Exceptions;
using TraktNet.Objects.Get.Shows;
using TraktNet.Parameters;
using TraktNet.Responses;

namespace Trakt.NET.Examples.Modules.Shows;

internal static class GetShowsStreamExample
{
    internal static async Task RunAsync()
    {
        Console.WriteLine("Trakt.NET - Get Multiple Shows Example");
        Console.WriteLine();

        Console.WriteLine("Please enter your Trakt Client-ID:");
        string? clientID = Console.ReadLine();

        var client = new TraktClient(clientID);

        Console.WriteLine("Enter the Trakt-Id or -Slug of Show 1:");
        string? showIdOrSlug1 = Console.ReadLine();

        Console.WriteLine("Enter the Trakt-Id or -Slug of Show 2:");
        string? showIdOrSlug2 = Console.ReadLine();

        Console.WriteLine("Enter the Trakt-Id or -Slug of Show 3:");
        string? showIdOrSlug3 = Console.ReadLine();

        // Default fallback slugs.
        showIdOrSlug1 = string.IsNullOrEmpty(showIdOrSlug1) ? "game-of-thrones" : showIdOrSlug1;
        showIdOrSlug2 = string.IsNullOrEmpty(showIdOrSlug2) ? "mr-robot" : showIdOrSlug2;
        showIdOrSlug3 = string.IsNullOrEmpty(showIdOrSlug3) ? "breaking-bad" : showIdOrSlug3;

        try
        {
            var extendedInfo = new TraktExtendedInfo { Full = true };

            var parameters = new TraktMultipleObjectsQueryParams
            {
                showIdOrSlug1, // For this show we want only the minimal information.

                // The following shows will have full information.
                { showIdOrSlug2, extendedInfo },
                { showIdOrSlug3, extendedInfo }
            };

            IAsyncEnumerable<TraktResponse<ITraktShow>> mutlipleShowsResponse = client.Shows.GetShowsStreamAsync(parameters);

            await foreach (TraktResponse<ITraktShow> showResponse in mutlipleShowsResponse)
            {
                ITraktShow show = showResponse.Value;

                Console.WriteLine("-------------------------------------------------------------------------");

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

                Console.WriteLine($"Overview: {show.Overview}");

                if (show.FirstAired.HasValue)
                {
                    Console.WriteLine($"First Aired (UTC): {show.FirstAired.Value}");
                }

                ITraktShowAirs airs = show.Airs;

                if (airs != null)
                {
                    Console.WriteLine($"Airs on: {airs.Day}");
                    Console.WriteLine($"Airs at: {airs.Time}");
                    Console.WriteLine($"Airs in: {airs.TimeZoneId}");
                }

                Console.WriteLine($"Runtime: {show.Runtime ?? 0} Minutes");

                if (show.Genres != null)
                {
                    Console.WriteLine($"Genres: {string.Join(", ", show.Genres)}");
                }

                Console.WriteLine($"Certification: {show.Certification}");
                Console.WriteLine($"Network: {show.Network}");
                Console.WriteLine($"Aired Episodes: {show.AiredEpisodes ?? 0}");

                if (show.Status != null)
                {
                    Console.WriteLine($"Status: {show.Status.DisplayName}");
                }

                Console.WriteLine($"Rating: {show.Rating ?? 0.0f}");
                Console.WriteLine($"Votes: {show.Votes ?? 0}");
                Console.WriteLine($"Country Code: {show.CountryCode}");
                Console.WriteLine($"Language Code: {show.LanguageCode}");

                if (show.UpdatedAt.HasValue)
                {
                    Console.WriteLine($"Updated At (UTC): {show.UpdatedAt.Value}");
                }

                if (show.AvailableTranslationLanguageCodes != null)
                {
                    Console.WriteLine($"Available Translation Languages: {string.Join(", ", show.AvailableTranslationLanguageCodes)}");
                }

                Console.WriteLine($"Trailer: {show.Trailer}");
                Console.WriteLine($"Homepage: {show.Homepage}");
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
