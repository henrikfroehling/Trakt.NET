namespace TraktApiSharp.Objects.JsonReader.Get.Seasons
{
    using Get.Episodes;
    using Newtonsoft.Json;
    using Objects.Get.Seasons;
    using System.IO;

    internal class TraktSeasonWatchedProgressObjectJsonReader : ITraktObjectJsonReader<TraktSeasonWatchedProgress>
    {
        private const string PROPERTY_NAME_NUMBER = "number";
        private const string PROPERTY_NAME_AIRED = "aired";
        private const string PROPERTY_NAME_COMPLETED = "completed";
        private const string PROPERTY_NAME_EPISODES = "episodes";

        public TraktSeasonWatchedProgress ReadObject(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObject(jsonReader);
            }
        }

        public TraktSeasonWatchedProgress ReadObject(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
            {
                var episodeWatchedProgressArrayReader = new TraktEpisodeWatchedProgressArrayJsonReader();
                var traktSeasonWatchedProgress = new TraktSeasonWatchedProgress();

                while (jsonReader.Read() && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_NUMBER:
                            traktSeasonWatchedProgress.Number = jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_AIRED:
                            traktSeasonWatchedProgress.Aired = jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_COMPLETED:
                            traktSeasonWatchedProgress.Completed = jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_EPISODES:
                            traktSeasonWatchedProgress.Episodes = episodeWatchedProgressArrayReader.ReadArray(jsonReader);
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

                return traktSeasonWatchedProgress;
            }

            return null;
        }
    }
}
