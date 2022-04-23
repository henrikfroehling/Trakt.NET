namespace TraktNet.Objects.Post.Syncs.Recommendations.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncRecommendationsPostResponseNotFoundGroupObjectJsonReader : AObjectJsonReader<ITraktSyncRecommendationsPostResponseNotFoundGroup>
    {
        public override async Task<ITraktSyncRecommendationsPostResponseNotFoundGroup> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var postResponseMoviesReader = new ArrayJsonReader<ITraktSyncRecommendationsPostMovie>();
                var postResponseShowsReader = new ArrayJsonReader<ITraktSyncRecommendationsPostShow>();
                ITraktSyncRecommendationsPostResponseNotFoundGroup traktSyncRecommendationsPostResponseNotFoundGroup = new TraktSyncRecommendationsPostResponseNotFoundGroup();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_MOVIES:
                            traktSyncRecommendationsPostResponseNotFoundGroup.Movies = await postResponseMoviesReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SHOWS:
                            traktSyncRecommendationsPostResponseNotFoundGroup.Shows = await postResponseShowsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktSyncRecommendationsPostResponseNotFoundGroup;
            }

            return await Task.FromResult(default(ITraktSyncRecommendationsPostResponseNotFoundGroup));
        }
    }
}
