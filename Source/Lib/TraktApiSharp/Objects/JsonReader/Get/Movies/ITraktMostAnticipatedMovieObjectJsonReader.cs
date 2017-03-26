namespace TraktApiSharp.Objects.JsonReader.Get.Movies
{
    using Newtonsoft.Json;
    using Objects.Get.Movies;
    using Objects.Get.Movies.Implementations;
    using System.IO;

    internal class ITraktMostAnticipatedMovieObjectJsonReader : ITraktObjectJsonReader<ITraktMostAnticipatedMovie>
    {
        private const string PROPERTY_NAME_LIST_COUNT = "list_count";
        private const string PROPERTY_NAME_MOVIE = "movie";

        public ITraktMostAnticipatedMovie ReadObject(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObject(jsonReader);
            }
        }

        public ITraktMostAnticipatedMovie ReadObject(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieObjectReader = new ITraktMovieObjectJsonReader();
                ITraktMostAnticipatedMovie traktMostAnticipatedMovie = new TraktMostAnticipatedMovie();

                while (jsonReader.Read() && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_LIST_COUNT:
                            traktMostAnticipatedMovie.ListCount = jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_MOVIE:
                            traktMostAnticipatedMovie.Movie = movieObjectReader.ReadObject(jsonReader);
                            break;
                        default:
                            JsonReaderHelper.OverreadInvalidContent(jsonReader);
                            break;
                    }
                }

                return traktMostAnticipatedMovie;
            }

            return null;
        }
    }
}
