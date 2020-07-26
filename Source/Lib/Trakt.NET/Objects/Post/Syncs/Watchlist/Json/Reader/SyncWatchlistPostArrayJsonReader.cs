namespace TraktNet.Objects.Post.Syncs.Watchlist.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncWatchlistPostArrayJsonReader : ArrayJsonReader<ITraktSyncWatchlistPost>
    {
        public override async Task<IEnumerable<ITraktSyncWatchlistPost>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncWatchlistPost>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncWatchlistPostReader = new SyncWatchlistPostObjectJsonReader();
                var syncWatchlistPosts = new List<ITraktSyncWatchlistPost>();
                ITraktSyncWatchlistPost syncWatchlistPost = await syncWatchlistPostReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncWatchlistPost != null)
                {
                    syncWatchlistPosts.Add(syncWatchlistPost);
                    syncWatchlistPost = await syncWatchlistPostReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncWatchlistPosts;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncWatchlistPost>));
        }
    }
}
