namespace TraktNet.Objects.Post.Syncs.Recommendations.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncRecommendationsPostResponseGroupObjectJsonReader : AObjectJsonReader<ITraktSyncRecommendationsPostResponseGroup>
    {
        public override async Task<ITraktSyncRecommendationsPostResponseGroup> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktSyncRecommendationsPostResponseGroup traktSyncRecommendationsPostResponseGroup = new TraktSyncRecommendationsPostResponseGroup();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_MOVIES:
                            traktSyncRecommendationsPostResponseGroup.Movies = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SHOWS:
                            traktSyncRecommendationsPostResponseGroup.Shows = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktSyncRecommendationsPostResponseGroup;
            }

            return await Task.FromResult(default(ITraktSyncRecommendationsPostResponseGroup));
        }
    }
}
