namespace TraktNet.Objects.Post.Syncs.Ratings.Json.Reader
{
    using Get.Episodes.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Utils;

    internal class SyncRatingsPostEpisodeObjectJsonReader : AObjectJsonReader<ITraktSyncRatingsPostEpisode>
    {
        public override async Task<ITraktSyncRatingsPostEpisode> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var episodeIdsObjectJsonReader = new EpisodeIdsObjectJsonReader();
                ITraktSyncRatingsPostEpisode syncRatingsPostEpisode = new TraktSyncRatingsPostEpisode();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_RATED_AT:
                            {
                                Pair<bool, DateTime> value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    syncRatingsPostEpisode.RatedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_RATING:
                            syncRatingsPostEpisode.Rating = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_IDS:
                            syncRatingsPostEpisode.Ids = await episodeIdsObjectJsonReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncRatingsPostEpisode;
            }

            return await Task.FromResult(default(ITraktSyncRatingsPostEpisode));
        }
    }
}
