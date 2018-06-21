namespace TraktNet.Objects.Post.Syncs.Ratings.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using Syncs.Responses.Json.Reader;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncRatingsPostResponseObjectJsonReader : AObjectJsonReader<ITraktSyncRatingsPostResponse>
    {
        public override async Task<ITraktSyncRatingsPostResponse> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktSyncRatingsPostResponse));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var groupReader = new SyncPostResponseGroupObjectJsonReader();
                var notFoundGroupReader = new SyncRatingsPostResponseNotFoundGroupObjectJsonReader();
                ITraktSyncRatingsPostResponse syncRatingsPostResponse = new TraktSyncRatingsPostResponse();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.SYNC_RATINGS_POST_RESPONSE_PROPERTY_NAME_ADDED:
                            syncRatingsPostResponse.Added = await groupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.SYNC_RATINGS_POST_RESPONSE_PROPERTY_NAME_NOT_FOUND:
                            syncRatingsPostResponse.NotFound = await notFoundGroupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncRatingsPostResponse;
            }

            return await Task.FromResult(default(ITraktSyncRatingsPostResponse));
        }
    }
}
