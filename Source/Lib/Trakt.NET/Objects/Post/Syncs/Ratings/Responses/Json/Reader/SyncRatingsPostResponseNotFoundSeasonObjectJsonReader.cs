namespace TraktNet.Objects.Post.Syncs.Ratings.Responses.Json.Reader
{
    using Get.Seasons.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncRatingsPostResponseNotFoundSeasonObjectJsonReader : AObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundSeason>
    {
        public override async Task<ITraktSyncRatingsPostResponseNotFoundSeason> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var seasonIdsReader = new SeasonIdsObjectJsonReader();
                ITraktSyncRatingsPostResponseNotFoundSeason syncRatingsPostResponseNotFoundSeason = new TraktSyncRatingsPostResponseNotFoundSeason();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_RATING:
                            syncRatingsPostResponseNotFoundSeason.Rating = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_IDS:
                            syncRatingsPostResponseNotFoundSeason.Ids = await seasonIdsReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncRatingsPostResponseNotFoundSeason;
            }

            return await Task.FromResult(default(ITraktSyncRatingsPostResponseNotFoundSeason));
        }
    }
}
