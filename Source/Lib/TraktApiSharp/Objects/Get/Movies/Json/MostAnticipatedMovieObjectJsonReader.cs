namespace TraktApiSharp.Objects.Get.Movies.Json
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Get.Movies;
    using Objects.Json;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MostAnticipatedMovieObjectJsonReader : IObjectJsonReader<ITraktMostAnticipatedMovie>
    {
        public Task<ITraktMostAnticipatedMovie> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktMostAnticipatedMovie));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktMostAnticipatedMovie> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktMostAnticipatedMovie));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktMostAnticipatedMovie> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
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
