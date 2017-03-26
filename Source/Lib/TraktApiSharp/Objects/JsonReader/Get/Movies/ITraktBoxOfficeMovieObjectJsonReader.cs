namespace TraktApiSharp.Objects.JsonReader.Get.Movies
{
    using Newtonsoft.Json;
    using Objects.Get.Movies;
    using Objects.Get.Movies.Implementations;
    using System.IO;

    internal class ITraktBoxOfficeMovieObjectJsonReader : ITraktObjectJsonReader<ITraktBoxOfficeMovie>
    {
        private const string PROPERTY_NAME_REVENUE = "revenue";
        private const string PROPERTY_NAME_MOVIE = "movie";

        public ITraktBoxOfficeMovie ReadObject(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObject(jsonReader);
            }
        }

        public ITraktBoxOfficeMovie ReadObject(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieObjectReader = new ITraktMovieObjectJsonReader();
                ITraktBoxOfficeMovie traktBoxOfficeMovie = new TraktBoxOfficeMovie();

                while (jsonReader.Read() && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_REVENUE:
                            traktBoxOfficeMovie.Revenue = jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_MOVIE:
                            traktBoxOfficeMovie.Movie = movieObjectReader.ReadObject(jsonReader);
                            break;
                        default:
                            JsonReaderHelper.OverreadInvalidContent(jsonReader);
                            break;
                    }
                }

                return traktBoxOfficeMovie;
            }

            return null;
        }
    }
}
