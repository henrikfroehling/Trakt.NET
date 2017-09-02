namespace TraktApiSharp.Objects.Get.Syncs.Playback.JsonReader
{
    using Episodes.JsonReader;
    using Implementations;
    using Movies.JsonReader;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using Shows.JsonReader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktApiSharp.Enums;

    internal class TraktSyncPlaybackProgressItemObjectJsonReader : IObjectJsonReader<ITraktSyncPlaybackProgressItem>
    {
        private const string PROPERTY_NAME_ID = "id";
        private const string PROPERTY_NAME_PROGRESS = "progress";
        private const string PROPERTY_NAME_PAUSED_AT = "paused_at";
        private const string PROPERTY_NAME_TYPE = "type";
        private const string PROPERTY_NAME_MOVIE = "movie";
        private const string PROPERTY_NAME_SHOW = "show";
        private const string PROPERTY_NAME_EPISODE = "episode";

        public Task<ITraktSyncPlaybackProgressItem> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktSyncPlaybackProgressItem));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktSyncPlaybackProgressItem> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktSyncPlaybackProgressItem));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktSyncPlaybackProgressItem> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktSyncPlaybackProgressItem));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieObjectReader = new MovieObjectJsonReader();
                var showObjectReader = new ShowObjectJsonReader();
                var episodeObjectReader = new EpisodeObjectJsonReader();

                ITraktSyncPlaybackProgressItem traktPlaybackProgressItem = new TraktSyncPlaybackProgressItem();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_ID:
                            {
                                var value = await JsonReaderHelper.ReadUnsignedIntegerValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktPlaybackProgressItem.Id = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_PROGRESS:
                            {
                                var value = await JsonReaderHelper.ReadFloatValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktPlaybackProgressItem.Progress = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_PAUSED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktPlaybackProgressItem.PausedAt = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_TYPE:
                            traktPlaybackProgressItem.Type = await JsonReaderHelper.ReadEnumerationValueAsync<TraktSyncType>(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_MOVIE:
                            traktPlaybackProgressItem.Movie = await movieObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_SHOW:
                            traktPlaybackProgressItem.Show = await showObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_EPISODE:
                            traktPlaybackProgressItem.Episode = await episodeObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktPlaybackProgressItem;
            }

            return await Task.FromResult(default(ITraktSyncPlaybackProgressItem));
        }
    }
}
