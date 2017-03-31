namespace TraktApiSharp.Objects.Get.Movies.JsonReader
{
    using Newtonsoft.Json;
    using Objects.Get.Movies.Implementations;
    using Objects.JsonReader;
    using System.IO;

    internal class TraktMovieIdsObjectJsonReader : ITraktObjectJsonReader<TraktMovieIds>
    {
        private const string PROPERTY_NAME_TRAKT = "trakt";
        private const string PROPERTY_NAME_SLUG = "slug";
        private const string PROPERTY_NAME_IMDB = "imdb";
        private const string PROPERTY_NAME_TMDB = "tmdb";

        public TraktMovieIds ReadObject(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObject(jsonReader);
            }
        }

        public TraktMovieIds ReadObject(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
            {
                var traktMovieIds = new TraktMovieIds();

                while (jsonReader.Read() && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_TRAKT:
                            uint traktId;

                            if (JsonReaderHelper.ReadUnsignedIntegerValue(jsonReader, out traktId))
                                traktMovieIds.Trakt = traktId;

                            break;
                        case PROPERTY_NAME_SLUG:
                            traktMovieIds.Slug = jsonReader.ReadAsString();
                            break;
                        case PROPERTY_NAME_IMDB:
                            traktMovieIds.Imdb = jsonReader.ReadAsString();
                            break;
                        case PROPERTY_NAME_TMDB:
                            uint tmdbId;

                            if (JsonReaderHelper.ReadUnsignedIntegerValue(jsonReader, out tmdbId))
                                traktMovieIds.Tmdb = tmdbId;

                            break;
                        default:
                            JsonReaderHelper.OverreadInvalidContent(jsonReader);
                            break;
                    }
                }

                return traktMovieIds;
            }

            return null;
        }
    }
}
