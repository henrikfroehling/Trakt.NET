namespace TraktNet.Objects.Get.History.Json.Reader
{
    using Enums;
    using Episodes.Json.Reader;
    using Movies.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using Seasons.Json.Reader;
    using Shows.Json.Reader;
    using System.Threading;
    using System.Threading.Tasks;

    internal class HistoryItemObjectJsonReader : AObjectJsonReader<ITraktHistoryItem>
    {
        public override async Task<ITraktHistoryItem> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktHistoryItem));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieObjectReader = new MovieObjectJsonReader();
                var showObjectReader = new ShowObjectJsonReader();
                var seasonObjectReader = new SeasonObjectJsonReader();
                var episodeObjectReader = new EpisodeObjectJsonReader();

                ITraktHistoryItem traktHistoryItem = new TraktHistoryItem();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.HISTORY_ITEM_PROPERTY_NAME_ID:
                            {
                                var value = await JsonReaderHelper.ReadUnsignedLongValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktHistoryItem.Id = value.Second;

                                break;
                            }
                        case JsonProperties.HISTORY_ITEM_PROPERTY_NAME_WATCHED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktHistoryItem.WatchedAt = value.Second;

                                break;
                            }
                        case JsonProperties.HISTORY_ITEM_PROPERTY_NAME_ACTION:
                            traktHistoryItem.Action = await JsonReaderHelper.ReadEnumerationValueAsync<TraktHistoryActionType>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.HISTORY_ITEM_PROPERTY_NAME_TYPE:
                            traktHistoryItem.Type = await JsonReaderHelper.ReadEnumerationValueAsync<TraktSyncItemType>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.HISTORY_ITEM_PROPERTY_NAME_MOVIE:
                            traktHistoryItem.Movie = await movieObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.HISTORY_ITEM_PROPERTY_NAME_SHOW:
                            traktHistoryItem.Show = await showObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.HISTORY_ITEM_PROPERTY_NAME_SEASON:
                            traktHistoryItem.Season = await seasonObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.HISTORY_ITEM_PROPERTY_NAME_EPISODE:
                            traktHistoryItem.Episode = await episodeObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktHistoryItem;
            }

            return await Task.FromResult(default(ITraktHistoryItem));
        }
    }
}
