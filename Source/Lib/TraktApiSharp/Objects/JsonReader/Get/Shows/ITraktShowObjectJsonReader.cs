namespace TraktApiSharp.Objects.JsonReader.Get.Shows
{
    using Enums;
    using Newtonsoft.Json;
    using Objects.Get.Shows;
    using Seasons;
    using System;
    using System.Collections.Generic;
    using System.IO;

    internal class ITraktShowObjectJsonReader : ITraktObjectJsonReader<ITraktShow>
    {
        private const string PROPERTY_NAME_TITLE = "title";
        private const string PROPERTY_NAME_YEAR = "year";
        private const string PROPERTY_NAME_IDS = "ids";
        private const string PROPERTY_NAME_OVERVIEW = "overview";
        private const string PROPERTY_NAME_FIRST_AIRED = "first_aired";
        private const string PROPERTY_NAME_AIRS = "airs";
        private const string PROPERTY_NAME_RUNTIME = "runtime";
        private const string PROPERTY_NAME_CERTIFICATION = "certification";
        private const string PROPERTY_NAME_NETWORK = "network";
        private const string PROPERTY_NAME_COUNTRY = "country";
        private const string PROPERTY_NAME_TRAILER = "trailer";
        private const string PROPERTY_NAME_HOMEPAGE = "homepage";
        private const string PROPERTY_NAME_STATUS = "status";
        private const string PROPERTY_NAME_RATING = "rating";
        private const string PROPERTY_NAME_VOTES = "votes";
        private const string PROPERTY_NAME_UPDATED_AT = "updated_at";
        private const string PROPERTY_NAME_LANGUAGE = "language";
        private const string PROPERTY_NAME_AVAILABLE_TRANSLATIONS = "available_translations";
        private const string PROPERTY_NAME_GENRES = "genres";
        private const string PROPERTY_NAME_AIRED_EPISODES = "aired_episodes";
        private const string PROPERTY_NAME_SEASONS = "seasons";

        public ITraktShow ReadObject(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObject(jsonReader);
            }
        }

        public ITraktShow ReadObject(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
            {
                var idsObjectReader = new TraktShowIdsObjectJsonReader();
                var airsObjectReader = new TraktShowAirsObjectJsonReader();
                var seasonsArrayReader = new TraktSeasonArrayJsonReader();

                ITraktShow traktShow = new TraktShow();

                while (jsonReader.Read() && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_TITLE:
                            traktShow.Title = jsonReader.ReadAsString();
                            break;
                        case PROPERTY_NAME_YEAR:
                            traktShow.Year = jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_IDS:
                            traktShow.Ids = idsObjectReader.ReadObject(jsonReader);
                            break;
                        case PROPERTY_NAME_OVERVIEW:
                            traktShow.Overview = jsonReader.ReadAsString();
                            break;
                        case PROPERTY_NAME_FIRST_AIRED:
                            if (jsonReader.Read())
                            {
                                if (jsonReader.ValueType == typeof(DateTime))
                                    traktShow.FirstAired = (DateTime)jsonReader.Value;
                                else if (jsonReader.ValueType == typeof(string))
                                    traktShow.FirstAired = DateTime.Parse(jsonReader.Value.ToString());
                            }

                            break;
                        case PROPERTY_NAME_AIRS:
                            traktShow.Airs = airsObjectReader.ReadObject(jsonReader);
                            break;
                        case PROPERTY_NAME_RUNTIME:
                            traktShow.Runtime = jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_CERTIFICATION:
                            traktShow.Certification = jsonReader.ReadAsString();
                            break;
                        case PROPERTY_NAME_NETWORK:
                            traktShow.Network = jsonReader.ReadAsString();
                            break;
                        case PROPERTY_NAME_COUNTRY:
                            traktShow.CountryCode = jsonReader.ReadAsString();
                            break;
                        case PROPERTY_NAME_TRAILER:
                            traktShow.Trailer = jsonReader.ReadAsString();
                            break;
                        case PROPERTY_NAME_HOMEPAGE:
                            traktShow.Homepage = jsonReader.ReadAsString();
                            break;
                        case PROPERTY_NAME_STATUS:
                            var value = jsonReader.ReadAsString();

                            if (!string.IsNullOrEmpty(value))
                                traktShow.Status = TraktEnumeration.FromObjectName<TraktShowStatus>(value);

                            break;
                        case PROPERTY_NAME_RATING:
                            traktShow.Rating = (float?)jsonReader.ReadAsDouble();
                            break;
                        case PROPERTY_NAME_VOTES:
                            traktShow.Votes = jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_UPDATED_AT:
                            if (jsonReader.Read())
                            {
                                if (jsonReader.ValueType == typeof(DateTime))
                                    traktShow.UpdatedAt = (DateTime)jsonReader.Value;
                                else if (jsonReader.ValueType == typeof(string))
                                    traktShow.UpdatedAt = DateTime.Parse(jsonReader.Value.ToString());
                            }

                            break;
                        case PROPERTY_NAME_LANGUAGE:
                            traktShow.LanguageCode = jsonReader.ReadAsString();
                            break;
                        case PROPERTY_NAME_AVAILABLE_TRANSLATIONS:
                            traktShow.AvailableTranslationLanguageCodes = ReadStringArray(jsonReader);
                            break;
                        case PROPERTY_NAME_GENRES:
                            traktShow.Genres = ReadStringArray(jsonReader);
                            break;
                        case PROPERTY_NAME_AIRED_EPISODES:
                            traktShow.AiredEpisodes = jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_SEASONS:
                            traktShow.Seasons = seasonsArrayReader.ReadArray(jsonReader);
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

                return traktShow;
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
