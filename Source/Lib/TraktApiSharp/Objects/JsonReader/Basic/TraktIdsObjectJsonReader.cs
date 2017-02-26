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
                            traktIds.Trakt = (uint)jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_SLUG:
                            traktIds.Slug = jsonReader.ReadAsString();
                            break;
                        case PROPERTY_NAME_TVDB:
                            traktIds.Tvdb = (uint)jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_IMDB:
                            traktIds.Imdb = jsonReader.ReadAsString();
                            break;
                        case PROPERTY_NAME_TMDB:
                            traktIds.Tmdb = (uint)jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_TVRAGE:
                            traktIds.TvRage = (uint)jsonReader.ReadAsInt32();
                            break;
                        default:
                            jsonReader.Read(); // read unmatched property value
                            break;
                    }
                }

                return traktIds;
            }

            return null;
        }
    }
}
