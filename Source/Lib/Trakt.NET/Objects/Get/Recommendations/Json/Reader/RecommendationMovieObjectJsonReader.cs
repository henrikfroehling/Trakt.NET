namespace TraktNet.Objects.Get.Recommendations.Json.Reader
{
    using Movies.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RecommendationMovieObjectJsonReader : ARecommendationObjectJsonReader<ITraktRecommendationMovie>
    {
        public override async Task<ITraktRecommendationMovie> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken).ConfigureAwait(false) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieObjectReader = new MovieObjectJsonReader();
                ITraktRecommendationMovie traktRecommendationMovie = new TraktRecommendationMovie();

                while (await jsonReader.ReadAsync(cancellationToken).ConfigureAwait(false) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_MOVIE:
                            traktRecommendationMovie.Movie = await movieObjectReader.ReadObjectAsync(jsonReader, cancellationToken).ConfigureAwait(false);
                            break;
                        default:
                            await ReadAsync(jsonReader, traktRecommendationMovie, propertyName, cancellationToken).ConfigureAwait(false);
                            break;
                    }
                }

                return traktRecommendationMovie;
            }

            return await Task.FromResult(default(ITraktRecommendationMovie));
        }
    }
}
