using TraktNet;
using TraktNet.Exceptions;
using TraktNet.Objects.Get.Calendars;
using TraktNet.Parameters;
using TraktNet.Responses;

Console.WriteLine("Please enter your Trakt Client-ID:");
string clientID = Console.ReadLine();

var client = new TraktClient(clientID);

ITraktCalendarFilter calendarFilter = TraktFilter.NewCalendarFilter()
                                            .WithGenres("action", "drama") // We want only "Action" and "Drama" shows.
                                                                           // Note: These should be official Trakt genre slugs.
                                            .WithRuntimes(30, 60)          // Shows with a runtime between 30 and 60 minutes.
                                            .WithYear(2022)                // Shows which were released in the year 2022.
                                                                           // Also possible:
                                                                           //.WithCountries("de", "us")
                                                                           //.WithLanguages("en", "de")
                                                                           //.WithRatings(70, 90)
                                                                           //.WithQuery("game")
                                                                           //.WithStudios("HBO", "Showtine")
                                                                           //.WithVotes(7000, 9000)
                                            .Build();                      // Finally, create the filter with the above given parameters.

try {
    TraktListResponse<ITraktCalendarShow> calendarShowsResponse = await client.Calendar.GetAllNewShowsAsync(
        filter: calendarFilter,                                 // The above created calendar filter.
        extendedInfo: new TraktExtendedInfo { Full = true }     // We like to get full information about the shows.
    );

    ITraktCalendarShow calendarShow = calendarShowsResponse.Value.First();

    Console.WriteLine($"Title: {calendarShow.Title}");
    Console.WriteLine($"Year: {calendarShow.Year}");
    Console.WriteLine($"Rating: {calendarShow.Rating}");
    Console.WriteLine($"First Aired: {calendarShow.FirstAiredInCalendar}");
} catch (TraktException ex) {
    Console.WriteLine("-------------- Trakt Exception --------------");
    Console.WriteLine($"Exception message: {ex.Message}");
    Console.WriteLine($"Status code: {ex.StatusCode}");
    Console.WriteLine($"Request URL: {ex.RequestUrl}");
    Console.WriteLine($"Request message: {ex.RequestBody}");
    Console.WriteLine($"Request response: {ex.Response}");
    Console.WriteLine($"Server Reason Phrase: {ex.ServerReasonPhrase}");
    Console.WriteLine("---------------------------------------------");
}
