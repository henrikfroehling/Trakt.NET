namespace TraktApiSharp.Objects.JsonReader.Get.Movies
{
    using Newtonsoft.Json;
    using Objects.Get.Movies;
    using System.IO;
    using TraktApiSharp.Objects.Get.Movies.Implementations;

    internal class TraktMovieAliasObjectJsonReader : ITraktObjectJsonReader<TraktMovieAlias>
    {
        private const string PROPERTY_NAME_TITLE = "title";
        private const string PROPERTY_NAME_COUNTRY = "country";

        public TraktMovieAlias ReadObject(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObject(jsonReader);
            }
        }

        public TraktMovieAlias ReadObject(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
            {
                var traktMovieAlias = new TraktMovieAlias();

                while (jsonReader.Read() && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_TITLE:
                            traktMovieAlias.Title = jsonReader.ReadAsString();
                            break;
                        case PROPERTY_NAME_COUNTRY:
                            traktMovieAlias.CountryCode = jsonReader.ReadAsString();
                            break;
                        default:
                            JsonReaderHelper.OverreadInvalidContent(jsonReader);
                            break;
                    }
                }

                return traktMovieAlias;
            }

            return null;
        }
    }
}
