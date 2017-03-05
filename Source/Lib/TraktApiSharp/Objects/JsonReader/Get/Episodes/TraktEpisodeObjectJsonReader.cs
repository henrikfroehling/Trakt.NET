namespace TraktApiSharp.Objects.JsonReader.Get.Episodes
{
    using Newtonsoft.Json;
    using Objects.Get.Episodes;
    using System;
    using System.Collections.Generic;
    using System.IO;

    internal class TraktEpisodeObjectJsonReader : ITraktObjectJsonReader<TraktEpisode>
    {
        private const string PROPERTY_NAME_SEASON_NUMBER = "season";
        private const string PROPERTY_NAME_NUMBER = "number";
        private const string PROPERTY_NAME_TITLE = "title";
        private const string PROPERTY_NAME_IDS = "ids";
        private const string PROPERTY_NAME_NUMBER_ABSOLUTE = "number_abs";
        private const string PROPERTY_NAME_OVERVIEW = "overview";
        private const string PROPERTY_NAME_RUNTIME = "runtime";
        private const string PROPERTY_NAME_RATING = "rating";
        private const string PROPERTY_NAME_VOTES = "votes";
        private const string PROPERTY_NAME_FIRST_AIRED = "first_aired";
        private const string PROPERTY_NAME_UPDATED_AT = "updated_at";
        private const string PROPERTY_NAME_AVAILABLE_TRANSLATIONS = "available_translations";
        private const string PROPERTY_NAME_TRANSLATIONS = "translations";

        public TraktEpisode ReadObject(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObject(jsonReader);
            }
        }

        public TraktEpisode ReadObject(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
            {
                var idsObjectReader = new TraktEpisodeIdsObjectJsonReader();
                var translationArrayReader = new TraktEpisodeTranslationArrayJsonReader();
                var traktEpisode = new TraktEpisode();

                while (jsonReader.Read() && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_SEASON_NUMBER:
                            traktEpisode.SeasonNumber = jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_NUMBER:
                            traktEpisode.Number = jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_TITLE:
                            traktEpisode.Title = jsonReader.ReadAsString();
                            break;
                        case PROPERTY_NAME_IDS:
                            traktEpisode.Ids = idsObjectReader.ReadObject(jsonReader);
                            break;
                        case PROPERTY_NAME_NUMBER_ABSOLUTE:
                            traktEpisode.NumberAbsolute = jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_OVERVIEW:
                            traktEpisode.Overview = jsonReader.ReadAsString();
                            break;
                        case PROPERTY_NAME_RUNTIME:
                            traktEpisode.Runtime = jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_RATING:
                            traktEpisode.Rating = (float?)jsonReader.ReadAsDouble();
                            break;
                        case PROPERTY_NAME_VOTES:
                            traktEpisode.Votes = jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_FIRST_AIRED:
                            if (jsonReader.Read() && jsonReader.ValueType == typeof(DateTime))
                                traktEpisode.FirstAired = (DateTime)jsonReader.Value;

                            break;
                        case PROPERTY_NAME_UPDATED_AT:
                            if (jsonReader.Read() && jsonReader.ValueType == typeof(DateTime))
                                traktEpisode.UpdatedAt = (DateTime)jsonReader.Value;

                            break;
                        case PROPERTY_NAME_AVAILABLE_TRANSLATIONS:
                            traktEpisode.AvailableTranslationLanguageCodes = ReadStringArray(jsonReader);
                            break;
                        case PROPERTY_NAME_TRANSLATIONS:
                            traktEpisode.Translations = translationArrayReader.ReadArray(jsonReader);
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

                return traktEpisode;
            }

            return null;
        }

        private static IEnumerable<string> ReadStringArray(JsonTextReader reader)
        {
            if (reader.Read() && reader.TokenType == JsonToken.StartArray)
            {
                var values = new List<string>();

                while (reader.Read() && reader.TokenType == JsonToken.String)
                {
                    var value = (string)reader.Value;

                    if (!string.IsNullOrEmpty(value))
                        values.Add(value);
                }

                return values;
            }

            return null;
        }
    }
}
