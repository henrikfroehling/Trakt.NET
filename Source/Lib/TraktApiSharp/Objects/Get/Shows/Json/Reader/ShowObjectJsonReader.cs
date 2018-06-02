namespace TraktApiSharp.Objects.Get.Shows.Json.Reader
{
    using Enums;
    using Newtonsoft.Json;
    using Objects.Json;
    using Seasons.Json.Reader;
    using Shows;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ShowObjectJsonReader : AObjectJsonReader<ITraktShow>
    {
        public override async Task<ITraktShow> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktShow));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var idsObjectReader = new ShowIdsObjectJsonReader();
                var airsObjectReader = new ShowAirsObjectJsonReader();
                var seasonsArrayReader = new SeasonArrayJsonReader();

                ITraktShow traktShow = new TraktShow();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.SHOW_PROPERTY_NAME_TITLE:
                            traktShow.Title = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.SHOW_PROPERTY_NAME_YEAR:
                            traktShow.Year = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.SHOW_PROPERTY_NAME_IDS:
                            traktShow.Ids = await idsObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.SHOW_PROPERTY_NAME_OVERVIEW:
                            traktShow.Overview = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.SHOW_PROPERTY_NAME_FIRST_AIRED:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktShow.FirstAired = value.Second;

                                break;
                            }
                        case JsonProperties.SHOW_PROPERTY_NAME_AIRS:
                            traktShow.Airs = await airsObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.SHOW_PROPERTY_NAME_RUNTIME:
                            traktShow.Runtime = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.SHOW_PROPERTY_NAME_CERTIFICATION:
                            traktShow.Certification = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.SHOW_PROPERTY_NAME_NETWORK:
                            traktShow.Network = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.SHOW_PROPERTY_NAME_COUNTRY:
                            traktShow.CountryCode = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.SHOW_PROPERTY_NAME_TRAILER:
                            traktShow.Trailer = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.SHOW_PROPERTY_NAME_HOMEPAGE:
                            traktShow.Homepage = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.SHOW_PROPERTY_NAME_STATUS:
                            traktShow.Status = await JsonReaderHelper.ReadEnumerationValueAsync<TraktShowStatus>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.SHOW_PROPERTY_NAME_RATING:
                            traktShow.Rating = (float?)await jsonReader.ReadAsDoubleAsync(cancellationToken);
                            break;
                        case JsonProperties.SHOW_PROPERTY_NAME_VOTES:
                            traktShow.Votes = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.SHOW_PROPERTY_NAME_UPDATED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktShow.UpdatedAt = value.Second;

                                break;
                            }
                        case JsonProperties.SHOW_PROPERTY_NAME_LANGUAGE:
                            traktShow.LanguageCode = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.SHOW_PROPERTY_NAME_AVAILABLE_TRANSLATIONS:
                            traktShow.AvailableTranslationLanguageCodes = await JsonReaderHelper.ReadStringArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.SHOW_PROPERTY_NAME_GENRES:
                            traktShow.Genres = await JsonReaderHelper.ReadStringArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.SHOW_PROPERTY_NAME_AIRED_EPISODES:
                            traktShow.AiredEpisodes = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.SHOW_PROPERTY_NAME_SEASONS:
                            traktShow.Seasons = await seasonsArrayReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.SHOW_PROPERTY_NAME_COMMENT_COUNT:
                            traktShow.CommentCount = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktShow;
            }

            return await Task.FromResult(default(ITraktShow));
        }
    }
}
