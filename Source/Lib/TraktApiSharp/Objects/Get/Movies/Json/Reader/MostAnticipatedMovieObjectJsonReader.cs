namespace TraktNet.Objects.Get.Movies.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Get.Movies;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MostAnticipatedMovieObjectJsonReader : AObjectJsonReader<ITraktMostAnticipatedMovie>
    {
        public override async Task<ITraktMostAnticipatedMovie> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktMostAnticipatedMovie));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieObjectReader = new MovieObjectJsonReader();
                ITraktMostAnticipatedMovie traktMostAnticipatedMovie = new TraktMostAnticipatedMovie();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.MOST_ANTICIPATED_MOVIE_PROPERTY_NAME_LIST_COUNT:
                            traktMostAnticipatedMovie.ListCount = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.MOST_ANTICIPATED_MOVIE_PROPERTY_NAME_MOVIE:
                            traktMostAnticipatedMovie.Movie = await movieObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktMostAnticipatedMovie;
            }

            return await Task.FromResult(default(ITraktMostAnticipatedMovie));
        }
    }
}
