namespace TraktApiSharp.Objects.JsonReader.Basic
{
    using Newtonsoft.Json;
    using Objects.Basic;
    using System.IO;
    using TraktApiSharp.Objects.Basic.Implementations;

    internal class TraktStatisticsObjectJsonReader : ITraktObjectJsonReader<TraktStatistics>
    {
        private const string PROPERTY_NAME_WATCHERS = "watchers";
        private const string PROPERTY_NAME_PLAYS = "plays";
        private const string PROPERTY_NAME_COLLECTORS = "collectors";
        private const string PROPERTY_NAME_COLLECTED_EPISODES = "collected_episodes";
        private const string PROPERTY_NAME_COMMENTS = "comments";
        private const string PROPERTY_NAME_LISTS = "lists";
        private const string PROPERTY_NAME_VOTES = "votes";

        public TraktStatistics ReadObject(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObject(jsonReader);
            }
        }

        public TraktStatistics ReadObject(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
            {
                var traktStatistics = new TraktStatistics();

                while (jsonReader.Read() && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_WATCHERS:
                            traktStatistics.Watchers = jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_PLAYS:
                            traktStatistics.Plays = jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_COLLECTORS:
                            traktStatistics.Collectors = jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_COLLECTED_EPISODES:
                            traktStatistics.CollectedEpisodes = jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_COMMENTS:
                            traktStatistics.Comments = jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_LISTS:
                            traktStatistics.Lists = jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_VOTES:
                            traktStatistics.Votes = jsonReader.ReadAsInt32();
                            break;
                        default:
                            JsonReaderHelper.OverreadInvalidContent(jsonReader);
                            break;
                    }
                }

                return traktStatistics;
            }

            return null;
        }
    }
}
