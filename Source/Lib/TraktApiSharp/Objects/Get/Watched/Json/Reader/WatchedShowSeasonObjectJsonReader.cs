namespace TraktApiSharp.Objects.Get.Watched.Json.Reader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class WatchedShowSeasonObjectJsonReader : IObjectJsonReader<ITraktWatchedShowSeason>
    {
        public Task<ITraktWatchedShowSeason> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktWatchedShowSeason));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktWatchedShowSeason> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktWatchedShowSeason));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktWatchedShowSeason> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktWatchedShowSeason));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var watchedShowEpisodeArrayReader = new WatchedShowEpisodeArrayJsonReader();

                ITraktWatchedShowSeason traktWatchedShowSeason = new TraktWatchedShowSeason();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.WATCHED_SHOW_SEASON_PROPERTY_NAME_NUMBER:
                            traktWatchedShowSeason.Number = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.WATCHED_SHOW_SEASON_PROPERTY_NAME_EPISODES:
                            traktWatchedShowSeason.Episodes = await watchedShowEpisodeArrayReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktWatchedShowSeason;
            }

            return await Task.FromResult(default(ITraktWatchedShowSeason));
        }
    }
}
