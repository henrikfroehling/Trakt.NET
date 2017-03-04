namespace TraktApiSharp.Objects.JsonReader.Get.Episodes
{
    using Newtonsoft.Json;
    using Objects.Get.Episodes;
    using System.Collections.Generic;
    using System.IO;

    internal class TraktEpisodeTranslationArrayJsonReader : ITraktArrayJsonReader<TraktEpisodeTranslation>
    {
        private const string PROPERTY_NAME_TITLE = "title";
        private const string PROPERTY_NAME_OVERVIEW = "overview";
        private const string PROPERTY_NAME_LANGUAGE_CODE = "language";

        public IEnumerable<TraktEpisodeTranslation> ReadArray(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArray(jsonReader);
            }
        }

        public IEnumerable<TraktEpisodeTranslation> ReadArray(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartArray)
            {
                var traktEpisodeTranslations = new List<TraktEpisodeTranslation>();

                while (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
                {
                    var traktEpisodeTranslation = new TraktEpisodeTranslation();

                    while (jsonReader.Read() && jsonReader.TokenType == JsonToken.PropertyName)
                    {
                        var propertyName = jsonReader.Value.ToString();

                        switch (propertyName)
                        {
                            case PROPERTY_NAME_TITLE:
                                traktEpisodeTranslation.Title = jsonReader.ReadAsString();
                                break;
                            case PROPERTY_NAME_OVERVIEW:
                                traktEpisodeTranslation.Overview = jsonReader.ReadAsString();
                                break;
                            case PROPERTY_NAME_LANGUAGE_CODE:
                                traktEpisodeTranslation.LanguageCode = jsonReader.ReadAsString();
                                break;
                            default:
                                jsonReader.Read(); // read unmatched property value
                                break;
                        }
                    }

                    traktEpisodeTranslations.Add(traktEpisodeTranslation);
                }

                return traktEpisodeTranslations;
            }

            return null;
        }
    }
}
