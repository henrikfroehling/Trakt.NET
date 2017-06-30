namespace TraktApiSharp.Objects.Get.Users.JsonReader
{
    using Enums;
    using Episodes.JsonReader;
    using Implementations;
    using Movies.JsonReader;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using Shows.JsonReader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TraktUserWatchingItemObjectJsonReader : ITraktObjectJsonReader<ITraktUserWatchingItem>
    {
        private const string PROPERTY_NAME_STARTED_AT = "started_at";
        private const string PROPERTY_NAME_EXPIRES_AT = "expires_at";
        private const string PROPERTY_NAME_ACTION = "action";
        private const string PROPERTY_NAME_TYPE = "type";
        private const string PROPERTY_NAME_MOVIE = "movie";
        private const string PROPERTY_NAME_SHOW = "show";
        private const string PROPERTY_NAME_EPISODE = "episode";

        public Task<ITraktUserWatchingItem> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktUserWatchingItem));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktUserWatchingItem> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktUserWatchingItem));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktUserWatchingItem> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktUserWatchingItem));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieReader = new TraktMovieObjectJsonReader();
                var showReader = new TraktShowObjectJsonReader();
                var episodeReader = new TraktEpisodeObjectJsonReader();
                ITraktUserWatchingItem traktUserWatchingItem = new TraktUserWatchingItem();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_STARTED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktUserWatchingItem.StartedAt = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_EXPIRES_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktUserWatchingItem.ExpiresAt = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_ACTION:
                            traktUserWatchingItem.Action = await JsonReaderHelper.ReadEnumerationValueAsync<TraktHistoryActionType>(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_TYPE:
                            traktUserWatchingItem.Type = await JsonReaderHelper.ReadEnumerationValueAsync<TraktSyncType>(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_MOVIE:
                            traktUserWatchingItem.Movie = await movieReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_SHOW:
                            traktUserWatchingItem.Show = await showReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_EPISODE:
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
