namespace TraktApiSharp.Objects.JsonReader.Get.Shows
{
    using Newtonsoft.Json;
    using Objects.Get.Shows;
    using System.IO;

    internal class TraktShowAliasObjectJsonReader : ITraktObjectJsonReader<TraktShowAlias>
    {
        private const string PROPERTY_NAME_TITLE = "title";
        private const string PROPERTY_NAME_COUNTRY = "country";

        public TraktShowAlias ReadObject(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObject(jsonReader);
            }
        }

        public TraktShowAlias ReadObject(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
            {
                var traktShowAlias = new TraktShowAlias();

                while (jsonReader.Read() && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_TITLE:
                            traktShowAlias.Title = jsonReader.ReadAsString();
                            break;
                        case PROPERTY_NAME_COUNTRY:
                            traktShowAlias.CountryCode = jsonReader.ReadAsString();
                            break;
                        default:
                            jsonReader.Read(); // read unmatched property value
                            break;
                    }
                }

                return traktShowAlias;
            }

            return null;
        }
    }
}
