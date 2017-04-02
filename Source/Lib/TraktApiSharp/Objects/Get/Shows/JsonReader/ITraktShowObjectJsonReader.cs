namespace TraktApiSharp.Objects.Get.Shows.JsonReader
{
    using Enums;
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using Seasons.JsonReader;
    using Shows;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ITraktShowObjectJsonReader : ITraktObjectJsonReader<ITraktShow>
    {
        private const string PROPERTY_NAME_TITLE = "title";
        private const string PROPERTY_NAME_YEAR = "year";
        private const string PROPERTY_NAME_IDS = "ids";
        private const string PROPERTY_NAME_OVERVIEW = "overview";
        private const string PROPERTY_NAME_FIRST_AIRED = "first_aired";
        private const string PROPERTY_NAME_AIRS = "airs";
        private const string PROPERTY_NAME_RUNTIME = "runtime";
        private const string PROPERTY_NAME_CERTIFICATION = "certification";
        private const string PROPERTY_NAME_NETWORK = "network";
        private const string PROPERTY_NAME_COUNTRY = "country";
        private const string PROPERTY_NAME_TRAILER = "trailer";
        private const string PROPERTY_NAME_HOMEPAGE = "homepage";
        private const string PROPERTY_NAME_STATUS = "status";
        private const string PROPERTY_NAME_RATING = "rating";
        private const string PROPERTY_NAME_VOTES = "votes";
        private const string PROPERTY_NAME_UPDATED_AT = "updated_at";
        private const string PROPERTY_NAME_LANGUAGE = "language";
        private const string PROPERTY_NAME_AVAILABLE_TRANSLATIONS = "available_translations";
        private const string PROPERTY_NAME_GENRES = "genres";
        private const string PROPERTY_NAME_AIRED_EPISODES = "aired_episodes";
        private const string PROPERTY_NAME_SEASONS = "seasons";

        public Task<ITraktShow> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktShow> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return null;

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var idsObjectReader = new ITraktShowIdsObjectJsonReader();
                var airsObjectReader = new ITraktShowAirsObjectJsonReader();
                var seasonsArrayReader = new ITraktSeasonArrayJsonReader();

                ITraktShow traktShow = new TraktShow();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_TITLE:
                            traktShow.Title = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case PROPERTY_NAME_YEAR:
                            traktShow.Year = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case PROPERTY_NAME_IDS:
                            traktShow.Ids = await idsObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_OVERVIEW:
                            traktShow.Overview = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case PROPERTY_NAME_FIRST_AIRED:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktShow.FirstAired = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_AIRS:
                            traktShow.Airs = await airsObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_RUNTIME:
                            traktShow.Runtime = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case PROPERTY_NAME_CERTIFICATION:
                            traktShow.Certification = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case PROPERTY_NAME_NETWORK:
                            traktShow.Network = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case PROPERTY_NAME_COUNTRY:
                            traktShow.CountryCode = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case PROPERTY_NAME_TRAILER:
                            traktShow.Trailer = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case PROPERTY_NAME_HOMEPAGE:
                            traktShow.Homepage = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case PROPERTY_NAME_STATUS:
                            traktShow.Status = await JsonReaderHelper.ReadEnumerationValueAsync<TraktShowStatus>(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_RATING:
                            traktShow.Rating = (float?)await jsonReader.ReadAsDoubleAsync(cancellationToken);
                            break;
                        case PROPERTY_NAME_VOTES:
                            traktShow.Votes = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case PROPERTY_NAME_UPDATED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktShow.UpdatedAt = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_LANGUAGE:
                            traktShow.LanguageCode = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case PROPERTY_NAME_AVAILABLE_TRANSLATIONS:
                            traktShow.AvailableTranslationLanguageCodes = await JsonReaderHelper.ReadStringArrayAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_GENRES:
                            traktShow.Genres = await JsonReaderHelper.ReadStringArrayAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_AIRED_EPISODES:
                            traktShow.AiredEpisodes = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case PROPERTY_NAME_SEASONS:
                            traktShow.Seasons = await seasonsArrayReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktShow;
            }

            return null;
        }
    }
}
