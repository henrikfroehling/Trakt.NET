namespace TraktApiSharp.Objects.JsonReader.Get.Shows
{
    using Newtonsoft.Json;
    using Objects.Get.Shows;
    using System.IO;

    internal class TraktShowAirsObjectJsonReader : ITraktObjectJsonReader<TraktShowAirs>
    {
        private const string PROPERTY_NAME_DAY = "day";
        private const string PROPERTY_NAME_TIME = "time";
        private const string PROPERTY_NAME_TIMEZONE = "timezone";

        public TraktShowAirs ReadObject(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObject(jsonReader);
            }
        }

        public TraktShowAirs ReadObject(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
            {
                var traktShowAirs = new TraktShowAirs();

                while (jsonReader.Read() && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_DAY:
                            traktShowAirs.Day = jsonReader.ReadAsString();
                            break;
                        case PROPERTY_NAME_TIME:
                            traktShowAirs.Time = jsonReader.ReadAsString();
                            break;
                        case PROPERTY_NAME_TIMEZONE:
                            traktShowAirs.TimeZoneId = jsonReader.ReadAsString();
                            break;
                        default:
                            jsonReader.Read(); // read unmatched property value
                            break;
                    }
                }

                return traktShowAirs;
            }

            return null;
        }
    }
}
