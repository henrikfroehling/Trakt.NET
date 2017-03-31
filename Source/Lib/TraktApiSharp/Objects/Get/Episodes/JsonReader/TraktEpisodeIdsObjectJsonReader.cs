namespace TraktApiSharp.Objects.Get.Episodes.JsonReader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.IO;

    internal class TraktEpisodeIdsObjectJsonReader : ITraktObjectJsonReader<TraktEpisodeIds>
    {
        private const string PROPERTY_NAME_TRAKT = "trakt";
        private const string PROPERTY_NAME_TVDB = "tvdb";
        private const string PROPERTY_NAME_IMDB = "imdb";
        private const string PROPERTY_NAME_TMDB = "tmdb";
        private const string PROPERTY_NAME_TVRAGE = "tvrage";

        public TraktEpisodeIds ReadObject(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObject(jsonReader);
            }
        }

        public TraktEpisodeIds ReadObject(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
            {
                var traktEpisodeIds = new TraktEpisodeIds();

                while (jsonReader.Read() && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_TRAKT:
                            uint traktId;

                            if (JsonReaderHelper.ReadUnsignedIntegerValue(jsonReader, out traktId))
                                traktEpisodeIds.Trakt = traktId;

                            break;
                        case PROPERTY_NAME_TVDB:
                            uint tvdbId;

                            if (JsonReaderHelper.ReadUnsignedIntegerValue(jsonReader, out tvdbId))
                                traktEpisodeIds.Tvdb = tvdbId;

                            break;
                        case PROPERTY_NAME_IMDB:
                            traktEpisodeIds.Imdb = jsonReader.ReadAsString();
                            break;
                        case PROPERTY_NAME_TMDB:
                            uint tmdbId;

                            if (JsonReaderHelper.ReadUnsignedIntegerValue(jsonReader, out tmdbId))
                                traktEpisodeIds.Tmdb = tmdbId;

                            break;
                        case PROPERTY_NAME_TVRAGE:
                            uint tvRageId;

                            if (JsonReaderHelper.ReadUnsignedIntegerValue(jsonReader, out tvRageId))
                                traktEpisodeIds.TvRage = tvRageId;

                            break;
                        default:
                            JsonReaderHelper.OverreadInvalidContent(jsonReader);
                            break;
                    }
                }

                return traktEpisodeIds;
            }

            return null;
        }
    }
}
