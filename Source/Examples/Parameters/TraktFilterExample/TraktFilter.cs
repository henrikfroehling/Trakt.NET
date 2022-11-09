using Spectre.Console;
using Trakt.Net.Examples.Utility;
using TraktNet;
using TraktNet.Exceptions;
using TraktNet.Objects.Get.Calendars;
using TraktNet.Parameters;
using TraktNet.Responses;

var client = new TraktClient("ENTER_CLIENT_ID_HERE");

try
{
    if (!client.IsValidForUseWithoutAuthorization)
        throw new InvalidOperationException("Trakt Client not valid for requests, which do not require OAuth authorization");

    Console.WriteLine("------------------------- All New Calendar Shows with Filter -------------------------");

    var table = new Table();
    table.AddColumn(new TableColumn("Title"));
    table.AddColumn(new TableColumn("Overview"));
    table.AddColumn(new TableColumn("Genres"));
    table.AddColumn(new TableColumn("Year"));
    table.AddColumn(new TableColumn("Runtime"));

    ITraktCalendarFilter calendarFilter = TraktFilter.NewCalendarFilter()
                                                .WithGenres("action", "drama")
                                                .WithRuntimes(30, 60)
                                                .WithYear(2022)
                                                .Build();

    TraktListResponse<ITraktCalendarShow> shows = await client.Calendar.GetAllNewShowsAsync(filter: calendarFilter,
                                                                                            extendedInfo: new TraktExtendedInfo { Full = true }).ConfigureAwait(false);

    AddShowsToTable(table, shows);

    AnsiConsole.Write(table);
    Console.WriteLine("-------------------------------------------------------------");
}
catch (TraktException ex)
{
    ExamplesUtility.PrintTraktException(ex);
}
catch (Exception ex)
{
    ExamplesUtility.PrintException(ex);
}

Console.ReadLine();

static void AddShowsToTable(Table table, IEnumerable<ITraktCalendarShow> shows)
{
    foreach (ITraktCalendarShow show in shows)
    {
        string title = show.Title ?? string.Empty;
        string overview = !string.IsNullOrEmpty(show.Overview) ? string.Concat(show.Overview.AsSpan(0, 20), "...") : string.Empty;
        string genres = show.Genres != null && show.Genres.Any() ? string.Join(",", show.Genres) : string.Empty;
        string year = show.Year.HasValue ? $"{show.Year}" : string.Empty;
        string runtime = show.Runtime.HasValue ? $"{show.Runtime} Minutes" : string.Empty;

        _ = table.AddRow(title, overview, genres, year, runtime);
    }
}
