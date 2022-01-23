namespace TraktNet.Objects.Post.Syncs.Recommendations.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncRecommendationsPostObjectJsonReader : AObjectJsonReader<ITraktSyncRecommendationsPost>
    {
        public override async Task<ITraktSyncRecommendationsPost> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktSyncRecommendationsPost traktSyncRecommendationsPost = new TraktSyncRecommendationsPost();
                var syncRecommendationsPostMovieArrayJsonReader = new ArrayJsonReader<ITraktSyncRecommendationsPostMovie>();
                var syncRecommendationsPostShowArrayJsonReader = new ArrayJsonReader<ITraktSyncRecommendationsPostShow>();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_MOVIES:
                            traktSyncRecommendationsPost.Movies = await syncRecommendationsPostMovieArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SHOWS:
                            traktSyncRecommendationsPost.Shows = await syncRecommendationsPostShowArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktSyncRecommendationsPost;
            }

            return await Task.FromResult(default(ITraktSyncRecommendationsPost));
        }
    }
}
