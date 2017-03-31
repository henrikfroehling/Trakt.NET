namespace TraktApiSharp.Objects.Get.Movies.JsonReader
{
    using Newtonsoft.Json;
    using Objects.Get.Movies;
    using Objects.Get.Movies.Implementations;
    using Objects.JsonReader;
    using System.IO;

    internal class ITraktMostPWCMovieObjectJsonReader : ITraktObjectJsonReader<ITraktMostPWCMovie>
    {
        private const string PROPERTY_NAME_WATCHER_COUNT = "watcher_count";
        private const string PROPERTY_NAME_PLAY_COUNT = "play_count";
        private const string PROPERTY_NAME_COLLECTED_COUNT = "collected_count";
        private const string PROPERTY_NAME_MOVIE = "movie";

        public ITraktMostPWCMovie ReadObject(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObject(jsonReader);
            }
        }

        public ITraktMostPWCMovie ReadObject(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieObjectReader = new ITraktMovieObjectJsonReader();
                ITraktMostPWCMovie traktMostPWCMovie = new TraktMostPWCMovie();

                while (jsonReader.Read() && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_WATCHER_COUNT:
                            traktMostPWCMovie.WatcherCount = jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_PLAY_COUNT:
                            traktMostPWCMovie.PlayCount = jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_COLLECTED_COUNT:
                            traktMostPWCMovie.CollectedCount = jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_MOVIE:
                            traktMostPWCMovie.Movie = movieObjectReader.ReadObject(jsonReader);
                            break;
                        default:
                            JsonReaderHelper.OverreadInvalidContent(jsonReader);
                            break;
                    }
                }

                return traktMostPWCMovie;
            }

            return null;
        }
    }
}
