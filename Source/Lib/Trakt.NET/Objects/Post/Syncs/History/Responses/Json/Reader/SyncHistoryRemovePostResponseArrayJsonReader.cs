namespace TraktNet.Objects.Post.Syncs.History.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncHistoryRemovePostResponseArrayJsonReader : AArrayJsonReader<ITraktSyncHistoryRemovePostResponse>
    {
        public override async Task<IEnumerable<ITraktSyncHistoryRemovePostResponse>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncHistoryRemovePostResponse>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncHistoryRemovePostResponseReader = new SyncHistoryRemovePostResponseObjectJsonReader();
                var syncHistoryRemovePostResponses = new List<ITraktSyncHistoryRemovePostResponse>();
                ITraktSyncHistoryRemovePostResponse syncHistoryRemovePostResponse = await syncHistoryRemovePostResponseReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncHistoryRemovePostResponse != null)
                {
                    syncHistoryRemovePostResponses.Add(syncHistoryRemovePostResponse);
                    syncHistoryRemovePostResponse = await syncHistoryRemovePostResponseReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncHistoryRemovePostResponses;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncHistoryRemovePostResponse>));
        }
    }
}
