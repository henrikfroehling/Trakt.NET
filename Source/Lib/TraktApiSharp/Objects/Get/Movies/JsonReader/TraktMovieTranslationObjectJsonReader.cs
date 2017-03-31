namespace TraktApiSharp.Objects.Get.Movies.JsonReader
{
    using Newtonsoft.Json;
    using Objects.Get.Movies.Implementations;
    using Objects.JsonReader;
    using System.IO;

    internal class TraktMovieTranslationObjectJsonReader : ITraktObjectJsonReader<TraktMovieTranslation>
    {
        private const string PROPERTY_NAME_TITLE = "title";
        private const string PROPERTY_NAME_OVERVIEW = "overview";
        private const string PROPERTY_NAME_LANGUAGE_CODE = "language";
        private const string PROPERTY_NAME_TAGLINE = "tagline";

        public TraktMovieTranslation ReadObject(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObject(jsonReader);
            }
        }

        public TraktMovieTranslation ReadObject(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
            {
                var traktMovieTranslation = new TraktMovieTranslation();

                while (jsonReader.Read() && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_TITLE:
                            traktMovieTranslation.Title = jsonReader.ReadAsString();
                            break;
                        case PROPERTY_NAME_OVERVIEW:
                            traktMovieTranslation.Overview = jsonReader.ReadAsString();
                            break;
                        case PROPERTY_NAME_LANGUAGE_CODE:
                            traktMovieTranslation.LanguageCode = jsonReader.ReadAsString();
                            break;
                        case PROPERTY_NAME_TAGLINE:
                            traktMovieTranslation.Tagline = jsonReader.ReadAsString();
                            break;
                        default:
                            JsonReaderHelper.OverreadInvalidContent(jsonReader);
                            break;
                    }
                }

                return traktMovieTranslation;
            }

            return null;
        }
    }
}
