namespace TraktNet.Objects.Post.Syncs.History.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncHistoryRemovePostArrayJsonReader : ArrayJsonReader<ITraktSyncHistoryRemovePost>
    {
        public override async Task<IEnumerable<ITraktSyncHistoryRemovePost>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncHistoryRemovePost>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncHistoryRemovePostReader = new SyncHistoryRemovePostObjectJsonReader();
                var syncHistoryRemovePosts = new List<ITraktSyncHistoryRemovePost>();
                ITraktSyncHistoryRemovePost syncHistoryRemovePost = await syncHistoryRemovePostReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncHistoryRemovePost != null)
                {
                    syncHistoryRemovePosts.Add(syncHistoryRemovePost);
                    syncHistoryRemovePost = await syncHistoryRemovePostReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncHistoryRemovePosts;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncHistoryRemovePost>));
        }
    }
}
