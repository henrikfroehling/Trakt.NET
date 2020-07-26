namespace TraktNet.Objects.Post.Syncs.Watchlist.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncWatchlistPostShowSeasonArrayJsonReader : ArrayJsonReader<ITraktSyncWatchlistPostShowSeason>
    {
        public override async Task<IEnumerable<ITraktSyncWatchlistPostShowSeason>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncWatchlistPostShowSeason>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncWatchlistPostShowSeasonReader = new SyncWatchlistPostShowSeasonObjectJsonReader();
                var syncWatchlistPostShowSeasons = new List<ITraktSyncWatchlistPostShowSeason>();
                ITraktSyncWatchlistPostShowSeason syncWatchlistPostShowSeason = await syncWatchlistPostShowSeasonReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncWatchlistPostShowSeason != null)
                {
                    syncWatchlistPostShowSeasons.Add(syncWatchlistPostShowSeason);
                    syncWatchlistPostShowSeason = await syncWatchlistPostShowSeasonReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncWatchlistPostShowSeasons;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncWatchlistPostShowSeason>));
        }
    }
}
