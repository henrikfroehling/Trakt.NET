namespace GetSingleShowExample
{
    using System;
    using System.Threading.Tasks;
    using TraktNet;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Requests.Parameters;
    using TraktNet.Responses;

    internal static class GetSingleShow
    {
        private const string CLIENT_ID = "ENTER_CLIENT_ID_HERE";
        private const string DEFAULT_SHOW_SLUG = "game-of-thrones";

        private static TraktClient _client = null;

        private static async Task Main()
        {
            try
            {
                SetupClient();

                Console.Write("Enter the Trakt-Id or -Slug of the Show: ");
                string showIdOrSlug = Console.ReadLine();

                if (!string.IsNullOrEmpty(showIdOrSlug))
                    await GetShow(showIdOrSlug).ConfigureAwait(false);
                else
                    await GetShow(DEFAULT_SHOW_SLUG).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine("-------------- Exception --------------");
                Console.WriteLine($"Exception message: {ex.Message}");
                Console.WriteLine("---------------------------------------");
            }

            Console.ReadLine();
        }

        private static void SetupClient()
        {
            if (_client == null)
            {
                _client = new TraktClient(CLIENT_ID);

                if (!_client.IsValidForUseWithoutAuthorization)
                    throw new InvalidOperationException("Trakt Client not valid for requests, which do not require OAuth authorization");
            }
        }

        private static async Task GetShow(string showIdOrSlug)
        {
            try
            {
                await GetShowMinimal(showIdOrSlug).ConfigureAwait(false);
                await GetShowFull(showIdOrSlug).ConfigureAwait(false);
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

                if (ex is TraktShowNotFoundException && ex is TraktShowNotFoundException showEx)
                {
                    Console.WriteLine($"Show-Id or -Slug: {showEx.ObjectId}");
                }

                Console.WriteLine("---------------------------------------------");
            }
        }

        private static async Task GetShowMinimal(string showIdOrSlug)
        {
            Console.WriteLine("------------------------- Show Minimal -------------------------");
            TraktResponse<ITraktShow> showResponse = await _client.Shows.GetShowAsync(showIdOrSlug).ConfigureAwait(false);

            if (showResponse)
                WriteShowMinimal(showResponse.Value);

            Console.WriteLine("----------------------------------------------------------------");
        }

        private static async Task GetShowFull(string showIdOrSlug)
        {
            var extendedInfo = new TraktExtendedInfo().SetFull();

            Console.WriteLine("------------------------- Show Full -------------------------");
            TraktResponse<ITraktShow> showResponse = await _client.Shows.GetShowAsync(showIdOrSlug, extendedInfo).ConfigureAwait(false);

            if (showResponse)
                WriteShowFull(showResponse.Value);

            Console.WriteLine("-------------------------------------------------------------");
        }

        private static void WriteShowMinimal(ITraktShow show)
        {
            if (show != null)
            {
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
        }

        private static void WriteShowFull(ITraktShow show)
        {
            WriteShowMinimal(show);

            if (show != null)
            {
                Console.WriteLine($"Overview: {show.Overview}");

                if (show.FirstAired.HasValue)
                    Console.WriteLine($"First Aired (UTC): {show.FirstAired.Value}");

                ITraktShowAirs airs = show.Airs;

                if (airs != null)
                {
                    Console.WriteLine($"Airs on: {airs.Day}");
                    Console.WriteLine($"Airs at: {airs.Time}");
                    Console.WriteLine($"Airs in: {airs.TimeZoneId}");
                }

                Console.WriteLine($"Runtime: {show.Runtime ?? 0} Minutes");

                if (show.Genres != null)
                    Console.WriteLine($"Genres: {string.Join(", ", show.Genres)}");

                Console.WriteLine($"Certification: {show.Certification}");
                Console.WriteLine($"Network: {show.Network}");
                Console.WriteLine($"Aired Episodes: {show.AiredEpisodes ?? 0}");

                if (show.Status != null)
                    Console.WriteLine($"Status: {show.Status.DisplayName}");

                Console.WriteLine($"Rating: {show.Rating ?? 0.0f}");
                Console.WriteLine($"Votes: {show.Votes ?? 0}");
                Console.WriteLine($"Country Code: {show.CountryCode}");
                Console.WriteLine($"Language Code: {show.LanguageCode}");

                if (show.UpdatedAt.HasValue)
                    Console.WriteLine($"Updated At (UTC): {show.UpdatedAt.Value}");

                if (show.AvailableTranslationLanguageCodes != null)
                    Console.WriteLine($"Available Translation Languages: {string.Join(", ", show.AvailableTranslationLanguageCodes)}");

                Console.WriteLine($"Trailer: {show.Trailer}");
                Console.WriteLine($"Homepage: {show.Homepage}");
            }
        }
    }
}
