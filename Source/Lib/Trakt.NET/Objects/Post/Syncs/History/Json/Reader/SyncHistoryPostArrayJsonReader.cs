namespace TraktNet.Objects.Post.Syncs.History.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncHistoryPostArrayJsonReader : ArrayJsonReader<ITraktSyncHistoryPost>
    {
        public override async Task<IEnumerable<ITraktSyncHistoryPost>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncHistoryPost>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncHistoryPostReader = new SyncHistoryPostObjectJsonReader();
                var syncHistoryPosts = new List<ITraktSyncHistoryPost>();
                ITraktSyncHistoryPost syncHistoryPost = await syncHistoryPostReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncHistoryPost != null)
                {
                    syncHistoryPosts.Add(syncHistoryPost);
                    syncHistoryPost = await syncHistoryPostReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncHistoryPosts;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncHistoryPost>));
        }
    }
}
