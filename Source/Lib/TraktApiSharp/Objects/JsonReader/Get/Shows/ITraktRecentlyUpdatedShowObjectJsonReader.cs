namespace TraktApiSharp.Objects.JsonReader.Get.Shows
{
    using Newtonsoft.Json;
    using Objects.Get.Shows;
    using Objects.Get.Shows.Implementations;
    using System;
    using System.IO;

    internal class ITraktRecentlyUpdatedShowObjectJsonReader : ITraktObjectJsonReader<ITraktRecentlyUpdatedShow>
    {
        private const string PROPERTY_NAME_UPDATED_AT = "updated_at";
        private const string PROPERTY_NAME_SHOW = "show";

        public ITraktRecentlyUpdatedShow ReadObject(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObject(jsonReader);
            }
        }

        public ITraktRecentlyUpdatedShow ReadObject(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
            {
                var showObjectReader = new ITraktShowObjectJsonReader();
                ITraktRecentlyUpdatedShow traktRecentlyUpdatedShow = new TraktRecentlyUpdatedShow();

                while (jsonReader.Read() && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_UPDATED_AT:
                            DateTime dateTime;
                            if (JsonReaderHelper.ReadDateTimeValue(jsonReader, out dateTime))
                                traktRecentlyUpdatedShow.RecentlyUpdatedAt = dateTime;

                            break;
                        case PROPERTY_NAME_SHOW:
                            traktRecentlyUpdatedShow.Show = showObjectReader.ReadObject(jsonReader);
                            break;
                        default:
                            JsonReaderHelper.OverreadInvalidContent(jsonReader);
                            break;
                    }
                }

                return traktRecentlyUpdatedShow;
            }

            return null;
        }
    }
}
