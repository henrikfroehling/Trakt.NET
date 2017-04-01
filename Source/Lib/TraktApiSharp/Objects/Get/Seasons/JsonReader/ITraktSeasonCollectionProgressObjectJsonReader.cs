namespace TraktApiSharp.Objects.Get.Seasons.JsonReader
{
    using Episodes.JsonReader;
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.IO;

    internal class ITraktSeasonCollectionProgressObjectJsonReader : ITraktObjectJsonReader<ITraktSeasonCollectionProgress>
    {
        private const string PROPERTY_NAME_NUMBER = "number";
        private const string PROPERTY_NAME_AIRED = "aired";
        private const string PROPERTY_NAME_COMPLETED = "completed";
        private const string PROPERTY_NAME_EPISODES = "episodes";

        public ITraktSeasonCollectionProgress ReadObject(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObject(jsonReader);
            }
        }

        public ITraktSeasonCollectionProgress ReadObject(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
            {
                var episodeCollectionProgressArrayReader = new ITraktEpisodeCollectionProgressArrayJsonReader();
                ITraktSeasonCollectionProgress traktSeasonCollectionProgress = new TraktSeasonCollectionProgress();

                while (jsonReader.Read() && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_NUMBER:
                            traktSeasonCollectionProgress.Number = jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_AIRED:
                            traktSeasonCollectionProgress.Aired = jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_COMPLETED:
                            traktSeasonCollectionProgress.Completed = jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_EPISODES:
                            traktSeasonCollectionProgress.Episodes = episodeCollectionProgressArrayReader.ReadArray(jsonReader);
                            break;
                        default:
                            JsonReaderHelper.OverreadInvalidContent(jsonReader);
                            break;
                    }
                }

                return traktSeasonCollectionProgress;
            }

            return null;
        }
    }
}
