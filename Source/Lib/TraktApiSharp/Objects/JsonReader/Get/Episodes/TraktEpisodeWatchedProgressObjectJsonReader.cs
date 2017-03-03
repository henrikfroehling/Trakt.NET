namespace TraktApiSharp.Objects.JsonReader.Get.Episodes
{
    using Newtonsoft.Json;
    using Objects.Get.Episodes;
    using System;
    using System.IO;

    internal class TraktEpisodeWatchedProgressObjectJsonReader : ITraktObjectJsonReader<TraktEpisodeWatchedProgress>
    {
        private const string PROPERTY_NAME_NUMBER = "number";
        private const string PROPERTY_NAME_COMPLETED = "completed";
        private const string PROPERTY_NAME_LAST_WATCHED_AT = "last_watched_at";

        public TraktEpisodeWatchedProgress ReadObject(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObject(jsonReader);
            }
        }

        public TraktEpisodeWatchedProgress ReadObject(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
            {
                var traktEpisodeWatchedProgress = new TraktEpisodeWatchedProgress();

                while (jsonReader.Read() && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_NUMBER:
                            traktEpisodeWatchedProgress.Number = jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_COMPLETED:
                            traktEpisodeWatchedProgress.Completed = jsonReader.ReadAsBoolean();
                            break;
                        case PROPERTY_NAME_LAST_WATCHED_AT:
                            if (jsonReader.Read() && jsonReader.ValueType == typeof(DateTime))
                                traktEpisodeWatchedProgress.LastWatchedAt = (DateTime)jsonReader.Value;

                            break;
                        default:
                            jsonReader.Read(); // read unmatched property value
                            break;
                    }
                }

                return traktEpisodeWatchedProgress;
            }

            return null;
        }
    }
}
