namespace TraktNet.Objects.Post.Syncs.Watchlist.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncWatchlistPostEpisodeArrayJsonReader : ArrayJsonReader<ITraktSyncWatchlistPostEpisode>
    {
        public override async Task<IEnumerable<ITraktSyncWatchlistPostEpisode>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncWatchlistPostEpisode>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncWatchlistPostEpisodeReader = new SyncWatchlistPostEpisodeObjectJsonReader();
                var syncWatchlistPostEpisodes = new List<ITraktSyncWatchlistPostEpisode>();
                ITraktSyncWatchlistPostEpisode syncWatchlistPostEpisode = await syncWatchlistPostEpisodeReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncWatchlistPostEpisode != null)
                {
                    syncWatchlistPostEpisodes.Add(syncWatchlistPostEpisode);
                    syncWatchlistPostEpisode = await syncWatchlistPostEpisodeReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncWatchlistPostEpisodes;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncWatchlistPostEpisode>));
        }
    }
}
