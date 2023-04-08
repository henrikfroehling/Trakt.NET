namespace TraktNet.Objects.Get.Shows.Json.Reader
{
    using Enums;
    using Newtonsoft.Json;
    using Objects.Json;
    using Seasons;
    using System.Threading;
    using System.Threading.Tasks;

    internal abstract class AShowObjectJsonReader<TShowObjectType> : AObjectJsonReader<TShowObjectType> where TShowObjectType : ITraktShow
    {
        public override async Task<TShowObjectType> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                TShowObjectType show = CreateShowObject();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();
                    await ReadPropertyAsync(jsonReader, show, propertyName, cancellationToken);
                }

                return show;
            }

            return await Task.FromResult(default(TShowObjectType));
        }

        protected virtual async Task ReadPropertyAsync(JsonTextReader jsonReader, TShowObjectType show, string propertyName, CancellationToken cancellationToken = default)
        {
            switch (propertyName)
            {
                case JsonProperties.PROPERTY_NAME_TITLE:
                    show.Title = await jsonReader.ReadAsStringAsync(cancellationToken);
                    break;
                case JsonProperties.PROPERTY_NAME_YEAR:
                    show.Year = await jsonReader.ReadAsInt32Async(cancellationToken);
                    break;
                case JsonProperties.PROPERTY_NAME_IDS:
                    var idsObjectReader = new ShowIdsObjectJsonReader();
                    show.Ids = await idsObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                    break;
                case JsonProperties.PROPERTY_NAME_OVERVIEW:
                    show.Overview = await jsonReader.ReadAsStringAsync(cancellationToken);
                    break;
                case JsonProperties.PROPERTY_NAME_FIRST_AIRED:
                    {
                        var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                        if (value.First)
                            show.FirstAired = value.Second;

                        break;
                    }
                case JsonProperties.PROPERTY_NAME_AIRS:
                    var airsObjectReader = new ShowAirsObjectJsonReader();
                    show.Airs = await airsObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                    break;
                case JsonProperties.PROPERTY_NAME_RUNTIME:
                    show.Runtime = await jsonReader.ReadAsInt32Async(cancellationToken);
                    break;
                case JsonProperties.PROPERTY_NAME_CERTIFICATION:
                    show.Certification = await jsonReader.ReadAsStringAsync(cancellationToken);
                    break;
                case JsonProperties.PROPERTY_NAME_NETWORK:
                    show.Network = await jsonReader.ReadAsStringAsync(cancellationToken);
                    break;
                case JsonProperties.PROPERTY_NAME_COUNTRY:
                    show.CountryCode = await jsonReader.ReadAsStringAsync(cancellationToken);
                    break;
                case JsonProperties.PROPERTY_NAME_TRAILER:
                    show.Trailer = await jsonReader.ReadAsStringAsync(cancellationToken);
                    break;
                case JsonProperties.PROPERTY_NAME_HOMEPAGE:
                    show.Homepage = await jsonReader.ReadAsStringAsync(cancellationToken);
                    break;
                case JsonProperties.PROPERTY_NAME_STATUS:
                    show.Status = await JsonReaderHelper.ReadEnumerationValueAsync<TraktShowStatus>(jsonReader, cancellationToken);
                    break;
                case JsonProperties.PROPERTY_NAME_RATING:
                    show.Rating = (float?)await jsonReader.ReadAsDoubleAsync(cancellationToken);
                    break;
                case JsonProperties.PROPERTY_NAME_VOTES:
                    show.Votes = await jsonReader.ReadAsInt32Async(cancellationToken);
                    break;
                case JsonProperties.PROPERTY_NAME_UPDATED_AT:
                    {
                        var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                        if (value.First)
                            show.UpdatedAt = value.Second;

                        break;
                    }
                case JsonProperties.PROPERTY_NAME_LANGUAGE:
                    show.LanguageCode = await jsonReader.ReadAsStringAsync(cancellationToken);
                    break;
                case JsonProperties.PROPERTY_NAME_AVAILABLE_TRANSLATIONS:
                    show.AvailableTranslationLanguageCodes = await JsonReaderHelper.ReadStringArrayAsync(jsonReader, cancellationToken);
                    break;
                case JsonProperties.PROPERTY_NAME_GENRES:
                    show.Genres = await JsonReaderHelper.ReadStringArrayAsync(jsonReader, cancellationToken);
                    break;
                case JsonProperties.PROPERTY_NAME_AIRED_EPISODES:
                    show.AiredEpisodes = await jsonReader.ReadAsInt32Async(cancellationToken);
                    break;
                case JsonProperties.PROPERTY_NAME_SEASONS:
                    var seasonsArrayReader = new ArrayJsonReader<ITraktSeason>();
                    show.Seasons = await seasonsArrayReader.ReadArrayAsync(jsonReader, cancellationToken);
                    break;
                case JsonProperties.PROPERTY_NAME_COMMENT_COUNT:
                    show.CommentCount = await jsonReader.ReadAsInt32Async(cancellationToken);
                    break;
                default:
                    await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                    break;
            }
        }

        protected abstract TShowObjectType CreateShowObject();
    }
}
