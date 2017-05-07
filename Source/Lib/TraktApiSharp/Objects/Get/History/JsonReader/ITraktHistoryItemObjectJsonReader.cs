namespace TraktApiSharp.Objects.Get.History.JsonReader
{
    using Enums;
    using Episodes.JsonReader;
    using Implementations;
    using Movies.JsonReader;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using Seasons.JsonReader;
    using Shows.JsonReader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ITraktHistoryItemObjectJsonReader : ITraktObjectJsonReader<ITraktHistoryItem>
    {
        private const string PROPERTY_NAME_ID = "id";
        private const string PROPERTY_NAME_WATCHED_AT = "watched_at";
        private const string PROPERTY_NAME_ACTION = "action";
        private const string PROPERTY_NAME_TYPE = "type";
        private const string PROPERTY_NAME_MOVIE = "movie";
        private const string PROPERTY_NAME_SHOW = "show";
        private const string PROPERTY_NAME_SEASON = "season";
        private const string PROPERTY_NAME_EPISODE = "episode";

        public Task<ITraktHistoryItem> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktHistoryItem));

            var item = new TraktHistoryItem();

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktHistoryItem> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktHistoryItem));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktHistoryItem> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktHistoryItem));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieObjectReader = new ITraktMovieObjectJsonReader();
                var showObjectReader = new ITraktShowObjectJsonReader();
                var seasonObjectReader = new ITraktSeasonObjectJsonReader();
                var episodeObjectReader = new ITraktEpisodeObjectJsonReader();

                ITraktHistoryItem traktHistoryItem = new TraktHistoryItem();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_ID:
                            {
                                var value = await JsonReaderHelper.ReadUnsignedLongIntegerAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktHistoryItem.Id = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_WATCHED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktHistoryItem.WatchedAt = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_ACTION:
                            traktHistoryItem.Action = await JsonReaderHelper.ReadEnumerationValueAsync<TraktHistoryActionType>(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_TYPE:
                            traktHistoryItem.Type = await JsonReaderHelper.ReadEnumerationValueAsync<TraktSyncItemType>(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_MOVIE:
                            traktHistoryItem.Movie = await movieObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_SHOW:
                            traktHistoryItem.Show = await showObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_SEASON:
                            traktHistoryItem.Season = await seasonObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_EPISODE:
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
