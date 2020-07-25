namespace TraktNet.Objects.Get.Users.Json.Reader
{
    using Enums;
    using Episodes.Json.Reader;
    using Movies.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using Shows.Json.Reader;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserWatchingItemObjectJsonReader : AObjectJsonReader<ITraktUserWatchingItem>
    {
        public override async Task<ITraktUserWatchingItem> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktUserWatchingItem));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieReader = new MovieObjectJsonReader();
                var showReader = new ShowObjectJsonReader();
                var episodeReader = new EpisodeObjectJsonReader();
                ITraktUserWatchingItem traktUserWatchingItem = new TraktUserWatchingItem();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_STARTED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktUserWatchingItem.StartedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_EXPIRES_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktUserWatchingItem.ExpiresAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_ACTION:
                            traktUserWatchingItem.Action = await JsonReaderHelper.ReadEnumerationValueAsync<TraktHistoryActionType>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_TYPE:
                            traktUserWatchingItem.Type = await JsonReaderHelper.ReadEnumerationValueAsync<TraktSyncType>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_MOVIE:
                            traktUserWatchingItem.Movie = await movieReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SHOW:
                            traktUserWatchingItem.Show = await showReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_EPISODE:
                            traktUserWatchingItem.Episode = await episodeReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktUserWatchingItem;
            }

            return await Task.FromResult(default(ITraktUserWatchingItem));
        }
    }
}
