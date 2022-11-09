using Spectre.Console;
using Trakt.Net.Examples.Utility;
using TraktNet;
using TraktNet.Exceptions;
using TraktNet.Objects.Get.Shows;
using TraktNet.Parameters;
using TraktNet.Responses;

var client = new TraktClient("ENTER_CLIENT_ID_HERE");

try
{
    if (!client.IsValidForUseWithoutAuthorization)
        throw new InvalidOperationException("Trakt Client not valid for requests, which do not require OAuth authorization");

    Console.WriteLine("------------------------- Trending Shows -------------------------");

    var table = new Table();
    table.AddColumn(new TableColumn("Rank"));
    table.AddColumn(new TableColumn("Watchers"));
    table.AddColumn(new TableColumn("Title"));
    table.AddColumn(new TableColumn("Overview"));
    table.AddColumn(new TableColumn("Network"));
    table.AddColumn(new TableColumn("Released"));
    table.AddColumn(new TableColumn("Votes"));
    table.AddColumn(new TableColumn("Rating"));

    IEnumerable<ITraktTrendingShow> trendingShows = await GetTrendingShowsAsync();
    AddShowsToTable(table, trendingShows);

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

async Task<IEnumerable<ITraktTrendingShow>> GetTrendingShowsAsync()
{
    TraktPagedResponse<ITraktTrendingShow> trendingShowsResponse = await client.Shows.GetTrendingShowsAsync(new TraktExtendedInfo { Full = true });

    if (trendingShowsResponse)
        return trendingShowsResponse;

    return new List<ITraktTrendingShow>();
}

void AddShowsToTable(Table table, IEnumerable<ITraktTrendingShow> trendingShows)
{
    int rank = 1;

    foreach (ITraktTrendingShow show in trendingShows)
    {
        _ = table.AddRow($"{rank++}", $"{show.Watchers}", show.Title,
            string.Concat(show.Overview.AsSpan(0, 20), "..."),
            show.Network, $"{show.Year}", $"{show.Votes}", $"{show.Rating}");
    }
}
