namespace TraktApiSharp.Objects.JsonReader.Get.Shows
{
    using Newtonsoft.Json;
    using Objects.Get.Shows;
    using System.IO;

    internal class TraktShowIdsObjectJsonReader : ITraktObjectJsonReader<TraktShowIds>
    {
        private const string PROPERTY_NAME_TRAKT = "trakt";
        private const string PROPERTY_NAME_SLUG = "slug";
        private const string PROPERTY_NAME_TVDB = "tvdb";
        private const string PROPERTY_NAME_IMDB = "imdb";
        private const string PROPERTY_NAME_TMDB = "tmdb";
        private const string PROPERTY_NAME_TVRAGE = "tvrage";

        public TraktShowIds ReadObject(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObject(jsonReader);
            }
        }

        public TraktShowIds ReadObject(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
            {
                var traktShowIds = new TraktShowIds();

                while (jsonReader.Read() && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_TRAKT:
                            traktShowIds.Trakt = (uint)jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_SLUG:
                            traktShowIds.Slug = jsonReader.ReadAsString();
                            break;
                        case PROPERTY_NAME_TVDB:
                            traktShowIds.Tvdb = (uint)jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_IMDB:
                            traktShowIds.Imdb = jsonReader.ReadAsString();
                            break;
                        case PROPERTY_NAME_TMDB:
                            traktShowIds.Tmdb = (uint)jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_TVRAGE:
                            traktShowIds.TvRage = (uint)jsonReader.ReadAsInt32();
                            break;
                        default:
                            jsonReader.Read(); // read unmatched property value
                            break;
                    }
                }

                return traktShowIds;
            }

            return null;
        }
    }
}
