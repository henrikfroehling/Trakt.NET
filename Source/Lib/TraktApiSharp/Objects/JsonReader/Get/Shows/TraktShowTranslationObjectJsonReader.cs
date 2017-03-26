namespace TraktApiSharp.Objects.JsonReader.Get.Shows
{
    using Newtonsoft.Json;
    using Objects.Get.Shows.Implementations;
    using System.IO;

    internal class TraktShowTranslationObjectJsonReader : ITraktObjectJsonReader<TraktShowTranslation>
    {
        private const string PROPERTY_NAME_TITLE = "title";
        private const string PROPERTY_NAME_OVERVIEW = "overview";
        private const string PROPERTY_NAME_LANGUAGE_CODE = "language";

        public TraktShowTranslation ReadObject(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObject(jsonReader);
            }
        }

        public TraktShowTranslation ReadObject(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
            {
                var traktShowTranslation = new TraktShowTranslation();

                while (jsonReader.Read() && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_TITLE:
                            traktShowTranslation.Title = jsonReader.ReadAsString();
                            break;
                        case PROPERTY_NAME_OVERVIEW:
                            traktShowTranslation.Overview = jsonReader.ReadAsString();
                            break;
                        case PROPERTY_NAME_LANGUAGE_CODE:
                            traktShowTranslation.LanguageCode = jsonReader.ReadAsString();
                            break;
                        default:
                            JsonReaderHelper.OverreadInvalidContent(jsonReader);
                            break;
                    }
                }

                return traktShowTranslation;
            }

            return null;
        }
    }
}
