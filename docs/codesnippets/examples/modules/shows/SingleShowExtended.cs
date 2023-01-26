using TraktNet.Parameters;

try
{
    TraktResponse<ITraktShow> showResponse = await client.Shows.GetShowAsync(showIdOrSlug, new TraktExtendedInfo().SetFull());
    
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