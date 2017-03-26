namespace TraktApiSharp.Objects.JsonReader.Get.Seasons
{
    using Get.Episodes;
    using Newtonsoft.Json;
    using Objects.Get.Seasons;
    using System.IO;
    using TraktApiSharp.Objects.Get.Seasons.Implementations;

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
