namespace TraktApiSharp.Objects.JsonReader.Get.Seasons
{
    using Newtonsoft.Json;
    using Objects.Get.Seasons;
    using System.IO;

    internal class TraktSeasonIdsObjectJsonReader : ITraktObjectJsonReader<TraktSeasonIds>
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
                            traktSeasonIds.Trakt = (uint)jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_TVDB:
                            traktSeasonIds.Tvdb = (uint)jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_TMDB:
                            traktSeasonIds.Tmdb = (uint)jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_TVRAGE:
                            traktSeasonIds.TvRage = (uint)jsonReader.ReadAsInt32();
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
