namespace TraktNet.Objects.Post.Syncs.Ratings.Json.Reader
{
    using Get.Seasons.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Utils;

    internal class SyncRatingsPostSeasonObjectJsonReader : AObjectJsonReader<ITraktSyncRatingsPostSeason>
    {
        public override async Task<ITraktSyncRatingsPostSeason> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var seasonIdsObjectJsonReader = new SeasonIdsObjectJsonReader();
                ITraktSyncRatingsPostSeason syncRatingsPostSeason = new TraktSyncRatingsPostSeason();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_IDS:
                            syncRatingsPostSeason.Ids = await seasonIdsObjectJsonReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_RATING:
                            {
                                Pair<bool, int> value = await JsonReaderHelper.ReadIntegerValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    syncRatingsPostSeason.Rating = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_RATED_AT:
                            {
                                Pair<bool, DateTime> value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    syncRatingsPostSeason.RatedAt = value.Second;

                                break;
                            }
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncRatingsPostSeason;
            }

            return await Task.FromResult(default(ITraktSyncRatingsPostSeason));
        }
    }
}
