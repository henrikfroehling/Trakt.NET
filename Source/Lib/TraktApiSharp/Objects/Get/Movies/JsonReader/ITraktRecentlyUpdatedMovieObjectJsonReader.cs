namespace TraktApiSharp.Objects.Get.Movies.JsonReader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Get.Movies;
    using Objects.JsonReader;
    using System;
    using System.IO;

    internal class ITraktRecentlyUpdatedMovieObjectJsonReader : ITraktObjectJsonReader<ITraktRecentlyUpdatedMovie>
    {
        private const string PROPERTY_NAME_UPDATED_AT = "updated_at";
        private const string PROPERTY_NAME_MOVIE = "movie";

        public ITraktRecentlyUpdatedMovie ReadObject(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObject(jsonReader);
            }
        }

        public ITraktRecentlyUpdatedMovie ReadObject(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieObjectReader = new ITraktMovieObjectJsonReader();
                ITraktRecentlyUpdatedMovie traktRecentlyUpdatedMovie = new TraktRecentlyUpdatedMovie();

                while (jsonReader.Read() && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_UPDATED_AT:
                            DateTime dateTime;
                            if (JsonReaderHelper.ReadDateTimeValue(jsonReader, out dateTime))
                                traktRecentlyUpdatedMovie.RecentlyUpdatedAt = dateTime;

                            break;
                        case PROPERTY_NAME_MOVIE:
                            traktRecentlyUpdatedMovie.Movie = movieObjectReader.ReadObject(jsonReader);
                            break;
                        default:
                            JsonReaderHelper.OverreadInvalidContent(jsonReader);
                            break;
                    }
                }

                return traktRecentlyUpdatedMovie;
            }

            return null;
        }
    }
}
