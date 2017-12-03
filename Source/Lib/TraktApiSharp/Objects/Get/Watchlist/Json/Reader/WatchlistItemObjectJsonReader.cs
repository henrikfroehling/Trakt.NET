namespace TraktApiSharp.Objects.Get.Watchlist.Json.Reader
{
    using Enums;
    using Episodes.Json.Reader;
    using Implementations;
    using Movies.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using Seasons.Json.Reader;
    using Shows.Json.Reader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class WatchlistItemObjectJsonReader : IObjectJsonReader<ITraktWatchlistItem>
    {
        public Task<ITraktWatchlistItem> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktWatchlistItem));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktWatchlistItem> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktWatchlistItem));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktWatchlistItem> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktWatchlistItem));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieObjectReader = new MovieObjectJsonReader();
                var showObjectReader = new ShowObjectJsonReader();
                var seasonObjectReader = new SeasonObjectJsonReader();
                var episodeObjectReader = new EpisodeObjectJsonReader();

                ITraktWatchlistItem traktWatchlistItem = new TraktWatchlistItem();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.WATCHLIST_ITEM_PROPERTY_NAME_LISTED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktWatchlistItem.ListedAt = value.Second;

                                break;
                            }
                        case JsonProperties.WATCHLIST_ITEM_PROPERTY_NAME_TYPE:
                            traktWatchlistItem.Type = await JsonReaderHelper.ReadEnumerationValueAsync<TraktSyncItemType>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.WATCHLIST_ITEM_PROPERTY_NAME_MOVIE:
                            traktWatchlistItem.Movie = await movieObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.WATCHLIST_ITEM_PROPERTY_NAME_SHOW:
                            traktWatchlistItem.Show = await showObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.WATCHLIST_ITEM_PROPERTY_NAME_SEASON:
                            traktWatchlistItem.Season = await seasonObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.WATCHLIST_ITEM_PROPERTY_NAME_EPISODE:
                            traktWatchlistItem.Episode = await episodeObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktWatchlistItem;
            }

            return await Task.FromResult(default(ITraktWatchlistItem));
        }
    }
}
