namespace TraktNet.Objects.Post.Syncs.History.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncHistoryRemovePostResponseNotFoundGroupArrayJsonReader : AArrayJsonReader<ITraktSyncHistoryRemovePostResponseNotFoundGroup>
    {
        public override async Task<IEnumerable<ITraktSyncHistoryRemovePostResponseNotFoundGroup>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncHistoryRemovePostResponseNotFoundGroup>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncHistoryRemovePostResponseNotFoundGroupReader = new SyncHistoryRemovePostResponseNotFoundGroupObjectJsonReader();
                var syncHistoryRemovePostResponseNotFoundGroups = new List<ITraktSyncHistoryRemovePostResponseNotFoundGroup>();
                ITraktSyncHistoryRemovePostResponseNotFoundGroup syncHistoryRemovePostResponseNotFoundGroup = await syncHistoryRemovePostResponseNotFoundGroupReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncHistoryRemovePostResponseNotFoundGroup != null)
                {
                    syncHistoryRemovePostResponseNotFoundGroups.Add(syncHistoryRemovePostResponseNotFoundGroup);
                    syncHistoryRemovePostResponseNotFoundGroup = await syncHistoryRemovePostResponseNotFoundGroupReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncHistoryRemovePostResponseNotFoundGroups;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncHistoryRemovePostResponseNotFoundGroup>));
        }
    }
}
