using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TraktNet;
using TraktNet.Objects.Get.Shows;
using TraktNet.Requests.Parameters;
using TraktNet.Responses;

namespace GetTrendingShows
{
    internal static class GetTrendingShows
    {
        private const string CLIENT_ID = "ENTER_CLIENT_ID_HERE";
        private static TraktClient _client = null;

        private static async Task Main()
        {
            try
            {
                SetupClient();

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
            catch (Exception ex)
            {
                Console.WriteLine("-------------- Exception --------------");
                AnsiConsole.WriteException(ex);
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

        private static async Task<IEnumerable<ITraktTrendingShow>> GetTrendingShowsAsync()
        {
            TraktPagedResponse<ITraktTrendingShow> trendingShowsResponse = await _client.Shows.GetTrendingShowsAsync(new TraktExtendedInfo { Full = true });

            if (trendingShowsResponse)
                return trendingShowsResponse.Value;

            return new List<ITraktTrendingShow>();
        }

        private static void AddShowsToTable(Table table, IEnumerable<ITraktShow> trendingShows)
        {
            int rank = 1;

            foreach (ITraktTrendingShow show in trendingShows)
                _ = table.AddRow($"{rank++}", $"{show.Watchers}", show.Title,
                    string.Concat(show.Overview.AsSpan(0, 20), "..."),
                    show.Network, $"{show.Year}", $"{show.Votes}", $"{show.Rating}");
        }
    }
}
