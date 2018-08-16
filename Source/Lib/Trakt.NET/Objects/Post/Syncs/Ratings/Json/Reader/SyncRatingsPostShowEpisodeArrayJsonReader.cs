namespace TraktNet.Objects.Post.Syncs.Ratings.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncRatingsPostShowEpisodeArrayJsonReader : AArrayJsonReader<ITraktSyncRatingsPostShowEpisode>
    {
        public override async Task<IEnumerable<ITraktSyncRatingsPostShowEpisode>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostShowEpisode>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncRatingsPostShowEpisodeReader = new SyncRatingsPostShowEpisodeObjectJsonReader();
                var syncRatingsPostShowEpisodes = new List<ITraktSyncRatingsPostShowEpisode>();
                ITraktSyncRatingsPostShowEpisode syncRatingsPostShowEpisode = await syncRatingsPostShowEpisodeReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncRatingsPostShowEpisode != null)
                {
                    syncRatingsPostShowEpisodes.Add(syncRatingsPostShowEpisode);
                    syncRatingsPostShowEpisode = await syncRatingsPostShowEpisodeReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncRatingsPostShowEpisodes;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostShowEpisode>));
        }
    }
}
