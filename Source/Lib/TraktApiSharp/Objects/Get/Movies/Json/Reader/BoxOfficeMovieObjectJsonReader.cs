namespace TraktNet.Objects.Get.Movies.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Get.Movies;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class BoxOfficeMovieObjectJsonReader : AObjectJsonReader<ITraktBoxOfficeMovie>
    {
        public override async Task<ITraktBoxOfficeMovie> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktBoxOfficeMovie));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieObjectReader = new MovieObjectJsonReader();
                ITraktBoxOfficeMovie traktBoxOfficeMovie = new TraktBoxOfficeMovie();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.BOX_OFFICE_MOVIE_PROPERTY_NAME_REVENUE:
                            traktBoxOfficeMovie.Revenue = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.BOX_OFFICE_MOVIE_PROPERTY_NAME_MOVIE:
                            traktBoxOfficeMovie.Movie = await movieObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktBoxOfficeMovie;
            }

            return await Task.FromResult(default(ITraktBoxOfficeMovie));
        }
    }
}
