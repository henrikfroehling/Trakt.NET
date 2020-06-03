namespace TraktNet.Objects.Post.Syncs.Collection.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncCollectionPostShowEpisodeArrayJsonReader : AArrayJsonReader<ITraktSyncCollectionPostShowEpisode>
    {
        public override async Task<IEnumerable<ITraktSyncCollectionPostShowEpisode>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncCollectionPostShowEpisode>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncCollectionPostShowEpisodeReader = new SyncCollectionPostShowEpisodeObjectJsonReader();
                var syncCollectionPostShowEpisodes = new List<ITraktSyncCollectionPostShowEpisode>();
                ITraktSyncCollectionPostShowEpisode syncCollectionPostShowEpisode = await syncCollectionPostShowEpisodeReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncCollectionPostShowEpisode != null)
                {
                    syncCollectionPostShowEpisodes.Add(syncCollectionPostShowEpisode);
                    syncCollectionPostShowEpisode = await syncCollectionPostShowEpisodeReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncCollectionPostShowEpisodes;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncCollectionPostShowEpisode>));
        }
    }
}
