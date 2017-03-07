namespace TraktApiSharp.Objects.JsonReader.Get.People
{
    using Newtonsoft.Json;
    using Objects.Get.People;
    using System.IO;

    internal class TraktPersonIdsObjectJsonReader : ITraktObjectJsonReader<TraktPersonIds>
    {
        private const string PROPERTY_NAME_TRAKT = "trakt";
        private const string PROPERTY_NAME_SLUG = "slug";
        private const string PROPERTY_NAME_IMDB = "imdb";
        private const string PROPERTY_NAME_TMDB = "tmdb";
        private const string PROPERTY_NAME_TVRAGE = "tvrage";

        public TraktPersonIds ReadObject(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObject(jsonReader);
            }
        }

        public TraktPersonIds ReadObject(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
            {
                var traktPersonIds = new TraktPersonIds();

                while (jsonReader.Read() && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_TRAKT:
                            traktPersonIds.Trakt = (uint)jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_SLUG:
                            traktPersonIds.Slug = jsonReader.ReadAsString();
                            break;
                        case PROPERTY_NAME_IMDB:
                            traktPersonIds.Imdb = jsonReader.ReadAsString();
                            break;
                        case PROPERTY_NAME_TMDB:
                            traktPersonIds.Tmdb = (uint)jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_TVRAGE:
                            traktPersonIds.TvRage = (uint)jsonReader.ReadAsInt32();
                            break;
                        default:
                            JsonReaderHelper.OverreadInvalidContent(jsonReader);
                            break;
                    }
                }

                return traktPersonIds;
            }

            return null;
        }
    }
}
