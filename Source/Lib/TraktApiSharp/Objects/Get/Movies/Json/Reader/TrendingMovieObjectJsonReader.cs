namespace TraktApiSharp.Objects.Get.Movies.Json.Reader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Get.Movies;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TrendingMovieObjectJsonReader : AObjectJsonReader<ITraktTrendingMovie>
    {
        public override async Task<ITraktTrendingMovie> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktTrendingMovie));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieObjectReader = new MovieObjectJsonReader();
                ITraktTrendingMovie traktTrendingMovie = new TraktTrendingMovie();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.TRENDING_MOVIE_PROPERTY_NAME_WATCHERS:
                            traktTrendingMovie.Watchers = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.TRENDING_MOVIE_PROPERTY_NAME_MOVIE:
                            traktTrendingMovie.Movie = await movieObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktTrendingMovie;
            }

            return await Task.FromResult(default(ITraktTrendingMovie));
        }
    }
}
