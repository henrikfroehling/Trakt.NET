namespace TraktNet.Objects.Post.Syncs.Watchlist.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncWatchlistPostResponseArrayJsonReader : ArrayJsonReader<ITraktSyncWatchlistPostResponse>
    {
        public override async Task<IEnumerable<ITraktSyncWatchlistPostResponse>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncWatchlistPostResponse>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncWatchlistPostResponseReader = new SyncWatchlistPostResponseObjectJsonReader();
                var syncWatchlistPostResponses = new List<ITraktSyncWatchlistPostResponse>();
                ITraktSyncWatchlistPostResponse syncWatchlistPostResponse = await syncWatchlistPostResponseReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncWatchlistPostResponse != null)
                {
                    syncWatchlistPostResponses.Add(syncWatchlistPostResponse);
                    syncWatchlistPostResponse = await syncWatchlistPostResponseReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncWatchlistPostResponses;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncWatchlistPostResponse>));
        }
    }
}
