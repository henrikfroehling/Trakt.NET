namespace TraktNet.Objects.Post.Syncs.Collection.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncCollectionPostShowArrayJsonReader : ArrayJsonReader<ITraktSyncCollectionPostShow>
    {
        public override async Task<IEnumerable<ITraktSyncCollectionPostShow>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncCollectionPostShow>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncCollectionPostShowReader = new SyncCollectionPostShowObjectJsonReader();
                var syncCollectionPostShows = new List<ITraktSyncCollectionPostShow>();
                ITraktSyncCollectionPostShow syncCollectionPostShow = await syncCollectionPostShowReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncCollectionPostShow != null)
                {
                    syncCollectionPostShows.Add(syncCollectionPostShow);
                    syncCollectionPostShow = await syncCollectionPostShowReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncCollectionPostShows;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncCollectionPostShow>));
        }
    }
}
