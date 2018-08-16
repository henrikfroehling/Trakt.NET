namespace TraktNet.Objects.Post.Syncs.Ratings.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncRatingsPostEpisodeArrayJsonReader : AArrayJsonReader<ITraktSyncRatingsPostEpisode>
    {
        public override async Task<IEnumerable<ITraktSyncRatingsPostEpisode>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostEpisode>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncRatingsPostEpisodeReader = new SyncRatingsPostEpisodeObjectJsonReader();
                var syncRatingsPostEpisodes = new List<ITraktSyncRatingsPostEpisode>();
                ITraktSyncRatingsPostEpisode syncRatingsPostEpisode = await syncRatingsPostEpisodeReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncRatingsPostEpisode != null)
                {
                    syncRatingsPostEpisodes.Add(syncRatingsPostEpisode);
                    syncRatingsPostEpisode = await syncRatingsPostEpisodeReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncRatingsPostEpisodes;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostEpisode>));
        }
    }
}
