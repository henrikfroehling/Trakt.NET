namespace TraktNet.Objects.Post.Syncs.Recommendations.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncRecommendationsPostResponseObjectJsonReader : AObjectJsonReader<ITraktSyncRecommendationsPostResponse>
    {
        public override async Task<ITraktSyncRecommendationsPostResponse> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var groupReader = new SyncRecommendationsPostResponseGroupObjectJsonReader();
                var notFoundGroupReader = new SyncRecommendationsPostResponseNotFoundGroupObjectJsonReader();
                ITraktSyncRecommendationsPostResponse syncRecommendationsPostResponse = new TraktSyncRecommendationsPostResponse();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_ADDED:
                            syncRecommendationsPostResponse.Added = await groupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_EXISTING:
                            syncRecommendationsPostResponse.Existing = await groupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_NOT_FOUND:
                            syncRecommendationsPostResponse.NotFound = await notFoundGroupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncRecommendationsPostResponse;
            }

            return await Task.FromResult(default(ITraktSyncRecommendationsPostResponse));
        }
    }
}
