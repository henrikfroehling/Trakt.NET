namespace TraktApiSharp.Objects.JsonReader.Get.Episodes
{
    using Newtonsoft.Json;
    using Objects.Get.Episodes;
    using System;
    using System.Collections.Generic;
    using System.IO;

    internal class TraktEpisodeCollectionProgressArrayJsonReader : ITraktArrayJsonReader<TraktEpisodeCollectionProgress>
    {
        private const string PROPERTY_NAME_NUMBER = "number";
        private const string PROPERTY_NAME_COMPLETED = "completed";
        private const string PROPERTY_NAME_COLLECTED_AT = "collected_at";

        public IEnumerable<TraktEpisodeCollectionProgress> ReadArray(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArray(jsonReader);
            }
        }

        public IEnumerable<TraktEpisodeCollectionProgress> ReadArray(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartArray)
            {
                var traktEpisodeCollectionProgresses = new List<TraktEpisodeCollectionProgress>();

                while (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
                {
                    var traktEpisodeCollectionProgress = new TraktEpisodeCollectionProgress();

                    while (jsonReader.Read() && jsonReader.TokenType == JsonToken.PropertyName)
                    {
                        var propertyName = jsonReader.Value.ToString();

                        switch (propertyName)
                        {
                            case PROPERTY_NAME_NUMBER:
                                traktEpisodeCollectionProgress.Number = jsonReader.ReadAsInt32();
                                break;
                            case PROPERTY_NAME_COMPLETED:
                                traktEpisodeCollectionProgress.Completed = jsonReader.ReadAsBoolean();
                                break;
                            case PROPERTY_NAME_COLLECTED_AT:
                                if (jsonReader.Read())
                                {
                                    if (jsonReader.ValueType == typeof(DateTime))
                                        traktEpisodeCollectionProgress.CollectedAt = (DateTime)jsonReader.Value;
                                    else if (jsonReader.ValueType == typeof(string))
                                        traktEpisodeCollectionProgress.CollectedAt = DateTime.Parse(jsonReader.Value.ToString());
                                }

                                break;
                            default:
                                jsonReader.Read(); // read unmatched property value
                                break;
                        }
                    }

                    traktEpisodeCollectionProgresses.Add(traktEpisodeCollectionProgress);
                }

                return traktEpisodeCollectionProgresses;
            }

            return null;
        }
    }
}
