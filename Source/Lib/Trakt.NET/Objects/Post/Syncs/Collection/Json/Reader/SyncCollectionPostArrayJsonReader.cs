namespace TraktNet.Objects.Post.Syncs.Collection.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncCollectionPostArrayJsonReader : AArrayJsonReader<ITraktSyncCollectionPost>
    {
        public override async Task<IEnumerable<ITraktSyncCollectionPost>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncCollectionPost>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncCollectionPostReader = new SyncCollectionPostObjectJsonReader();
                //var syncCollectionPostReadingTasks = new List<Task<ITraktSyncCollectionPost>>();
                var syncCollectionPosts = new List<ITraktSyncCollectionPost>();

                //syncCollectionPostReadingTasks.Add(syncCollectionPostReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktSyncCollectionPost syncCollectionPost = await syncCollectionPostReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncCollectionPost != null)
                {
                    syncCollectionPosts.Add(syncCollectionPost);
                    //syncCollectionPostReadingTasks.Add(syncCollectionPostReader.ReadObjectAsync(jsonReader, cancellationToken));
                    syncCollectionPost = await syncCollectionPostReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readSyncCollectionPosts = await Task.WhenAll(syncCollectionPostReadingTasks);
                //return (IEnumerable<ITraktSyncCollectionPost>)readSyncCollectionPosts.GetEnumerator();
                return syncCollectionPosts;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncCollectionPost>));
        }
    }
}
