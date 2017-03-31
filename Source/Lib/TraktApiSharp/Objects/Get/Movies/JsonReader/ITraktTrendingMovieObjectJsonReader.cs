namespace TraktApiSharp.Objects.Get.Movies.JsonReader
{
    using Newtonsoft.Json;
    using Objects.Get.Movies;
    using Objects.Get.Movies.Implementations;
    using Objects.JsonReader;
    using System.IO;

    internal class ITraktTrendingMovieObjectJsonReader : ITraktObjectJsonReader<ITraktTrendingMovie>
    {
        private const string PROPERTY_NAME_WATCHERS = "watchers";
        private const string PROPERTY_NAME_MOVIE = "movie";

        public ITraktTrendingMovie ReadObject(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObject(jsonReader);
            }
        }

        public ITraktTrendingMovie ReadObject(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieObjectReader = new ITraktMovieObjectJsonReader();
                ITraktTrendingMovie traktTrendingMovie = new TraktTrendingMovie();

                while (jsonReader.Read() && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_WATCHERS:
                            traktTrendingMovie.Watchers = jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_MOVIE:
                            traktTrendingMovie.Movie = movieObjectReader.ReadObject(jsonReader);
                            break;
                        default:
                            JsonReaderHelper.OverreadInvalidContent(jsonReader);
                            break;
                    }
                }

                return traktTrendingMovie;
            }

            return null;
        }
    }
}
