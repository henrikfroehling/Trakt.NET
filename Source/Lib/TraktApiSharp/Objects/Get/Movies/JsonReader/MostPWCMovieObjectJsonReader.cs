namespace TraktApiSharp.Objects.Get.Movies.JsonReader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Get.Movies;
    using Objects.JsonReader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MostPWCMovieObjectJsonReader : IObjectJsonReader<ITraktMostPWCMovie>
    {
        private const string PROPERTY_NAME_WATCHER_COUNT = "watcher_count";
        private const string PROPERTY_NAME_PLAY_COUNT = "play_count";
        private const string PROPERTY_NAME_COLLECTED_COUNT = "collected_count";
        private const string PROPERTY_NAME_MOVIE = "movie";

        public Task<ITraktMostPWCMovie> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktMostPWCMovie));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktMostPWCMovie> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktMostPWCMovie));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktMostPWCMovie> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktMostPWCMovie));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieObjectReader = new TraktMovieObjectJsonReader();
                ITraktMostPWCMovie traktMostPWCMovie = new TraktMostPWCMovie();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_WATCHER_COUNT:
                            traktMostPWCMovie.WatcherCount = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case PROPERTY_NAME_PLAY_COUNT:
                            traktMostPWCMovie.PlayCount = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case PROPERTY_NAME_COLLECTED_COUNT:
                            traktMostPWCMovie.CollectedCount = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case PROPERTY_NAME_MOVIE:
                            traktMostPWCMovie.Movie = await movieObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktMostPWCMovie;
            }

            return await Task.FromResult(default(ITraktMostPWCMovie));
        }
    }
}
