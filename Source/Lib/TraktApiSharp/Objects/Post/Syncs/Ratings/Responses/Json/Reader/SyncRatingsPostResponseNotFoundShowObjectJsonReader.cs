namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.Json.Reader
{
    using Get.Shows.Json.Reader;
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncRatingsPostResponseNotFoundShowObjectJsonReader : AObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundShow>
    {
        public override async Task<ITraktSyncRatingsPostResponseNotFoundShow> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktSyncRatingsPostResponseNotFoundShow));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var showIdsReader = new ShowIdsObjectJsonReader();
                ITraktSyncRatingsPostResponseNotFoundShow syncRatingsPostResponseNotFoundShow = new TraktSyncRatingsPostResponseNotFoundShow();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.SYNC_RATINGS_POST_RESPONSE_NOT_FOUND_SHOW_PROPERTY_NAME_RATING:
                            syncRatingsPostResponseNotFoundShow.Rating = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.SYNC_RATINGS_POST_RESPONSE_NOT_FOUND_SHOW_PROPERTY_NAME_IDS:
                            syncRatingsPostResponseNotFoundShow.Ids = await showIdsReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncRatingsPostResponseNotFoundShow;
            }

            return await Task.FromResult(default(ITraktSyncRatingsPostResponseNotFoundShow));
        }
    }
}
