namespace TraktApiSharp.Objects.Get.Seasons.JsonReader
{
    using Episodes.JsonReader;
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.IO;

    internal class ITraktSeasonWatchedProgressObjectJsonReader : ITraktObjectJsonReader<ITraktSeasonWatchedProgress>
    {
        private const string PROPERTY_NAME_NUMBER = "number";
        private const string PROPERTY_NAME_AIRED = "aired";
        private const string PROPERTY_NAME_COMPLETED = "completed";
        private const string PROPERTY_NAME_EPISODES = "episodes";

        public ITraktSeasonWatchedProgress ReadObject(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObject(jsonReader);
            }
        }

        public ITraktSeasonWatchedProgress ReadObject(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
            {
                var episodeWatchedProgressArrayReader = new ITraktEpisodeWatchedProgressArrayJsonReader();
                ITraktSeasonWatchedProgress traktSeasonWatchedProgress = new TraktSeasonWatchedProgress();

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
                            JsonReaderHelper.OverreadInvalidContent(jsonReader);
                            break;
                    }
                }

                return traktSeasonWatchedProgress;
            }

            return null;
        }
    }
}
