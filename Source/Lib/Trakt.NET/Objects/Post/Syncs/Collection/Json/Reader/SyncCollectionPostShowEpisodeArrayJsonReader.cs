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
                //var syncCollectionPostShowEpisodeReadingTasks = new List<Task<ITraktSyncCollectionPostShowEpisode>>();
                var syncCollectionPostShowEpisodes = new List<ITraktSyncCollectionPostShowEpisode>();

                //syncCollectionPostShowEpisodeReadingTasks.Add(syncCollectionPostShowEpisodeReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktSyncCollectionPostShowEpisode syncCollectionPostShowEpisode = await syncCollectionPostShowEpisodeReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncCollectionPostShowEpisode != null)
                {
                    syncCollectionPostShowEpisodes.Add(syncCollectionPostShowEpisode);
                    //syncCollectionPostShowEpisodeReadingTasks.Add(syncCollectionPostShowEpisodeReader.ReadObjectAsync(jsonReader, cancellationToken));
                    syncCollectionPostShowEpisode = await syncCollectionPostShowEpisodeReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readSyncCollectionPostShowEpisodes = await Task.WhenAll(syncCollectionPostShowEpisodeReadingTasks);
                //return (IEnumerable<ITraktSyncCollectionPostShowEpisode>)readSyncCollectionPostShowEpisodes.GetEnumerator();
                return syncCollectionPostShowEpisodes;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncCollectionPostShowEpisode>));
        }
    }
}
