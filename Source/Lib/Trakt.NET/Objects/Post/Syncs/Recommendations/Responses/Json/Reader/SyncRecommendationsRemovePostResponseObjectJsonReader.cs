namespace TraktNet.Objects.Post.Syncs.Recommendations.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using Objects.Post.Responses.Json.Reader;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncRecommendationsRemovePostResponseObjectJsonReader : AObjectJsonReader<ITraktSyncRecommendationsRemovePostResponse>
    {
        public override async Task<ITraktSyncRecommendationsRemovePostResponse> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var groupReader = new SyncRecommendationsPostResponseGroupObjectJsonReader();
                var notFoundGroupReader = new SyncRecommendationsPostResponseNotFoundGroupObjectJsonReader();
                var listDataReader = new PostResponseListDataObjectJsonReader();
                ITraktSyncRecommendationsRemovePostResponse syncRecommendationsRemovePostResponse = new TraktSyncRecommendationsRemovePostResponse();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_DELETED:
                            syncRecommendationsRemovePostResponse.Deleted = await groupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_NOT_FOUND:
                            syncRecommendationsRemovePostResponse.NotFound = await notFoundGroupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_LIST:
                            syncRecommendationsRemovePostResponse.List = await listDataReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncRecommendationsRemovePostResponse;
            }

            return await Task.FromResult(default(ITraktSyncRecommendationsRemovePostResponse));
        }
    }
}
