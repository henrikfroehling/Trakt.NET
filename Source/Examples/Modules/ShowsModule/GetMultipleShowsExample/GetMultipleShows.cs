﻿using Trakt.Net.Examples.Utility;
using TraktNet;
using TraktNet.Exceptions;
using TraktNet.Modules;
using TraktNet.Objects.Get.Shows;
using TraktNet.Parameters;
using TraktNet.Responses;

const string SHOW_SLUG1 = "game-of-thrones";
const string SHOW_SLUG2 = "mr-robot";
const string SHOW_SLUG3 = "the-flash-2014";

var client = new TraktClient("ENTER_CLIENT_ID_HERE");

try
{
    if (!client.IsValidForUseWithoutAuthorization)
        throw new InvalidOperationException("Trakt Client not valid for requests, which do not require OAuth authorization");

    Console.WriteLine("Enter three Trakt-Ids or -Slugs of Shows.");

    Console.Write("Show 1: ");
    string showIdOrSlug1 = Console.ReadLine();

    Console.Write("Show 2: ");
    string showIdOrSlug2 = Console.ReadLine();

    Console.Write("Show 3: ");
    string showIdOrSlug3 = Console.ReadLine();

    string show1 = string.IsNullOrEmpty(showIdOrSlug1) ? SHOW_SLUG1 : showIdOrSlug1;
    string show2 = string.IsNullOrEmpty(showIdOrSlug2) ? SHOW_SLUG2 : showIdOrSlug2;
    string show3 = string.IsNullOrEmpty(showIdOrSlug3) ? SHOW_SLUG3 : showIdOrSlug3;

    await GetMultipleShowsAsync(show1, show2, show3).ConfigureAwait(false);
}
catch (Exception ex)
{
    ExamplesUtility.PrintException(ex);
}

Console.ReadLine();

async Task GetMultipleShowsAsync(string showIdOrSlug1, string showIdOrSlug2, string showIdOrSlug3)
{
    var parameters = new TraktMultipleObjectsQueryParams
            {
                showIdOrSlug1,
                { showIdOrSlug2, new TraktExtendedInfo { Full = true } },
                { showIdOrSlug3, new TraktExtendedInfo { Full = true } }
            };

    try
    {
        IEnumerable<TraktResponse<ITraktShow>> responses = await client.Shows.GetMultipleShowsAsync(parameters).ConfigureAwait(false);

        if (responses != null)
        {
            foreach (TraktResponse<ITraktShow> response in responses)
            {
                if (response)
                {
                    Console.WriteLine("-------------------------------------------------------------------------");
                    WriteShowFullWithImages(response.Value);
                    Console.WriteLine("-------------------------------------------------------------------------");
                }
            }
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

        if (ex is TraktShowNotFoundException showEx)
        {
            Console.WriteLine($"Show-Id or -Slug: {showEx.ObjectId}");
        }

        Console.WriteLine("---------------------------------------------");
    }
}

void WriteShowFullWithImages(ITraktShow show)
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
