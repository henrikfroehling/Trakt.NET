namespace TraktNet.Objects.Post.Syncs.Collection.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncCollectionPostEpisodeArrayJsonReader : AArrayJsonReader<ITraktSyncCollectionPostEpisode>
    {
        public override async Task<IEnumerable<ITraktSyncCollectionPostEpisode>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncCollectionPostEpisode>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncCollectionPostEpisodeReader = new SyncCollectionPostEpisodeObjectJsonReader();
                var syncCollectionPostEpisodes = new List<ITraktSyncCollectionPostEpisode>();
                ITraktSyncCollectionPostEpisode syncCollectionPostEpisode = await syncCollectionPostEpisodeReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncCollectionPostEpisode != null)
                {
                    syncCollectionPostEpisodes.Add(syncCollectionPostEpisode);
                    syncCollectionPostEpisode = await syncCollectionPostEpisodeReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncCollectionPostEpisodes;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncCollectionPostEpisode>));
        }
    }
}
