namespace TraktApiSharp.Objects.JsonReader.Basic
{
    using Newtonsoft.Json;
    using Objects.Basic;
    using System.IO;

    internal class TraktIdsObjectJsonReader : ITraktObjectJsonReader<TraktIds>
    {
        private const string PROPERTY_NAME_TRAKT = "trakt";
        private const string PROPERTY_NAME_SLUG = "slug";
        private const string PROPERTY_NAME_TVDB = "tvdb";
        private const string PROPERTY_NAME_IMDB = "imdb";
        private const string PROPERTY_NAME_TMDB = "tmdb";
        private const string PROPERTY_NAME_TVRAGE = "tvrage";

        public TraktIds ReadObject(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObject(jsonReader);
            }
        }

        public TraktIds ReadObject(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
            {
                var traktIds = new TraktIds();

                while (jsonReader.Read() && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_TRAKT:
                            uint traktId;

                            if (JsonReaderHelper.ReadUnsignedIntegerValue(jsonReader, out traktId))
                                traktIds.Trakt = traktId;

                            break;
                        case PROPERTY_NAME_SLUG:
                            traktIds.Slug = jsonReader.ReadAsString();
                            break;
                        case PROPERTY_NAME_TVDB:
                            uint tvdbId;

                            if (JsonReaderHelper.ReadUnsignedIntegerValue(jsonReader, out tvdbId))
                                traktIds.Tvdb = tvdbId;

                            break;
                        case PROPERTY_NAME_IMDB:
                            traktIds.Imdb = jsonReader.ReadAsString();
                            break;
                        case PROPERTY_NAME_TMDB:
                            uint tmdbId;

                            if (JsonReaderHelper.ReadUnsignedIntegerValue(jsonReader, out tmdbId))
                                traktIds.Tmdb = tmdbId;

                            break;
                        case PROPERTY_NAME_TVRAGE:
                            uint tvRageId;

                            if (JsonReaderHelper.ReadUnsignedIntegerValue(jsonReader, out tvRageId))
                                traktIds.TvRage = tvRageId;

                            break;
                        default:
                            JsonReaderHelper.OverreadInvalidContent(jsonReader);
                            break;
                    }
                }

                return traktIds;
            }

            return null;
        }
    }
}
