namespace TraktApiSharp.Objects.Get.Watched.Json.Reader
{
    using Implementations;
    using Movies.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class WatchedMovieObjectJsonReader : AObjectJsonReader<ITraktWatchedMovie>
    {
        public override async Task<ITraktWatchedMovie> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktWatchedMovie));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieObjectReader = new MovieObjectJsonReader();

                ITraktWatchedMovie traktWatchedMovie = new TraktWatchedMovie();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.WATCHED_MOVIE_PROPERTY_NAME_PLAYS:
                            traktWatchedMovie.Plays = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.WATCHED_MOVIE_PROPERTY_NAME_LAST_WATCHED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktWatchedMovie.LastWatchedAt = value.Second;

                                break;
                            }
                        case JsonProperties.WATCHED_MOVIE_PROPERTY_NAME_MOVIE:
                            traktWatchedMovie.Movie = await movieObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktWatchedMovie;
            }

            return await Task.FromResult(default(ITraktWatchedMovie));
        }
    }
}
