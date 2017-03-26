namespace TraktApiSharp.Objects.JsonReader.Get.Shows
{
    using Newtonsoft.Json;
    using Objects.Get.Shows;
    using System.IO;
    using TraktApiSharp.Objects.Get.Shows.Implementations;

    internal class ITraktMostAnticipatedShowObjectJsonReader : ITraktObjectJsonReader<ITraktMostAnticipatedShow>
    {
        private const string PROPERTY_NAME_LIST_COUNT = "list_count";
        private const string PROPERTY_NAME_SHOW = "show";

        public ITraktMostAnticipatedShow ReadObject(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObject(jsonReader);
            }
        }

        public ITraktMostAnticipatedShow ReadObject(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
            {
                var showObjectReader = new ITraktShowObjectJsonReader();
                ITraktMostAnticipatedShow traktMostAnticipatedShow = new TraktMostAnticipatedShow();

                while (jsonReader.Read() && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_LIST_COUNT:
                            traktMostAnticipatedShow.ListCount = jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_SHOW:
                            traktMostAnticipatedShow.Show = showObjectReader.ReadObject(jsonReader);
                            break;
                        default:
                            JsonReaderHelper.OverreadInvalidContent(jsonReader);
                            break;
                    }
                }

                return traktMostAnticipatedShow;
            }

            return null;
        }
    }
}
