namespace TraktApiSharp.Objects.JsonReader.Get.Shows
{
    using Episodes;
    using Newtonsoft.Json;
    using Objects.Get.Shows;
    using Seasons;
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
                            if (jsonReader.Read())
                            {
                                if (jsonReader.ValueType == typeof(DateTime))
                                    traktShowCollectionProgress.LastCollectedAt = (DateTime)jsonReader.Value;
                                else if (jsonReader.ValueType == typeof(string))
                                    traktShowCollectionProgress.LastCollectedAt = DateTime.Parse(jsonReader.Value.ToString());
                            }

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
                            jsonReader.Read(); // read unmatched property value

                            if (jsonReader.TokenType == JsonToken.StartArray)
                                OverreadInvalidContent(jsonReader, true);
                            else if (jsonReader.TokenType == JsonToken.StartObject)
                                OverreadInvalidContent(jsonReader, false, true);

                            break;
                    }
                }

                return traktShowCollectionProgress;
            }

            return null;
        }

        private static void OverreadInvalidContent(JsonTextReader jsonReader, bool startWithOpenBracket = false, bool startWithOpenBrace = false)
        {
            var arrayBracketPairCount = startWithOpenBracket ? 1 : 0;
            var objectBracePairCount = startWithOpenBrace ? 1 : 0;
            var steppedOverAllArrays = false;
            var steppedOverAllObjects = false;

            while (true)
            {
                if (steppedOverAllArrays && steppedOverAllObjects)
                    break;

                if (jsonReader.Read())
                {
                    switch (jsonReader.TokenType)
                    {
                        case JsonToken.StartArray:
                            arrayBracketPairCount++;

                            if (arrayBracketPairCount != 0)
                                steppedOverAllArrays = false;

                            break;
                        case JsonToken.EndArray:
                            arrayBracketPairCount--;

                            if (arrayBracketPairCount == 0)
                                steppedOverAllArrays = true;

                            break;
                        case JsonToken.StartObject:
                            objectBracePairCount++;

                            if (objectBracePairCount != 0)
                                steppedOverAllObjects = false;

                            break;
                        case JsonToken.EndObject:
                            objectBracePairCount--;

                            if (objectBracePairCount == 0)
                                steppedOverAllObjects = true;

                            break;
                        default:
                            continue;
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}
