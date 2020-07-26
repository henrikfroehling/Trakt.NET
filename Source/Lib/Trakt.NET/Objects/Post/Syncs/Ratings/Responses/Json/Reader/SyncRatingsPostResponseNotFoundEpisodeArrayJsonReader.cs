namespace TraktNet.Objects.Post.Syncs.Ratings.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncRatingsPostResponseNotFoundEpisodeArrayJsonReader : ArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundEpisode>
    {
        public override async Task<IEnumerable<ITraktSyncRatingsPostResponseNotFoundEpisode>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostResponseNotFoundEpisode>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncRatingsPostResponseNotFoundEpisodeObjectReader = new SyncRatingsPostResponseNotFoundEpisodeObjectJsonReader();
                var syncRatingsPostResponseNotFoundEpisodes = new List<ITraktSyncRatingsPostResponseNotFoundEpisode>();
                ITraktSyncRatingsPostResponseNotFoundEpisode syncRatingsPostResponseNotFoundEpisode = await syncRatingsPostResponseNotFoundEpisodeObjectReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncRatingsPostResponseNotFoundEpisode != null)
                {
                    syncRatingsPostResponseNotFoundEpisodes.Add(syncRatingsPostResponseNotFoundEpisode);
                    syncRatingsPostResponseNotFoundEpisode = await syncRatingsPostResponseNotFoundEpisodeObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncRatingsPostResponseNotFoundEpisodes;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncRatingsPostResponseNotFoundEpisode>));
        }
    }
}
