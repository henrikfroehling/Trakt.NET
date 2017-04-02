namespace TraktApiSharp.Objects.Basic.JsonReader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ITraktIdsObjectJsonReader : ITraktObjectJsonReader<ITraktIds>
    {
        private const string PROPERTY_NAME_TRAKT = "trakt";
        private const string PROPERTY_NAME_SLUG = "slug";
        private const string PROPERTY_NAME_TVDB = "tvdb";
        private const string PROPERTY_NAME_IMDB = "imdb";
        private const string PROPERTY_NAME_TMDB = "tmdb";
        private const string PROPERTY_NAME_TVRAGE = "tvrage";

        public Task<ITraktIds> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktIds> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return null;

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktIds traktIds = new TraktIds();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
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
                            traktIds.Imdb = await jsonReader.ReadAsStringAsync(cancellationToken);
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
