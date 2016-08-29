namespace GetSingleShowExample
{
    using System;
    using System.Threading.Tasks;
    using TraktApiSharp;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Requests.Params;

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
                await GetShowFullWithImages(showIdOrSlug);
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
            var extendedOption = new TraktExtendedOption().SetFull();

            Console.WriteLine("------------------------- Show Full -------------------------");
            TraktShow show = await _client.Shows.GetShowAsync(showIdOrSlug, extendedOption);
            WriteShowFull(show);
            Console.WriteLine("-------------------------------------------------------------");
        }

        static async Task GetShowFullWithImages(string showIdOrSlug)
        {
            var extendedOption = new TraktExtendedOption().SetFull().SetImages();

            Console.WriteLine("------------------------- Show Full with Images -------------------------");
            TraktShow show = await _client.Shows.GetShowAsync(showIdOrSlug, extendedOption);
            WriteShowFullWithImages(show);
            Console.WriteLine("-------------------------------------------------------------------------");
        }

        static void WriteShowMinimal(TraktShow show)
        {
            if (show != null)
            {
                Console.WriteLine($"Title: {show.Title}");
                Console.WriteLine($"Year: {show.Year ?? 0}");

                TraktShowIds ids = show.Ids;

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

                TraktShowAirs airs = show.Airs;

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

        static void WriteShowFullWithImages(TraktShow show)
        {
            WriteShowFull(show);

            if (show != null)
            {
                TraktShowImages images = show.Images;

                if (images != null)
                {
                    TraktImageSet fanart = images.FanArt;

                    if (fanart != null)
                    {
                        Console.WriteLine($"Fanart Full: {fanart.Full}");
                        Console.WriteLine($"Fanart Medium: {fanart.Medium}");
                        Console.WriteLine($"Fanart Thumb: {fanart.Thumb}");
                    }

                    TraktImageSet poster = images.Poster;

                    if (poster != null)
                    {
                        Console.WriteLine($"Poster Full: {poster.Full}");
                        Console.WriteLine($"Poster Medium: {poster.Medium}");
                        Console.WriteLine($"Poster Thumb: {poster.Thumb}");
                    }

                    if (images.Banner != null)
                        Console.WriteLine($"Banner: {images.Banner.Full}");

                    if (images.Logo != null)
                        Console.WriteLine($"Logo: {images.Logo.Full}");

                    if (images.ClearArt != null)
                        Console.WriteLine($"Clearart: {images.ClearArt.Full}");

                    if (images.Thumb != null)
                        Console.WriteLine($"Thumb: {images.Thumb.Full}");
                }
            }
        }
    }
}
