namespace TraktApiSharp.Objects.Get.Episodes.JsonReader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System;
    using System.IO;

    internal class ITraktEpisodeObjectJsonReader : ITraktObjectJsonReader<ITraktEpisode>
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

        public ITraktEpisode ReadObject(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObject(jsonReader);
            }
        }

        public ITraktEpisode ReadObject(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
            {
                var idsObjectReader = new ITraktEpisodeIdsObjectJsonReader();
                var translationArrayReader = new ITraktEpisodeTranslationArrayJsonReader();
                ITraktEpisode traktEpisode = new TraktEpisode();

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
                            {
                                DateTime dateTime;
                                if (JsonReaderHelper.ReadDateTimeValue(jsonReader, out dateTime))
                                    traktEpisode.FirstAired = dateTime;

                                break;
                            }
                        case PROPERTY_NAME_UPDATED_AT:
                            {
                                DateTime dateTime;
                                if (JsonReaderHelper.ReadDateTimeValue(jsonReader, out dateTime))
                                    traktEpisode.UpdatedAt = dateTime;

                                break;
                            }
                        case PROPERTY_NAME_AVAILABLE_TRANSLATIONS:
                            traktEpisode.AvailableTranslationLanguageCodes = JsonReaderHelper.ReadStringArray(jsonReader);
                            break;
                        case PROPERTY_NAME_TRANSLATIONS:
                            traktEpisode.Translations = translationArrayReader.ReadArray(jsonReader);
                            break;
                        default:
                            JsonReaderHelper.OverreadInvalidContent(jsonReader);
                            break;
                    }
                }

                return traktEpisode;
            }

            return null;
        }
    }
}
