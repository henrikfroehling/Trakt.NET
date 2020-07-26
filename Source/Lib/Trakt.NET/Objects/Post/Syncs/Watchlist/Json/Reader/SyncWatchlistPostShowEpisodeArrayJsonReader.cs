namespace TraktNet.Objects.Post.Syncs.Watchlist.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncWatchlistPostShowEpisodeArrayJsonReader : ArrayJsonReader<ITraktSyncWatchlistPostShowEpisode>
    {
        public override async Task<IEnumerable<ITraktSyncWatchlistPostShowEpisode>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncWatchlistPostShowEpisode>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncWatchlistPostShowEpisodeReader = new SyncWatchlistPostShowEpisodeObjectJsonReader();
                var syncWatchlistPostShowEpisodes = new List<ITraktSyncWatchlistPostShowEpisode>();
                ITraktSyncWatchlistPostShowEpisode syncWatchlistPostShowEpisode = await syncWatchlistPostShowEpisodeReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncWatchlistPostShowEpisode != null)
                {
                    syncWatchlistPostShowEpisodes.Add(syncWatchlistPostShowEpisode);
                    syncWatchlistPostShowEpisode = await syncWatchlistPostShowEpisodeReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncWatchlistPostShowEpisodes;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncWatchlistPostShowEpisode>));
        }
    }
}
