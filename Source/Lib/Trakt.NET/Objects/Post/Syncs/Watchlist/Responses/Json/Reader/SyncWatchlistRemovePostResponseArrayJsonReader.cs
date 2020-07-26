namespace TraktNet.Objects.Post.Syncs.Watchlist.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncWatchlistRemovePostResponseArrayJsonReader : ArrayJsonReader<ITraktSyncWatchlistRemovePostResponse>
    {
        public override async Task<IEnumerable<ITraktSyncWatchlistRemovePostResponse>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncWatchlistRemovePostResponse>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncWatchlistRemovePostResponseReader = new SyncWatchlistRemovePostResponseObjectJsonReader();
                var syncWatchlistRemovePostResponses = new List<ITraktSyncWatchlistRemovePostResponse>();
                ITraktSyncWatchlistRemovePostResponse syncWatchlistRemovePostResponse = await syncWatchlistRemovePostResponseReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncWatchlistRemovePostResponse != null)
                {
                    syncWatchlistRemovePostResponses.Add(syncWatchlistRemovePostResponse);
                    syncWatchlistRemovePostResponse = await syncWatchlistRemovePostResponseReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncWatchlistRemovePostResponses;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncWatchlistRemovePostResponse>));
        }
    }
}
