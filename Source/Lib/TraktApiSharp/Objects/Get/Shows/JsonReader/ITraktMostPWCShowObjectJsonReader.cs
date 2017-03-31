namespace TraktApiSharp.Objects.Get.Shows.JsonReader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using Shows;
    using System.IO;

    internal class ITraktMostPWCShowObjectJsonReader : ITraktObjectJsonReader<ITraktMostPWCShow>
    {
        private const string PROPERTY_NAME_WATCHER_COUNT = "watcher_count";
        private const string PROPERTY_NAME_PLAY_COUNT = "play_count";
        private const string PROPERTY_NAME_COLLECTED_COUNT = "collected_count";
        private const string PROPERTY_NAME_COLLECTOR_COUNT = "collector_count";
        private const string PROPERTY_NAME_SHOW = "show";

        public ITraktMostPWCShow ReadObject(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObject(jsonReader);
            }
        }

        public ITraktMostPWCShow ReadObject(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
            {
                var showObjectReader = new ITraktShowObjectJsonReader();
                ITraktMostPWCShow traktMostPWCShow = new TraktMostPWCShow();

                while (jsonReader.Read() && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_WATCHER_COUNT:
                            traktMostPWCShow.WatcherCount = jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_PLAY_COUNT:
                            traktMostPWCShow.PlayCount = jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_COLLECTED_COUNT:
                            traktMostPWCShow.CollectedCount = jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_COLLECTOR_COUNT:
                            traktMostPWCShow.CollectorCount = jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_SHOW:
                            traktMostPWCShow.Show = showObjectReader.ReadObject(jsonReader);
                            break;
                        default:
                            JsonReaderHelper.OverreadInvalidContent(jsonReader);
                            break;
                    }
                }

                return traktMostPWCShow;
            }

            return null;
        }
    }
}
