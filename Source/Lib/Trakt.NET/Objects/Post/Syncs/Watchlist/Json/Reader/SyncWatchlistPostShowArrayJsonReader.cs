namespace TraktNet.Objects.Post.Syncs.Watchlist.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncWatchlistPostShowArrayJsonReader : AArrayJsonReader<ITraktSyncWatchlistPostShow>
    {
        public override async Task<IEnumerable<ITraktSyncWatchlistPostShow>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncWatchlistPostShow>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncWatchlistPostShowReader = new SyncWatchlistPostShowObjectJsonReader();
                var syncWatchlistPostShows = new List<ITraktSyncWatchlistPostShow>();
                ITraktSyncWatchlistPostShow syncWatchlistPostShow = await syncWatchlistPostShowReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncWatchlistPostShow != null)
                {
                    syncWatchlistPostShows.Add(syncWatchlistPostShow);
                    syncWatchlistPostShow = await syncWatchlistPostShowReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncWatchlistPostShows;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncWatchlistPostShow>));
        }
    }
}
