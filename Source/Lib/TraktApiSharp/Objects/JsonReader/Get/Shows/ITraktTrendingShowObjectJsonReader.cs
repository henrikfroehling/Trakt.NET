namespace TraktApiSharp.Objects.JsonReader.Get.Shows
{
    using Newtonsoft.Json;
    using Objects.Get.Shows;
    using System.IO;

    internal class ITraktTrendingShowObjectJsonReader : ITraktObjectJsonReader<ITraktTrendingShow>
    {
        private const string PROPERTY_NAME_WATCHERS = "watchers";
        private const string PROPERTY_NAME_SHOW = "show";

        public ITraktTrendingShow ReadObject(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObject(jsonReader);
            }
        }

        public ITraktTrendingShow ReadObject(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
            {
                var showObjectReader = new ITraktShowObjectJsonReader();
                ITraktTrendingShow traktTrendingShow = new TraktTrendingShow();

                while (jsonReader.Read() && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_WATCHERS:
                            traktTrendingShow.Watchers = jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_SHOW:
                            traktTrendingShow.Show = showObjectReader.ReadObject(jsonReader);
                            break;
                        default:
                            jsonReader.Read(); // read unmatched property value

                            if (jsonReader.TokenType == JsonToken.StartArray)
                            {
                                // step over possible array values for unmatched property
                                while (jsonReader.Read() && jsonReader.TokenType != JsonToken.EndArray)
                                {
                                }
                            }
                            else if (jsonReader.TokenType == JsonToken.StartObject)
                            {
                                // step over possible object values for unmatched property
                                while (jsonReader.Read() && jsonReader.TokenType != JsonToken.EndObject)
                                {
                                }
                            }

                            break;
                    }
                }

                return traktTrendingShow;
            }

            return null;
        }
    }
}
