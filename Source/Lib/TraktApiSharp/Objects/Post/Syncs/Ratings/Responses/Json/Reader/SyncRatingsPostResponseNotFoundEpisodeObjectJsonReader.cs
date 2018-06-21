namespace TraktNet.Objects.Post.Syncs.Ratings.Responses.Json.Reader
{
    using Get.Episodes.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncRatingsPostResponseNotFoundEpisodeObjectJsonReader : AObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundEpisode>
    {
        public override async Task<ITraktSyncRatingsPostResponseNotFoundEpisode> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktSyncRatingsPostResponseNotFoundEpisode));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var episodeIdsReader = new EpisodeIdsObjectJsonReader();
                ITraktSyncRatingsPostResponseNotFoundEpisode syncRatingsPostResponseNotFoundEpisode = new TraktSyncRatingsPostResponseNotFoundEpisode();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.SYNC_RATINGS_POST_RESPONSE_NOT_FOUND_EPISODE_PROPERTY_NAME_RATING:
                            syncRatingsPostResponseNotFoundEpisode.Rating = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.SYNC_RATINGS_POST_RESPONSE_NOT_FOUND_EPISODE_PROPERTY_NAME_IDS:
                            syncRatingsPostResponseNotFoundEpisode.Ids = await episodeIdsReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncRatingsPostResponseNotFoundEpisode;
            }

            return await Task.FromResult(default(ITraktSyncRatingsPostResponseNotFoundEpisode));
        }
    }
}
