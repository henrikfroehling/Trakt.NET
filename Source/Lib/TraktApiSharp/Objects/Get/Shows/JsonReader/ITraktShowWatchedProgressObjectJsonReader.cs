namespace TraktApiSharp.Objects.Get.Shows.JsonReader
{
    using Episodes.JsonReader;
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using Seasons.JsonReader;
    using System;
    using System.IO;

    internal class ITraktShowWatchedProgressObjectJsonReader : ITraktObjectJsonReader<ITraktShowWatchedProgress>
    {
        private const string PROPERTY_NAME_AIRED = "aired";
        private const string PROPERTY_NAME_COMPLETED = "completed";
        private const string PROPERTY_NAME_LAST_WATCHED_AT = "last_watched_at";
        private const string PROPERTY_NAME_SEASONS = "seasons";
        private const string PROPERTY_NAME_HIDDEN_SEASONS = "hidden_seasons";
        private const string PROPERTY_NAME_NEXT_EPISODE = "next_episode";

        public ITraktShowWatchedProgress ReadObject(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObject(jsonReader);
            }
        }

        public ITraktShowWatchedProgress ReadObject(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
            {
                var seasonsArrayReader = new ITraktSeasonArrayJsonReader();
                var seasonWatchedProgressArrayReader = new ITraktSeasonWatchedProgressArrayJsonReader();
                var episodeObjectReader = new ITraktEpisodeObjectJsonReader();

                ITraktShowWatchedProgress traktShowWatchedProgress = new TraktShowWatchedProgress();

                while (jsonReader.Read() && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_AIRED:
                            traktShowWatchedProgress.Aired = jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_COMPLETED:
                            traktShowWatchedProgress.Completed = jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_LAST_WATCHED_AT:
                            DateTime dateTime;
                            if (JsonReaderHelper.ReadDateTimeValue(jsonReader, out dateTime))
                                traktShowWatchedProgress.LastWatchedAt = dateTime;

                            break;
                        case PROPERTY_NAME_SEASONS:
                            traktShowWatchedProgress.Seasons = seasonWatchedProgressArrayReader.ReadArray(jsonReader);
                            break;
                        case PROPERTY_NAME_HIDDEN_SEASONS:
                            traktShowWatchedProgress.HiddenSeasons = seasonsArrayReader.ReadArray(jsonReader);
                            break;
                        case PROPERTY_NAME_NEXT_EPISODE:
                            traktShowWatchedProgress.NextEpisode = episodeObjectReader.ReadObject(jsonReader);
                            break;
                        default:
                            JsonReaderHelper.OverreadInvalidContent(jsonReader);
                            break;
                    }
                }

                return traktShowWatchedProgress;
            }

            return null;
        }
    }
}
