namespace TraktApiSharp.Objects.Get.Seasons.JsonReader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.IO;

    internal class ITraktSeasonIdsObjectJsonReader : ITraktObjectJsonReader<TraktSeasonIds>
    {
        private const string PROPERTY_NAME_TRAKT = "trakt";
        private const string PROPERTY_NAME_TVDB = "tvdb";
        private const string PROPERTY_NAME_TMDB = "tmdb";
        private const string PROPERTY_NAME_TVRAGE = "tvrage";

        public TraktSeasonIds ReadObject(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObject(jsonReader);
            }
        }

        public TraktSeasonIds ReadObject(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
            {
                var traktSeasonIds = new TraktSeasonIds();

                while (jsonReader.Read() && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_TRAKT:
                            uint traktId;

                            if (JsonReaderHelper.ReadUnsignedIntegerValue(jsonReader, out traktId))
                                traktSeasonIds.Trakt = traktId;

                            break;
                        case PROPERTY_NAME_TVDB:
                            uint tvdbId;

                            if (JsonReaderHelper.ReadUnsignedIntegerValue(jsonReader, out tvdbId))
                                traktSeasonIds.Tvdb = tvdbId;

                            break;
                        case PROPERTY_NAME_TMDB:
                            uint tmdbId;

                            if (JsonReaderHelper.ReadUnsignedIntegerValue(jsonReader, out tmdbId))
                                traktSeasonIds.Tmdb = tmdbId;

                            break;
                        case PROPERTY_NAME_TVRAGE:
                            uint tvRageId;

                            if (JsonReaderHelper.ReadUnsignedIntegerValue(jsonReader, out tvRageId))
                                traktSeasonIds.TvRage = tvRageId;

                            break;
                        default:
                            JsonReaderHelper.OverreadInvalidContent(jsonReader);
                            break;
                    }
                }

                return traktSeasonIds;
            }

            return null;
        }
    }
}
