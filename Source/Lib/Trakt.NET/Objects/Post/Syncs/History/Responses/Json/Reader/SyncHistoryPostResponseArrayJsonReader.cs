namespace TraktNet.Objects.Post.Syncs.History.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncHistoryPostResponseArrayJsonReader : AArrayJsonReader<ITraktSyncHistoryPostResponse>
    {
        public override async Task<IEnumerable<ITraktSyncHistoryPostResponse>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncHistoryPostResponse>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncHistoryPostResponseReader = new SyncHistoryPostResponseObjectJsonReader();
                var syncHistoryPostResponses = new List<ITraktSyncHistoryPostResponse>();
                ITraktSyncHistoryPostResponse syncHistoryPostResponse = await syncHistoryPostResponseReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncHistoryPostResponse != null)
                {
                    syncHistoryPostResponses.Add(syncHistoryPostResponse);
                    syncHistoryPostResponse = await syncHistoryPostResponseReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncHistoryPostResponses;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncHistoryPostResponse>));
        }
    }
}
