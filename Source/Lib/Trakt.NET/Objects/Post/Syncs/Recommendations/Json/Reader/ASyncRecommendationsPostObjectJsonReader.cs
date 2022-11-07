namespace TraktNet.Objects.Post.Syncs.Recommendations.Json.Reader
{
    using Newtonsoft.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktNet.Objects.Json;

    internal abstract class ASyncRecommendationsPostObjectJsonReader<TSyncRecommendationsPost> : AObjectJsonReader<TSyncRecommendationsPost>
        where TSyncRecommendationsPost : ITraktSyncRecommendationsPost
    {
        public override async Task<TSyncRecommendationsPost> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                TSyncRecommendationsPost syncRecommendationsPost = CreateInstance();
                var syncRecommendationsPostMovieArrayJsonReader = new ArrayJsonReader<ITraktSyncRecommendationsPostMovie>();
                var syncRecommendationsPostShowArrayJsonReader = new ArrayJsonReader<ITraktSyncRecommendationsPostShow>();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_MOVIES:
                            syncRecommendationsPost.Movies = await syncRecommendationsPostMovieArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SHOWS:
                            syncRecommendationsPost.Shows = await syncRecommendationsPostShowArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncRecommendationsPost;
            }

            return await Task.FromResult(default(TSyncRecommendationsPost));
        }

        protected abstract TSyncRecommendationsPost CreateInstance();
    }
}
