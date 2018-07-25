namespace TraktNet.Objects.Post.Syncs.Collection.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncCollectionPostShowArrayJsonReader : AArrayJsonReader<ITraktSyncCollectionPostShow>
    {
        public override async Task<IEnumerable<ITraktSyncCollectionPostShow>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncCollectionPostShow>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncCollectionPostShowReader = new SyncCollectionPostShowObjectJsonReader();
                //var syncCollectionPostShowReadingTasks = new List<Task<ITraktSyncCollectionPostShow>>();
                var syncCollectionPostShows = new List<ITraktSyncCollectionPostShow>();

                //syncCollectionPostShowReadingTasks.Add(syncCollectionPostShowReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktSyncCollectionPostShow syncCollectionPostShow = await syncCollectionPostShowReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncCollectionPostShow != null)
                {
                    syncCollectionPostShows.Add(syncCollectionPostShow);
                    //syncCollectionPostShowReadingTasks.Add(syncCollectionPostShowReader.ReadObjectAsync(jsonReader, cancellationToken));
                    syncCollectionPostShow = await syncCollectionPostShowReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readSyncCollectionPostShows = await Task.WhenAll(syncCollectionPostShowReadingTasks);
                //return (IEnumerable<ITraktSyncCollectionPostShow>)readSyncCollectionPostShows.GetEnumerator();
                return syncCollectionPostShows;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncCollectionPostShow>));
        }
    }
}
