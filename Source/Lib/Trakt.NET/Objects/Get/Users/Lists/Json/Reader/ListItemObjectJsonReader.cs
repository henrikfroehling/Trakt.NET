namespace TraktNet.Objects.Get.Users.Lists.Json.Reader
{
    using Enums;
    using Episodes.Json.Reader;
    using Movies.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using People.Json.Reader;
    using Seasons.Json.Reader;
    using Shows.Json.Reader;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ListItemObjectJsonReader : AObjectJsonReader<ITraktListItem>
    {
        public override async Task<ITraktListItem> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieReader = new MovieObjectJsonReader();
                var showReader = new ShowObjectJsonReader();
                var seasonReader = new SeasonObjectJsonReader();
                var episodeReader = new EpisodeObjectJsonReader();
                var personReader = new PersonObjectJsonReader();

                ITraktListItem traktListItem = new TraktListItem();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_ID:
                            {
                                var value = await JsonReaderHelper.ReadUnsignedIntegerValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktListItem.Id = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_RANK:
                            traktListItem.Rank = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_LISTED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktListItem.ListedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_TYPE:
                            traktListItem.Type = await JsonReaderHelper.ReadEnumerationValueAsync<TraktListItemType>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_MOVIE:
                            traktListItem.Movie = await movieReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SHOW:
                            traktListItem.Show = await showReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SEASON:
                            traktListItem.Season = await seasonReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_EPISODE:
                            traktListItem.Episode = await episodeReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_PERSON:
                            traktListItem.Person = await personReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktListItem;
            }

            return await Task.FromResult(default(ITraktListItem));
        }
    }
}
