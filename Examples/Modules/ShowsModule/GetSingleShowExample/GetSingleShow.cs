namespace GetSingleShowExample
{
    using System;
    using System.Threading.Tasks;
    using TraktApiSharp;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Shows.Implementations;
    using TraktApiSharp.Requests.Parameters;

    class GetSingleShow
    {
        private const string CLIENT_ID = "ENTER_CLIENT_ID_HERE";
        private const string DEFAULT_SHOW_SLUG = "game-of-thrones";

        private static TraktClient _client = null;

        static void Main(string[] args)
        {
            try
            {
                SetupClient();

                Console.Write("Enter the Trakt-Id or -Slug of the Show: ");
                string showIdOrSlug = Console.ReadLine();

                if (!string.IsNullOrEmpty(showIdOrSlug))
                    GetShow(showIdOrSlug).Wait();
                else
                    GetShow(DEFAULT_SHOW_SLUG).Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine("-------------- Exception --------------");
                Console.WriteLine($"Exception message: {ex.Message}");
                Console.WriteLine("---------------------------------------");
            }

            Console.ReadLine();
        }

        static void SetupClient()
        {
            if (_client == null)
            {
                _client = new TraktClient(CLIENT_ID);

                if (!_client.IsValidForUseWithoutAuthorization)
                    throw new InvalidOperationException("Trakt Client not valid for requests, which do not require OAuth authorization");
            }
        }

        static async Task GetShow(string showIdOrSlug)
        {
            try
            {
                await GetShowMinimal(showIdOrSlug);
                await GetShowFull(showIdOrSlug);
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

                if (ex is TraktShowNotFoundException)
                {
                    var showEx = ex as TraktShowNotFoundException;

                    if (showEx != null)
                        Console.WriteLine($"Show-Id or -Slug: {showEx.ObjectId}");
                }

                Console.WriteLine("---------------------------------------------");
            }
        }

        static async Task GetShowMinimal(string showIdOrSlug)
        {
            Console.WriteLine("------------------------- Show Minimal -------------------------");
            TraktShow show = await _client.Shows.GetShowAsync(showIdOrSlug);
            WriteShowMinimal(show);
            Console.WriteLine("----------------------------------------------------------------");
        }

        static async Task GetShowFull(string showIdOrSlug)
        {
            var extendedInfo = new TraktExtendedInfo().SetFull();

            Console.WriteLine("------------------------- Show Full -------------------------");
            TraktShow show = await _client.Shows.GetShowAsync(showIdOrSlug, extendedInfo);
            WriteShowFull(show);
            Console.WriteLine("-------------------------------------------------------------");
        }

        static void WriteShowMinimal(TraktShow show)
        {
            if (show != null)
            {
                Console.WriteLine($"Title: {show.Title}");
                Console.WriteLine($"Year: {show.Year ?? 0}");

                TraktShowIds ids = (TraktShowIds)show.Ids; // TODO use interface

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

        static void WriteShowFull(TraktShow show)
        {
            WriteShowMinimal(show);

            if (show != null)
            {
                Console.WriteLine($"Overview: {show.Overview}");

                if (show.FirstAired.HasValue)
                    Console.WriteLine($"First Aired (UTC): {show.FirstAired.Value}");

                TraktShowAirs airs = (TraktShowAirs)show.Airs; // TODO use interface

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
