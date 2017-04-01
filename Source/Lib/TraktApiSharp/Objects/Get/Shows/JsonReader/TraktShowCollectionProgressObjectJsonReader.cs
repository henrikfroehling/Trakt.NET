namespace TraktApiSharp.Objects.Get.Shows.JsonReader
{
    using Episodes.JsonReader;
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using Seasons.JsonReader;
    using System;
    using System.IO;

    internal class TraktShowCollectionProgressObjectJsonReader : ITraktObjectJsonReader<TraktShowCollectionProgress>
    {
        private const string PROPERTY_NAME_AIRED = "aired";
        private const string PROPERTY_NAME_COMPLETED = "completed";
        private const string PROPERTY_NAME_LAST_COLLECTED_AT = "last_collected_at";
        private const string PROPERTY_NAME_SEASONS = "seasons";
        private const string PROPERTY_NAME_HIDDEN_SEASONS = "hidden_seasons";
        private const string PROPERTY_NAME_NEXT_EPISODE = "next_episode";

        public TraktShowCollectionProgress ReadObject(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObject(jsonReader);
            }
        }

        public TraktShowCollectionProgress ReadObject(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
            {
                var seasonsArrayReader = new TraktSeasonArrayJsonReader();
                var seasonCollectionProgressArrayReader = new TraktSeasonCollectionProgressArrayJsonReader();
                var episodeObjectReader = new TraktEpisodeObjectJsonReader();

                var traktShowCollectionProgress = new TraktShowCollectionProgress();

                while (jsonReader.Read() && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_AIRED:
                            traktShowCollectionProgress.Aired = jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_COMPLETED:
                            traktShowCollectionProgress.Completed = jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_LAST_COLLECTED_AT:
                            DateTime dateTime;
                            if (JsonReaderHelper.ReadDateTimeValue(jsonReader, out dateTime))
                                traktShowCollectionProgress.LastCollectedAt = dateTime;

                            break;
                        case PROPERTY_NAME_SEASONS:
                            traktShowCollectionProgress.Seasons = seasonCollectionProgressArrayReader.ReadArray(jsonReader);
                            break;
                        case PROPERTY_NAME_HIDDEN_SEASONS:
                            traktShowCollectionProgress.HiddenSeasons = seasonsArrayReader.ReadArray(jsonReader);
                            break;
                        case PROPERTY_NAME_NEXT_EPISODE:
                            traktShowCollectionProgress.NextEpisode = episodeObjectReader.ReadObject(jsonReader);
                            break;
                        default:
                            JsonReaderHelper.OverreadInvalidContent(jsonReader);
                            break;
                    }
                }

                return traktShowCollectionProgress;
            }

            return null;
        }
    }
}
