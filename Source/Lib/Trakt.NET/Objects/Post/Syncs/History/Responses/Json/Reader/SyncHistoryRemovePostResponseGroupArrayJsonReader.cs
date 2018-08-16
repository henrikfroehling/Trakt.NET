namespace TraktNet.Objects.Post.Syncs.History.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncHistoryRemovePostResponseGroupArrayJsonReader : AArrayJsonReader<ITraktSyncHistoryRemovePostResponseGroup>
    {
        public override async Task<IEnumerable<ITraktSyncHistoryRemovePostResponseGroup>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncHistoryRemovePostResponseGroup>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncHistoryRemovePostResponseGroupReader = new SyncHistoryRemovePostResponseGroupObjectJsonReader();
                var syncHistoryRemovePostResponseGroups = new List<ITraktSyncHistoryRemovePostResponseGroup>();
                ITraktSyncHistoryRemovePostResponseGroup syncHistoryRemovePostResponseGroup = await syncHistoryRemovePostResponseGroupReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncHistoryRemovePostResponseGroup != null)
                {
                    syncHistoryRemovePostResponseGroups.Add(syncHistoryRemovePostResponseGroup);
                    syncHistoryRemovePostResponseGroup = await syncHistoryRemovePostResponseGroupReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncHistoryRemovePostResponseGroups;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncHistoryRemovePostResponseGroup>));
        }
    }
}
