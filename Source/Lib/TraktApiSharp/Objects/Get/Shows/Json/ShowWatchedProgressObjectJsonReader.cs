namespace TraktApiSharp.Objects.Get.Shows.Json
{
    using Episodes.Json;
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Json;
    using Seasons.Json;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ShowWatchedProgressObjectJsonReader : IObjectJsonReader<ITraktShowWatchedProgress>
    {
        private const string PROPERTY_NAME_AIRED = "aired";
        private const string PROPERTY_NAME_COMPLETED = "completed";
        private const string PROPERTY_NAME_LAST_WATCHED_AT = "last_watched_at";
        private const string PROPERTY_NAME_SEASONS = "seasons";
        private const string PROPERTY_NAME_HIDDEN_SEASONS = "hidden_seasons";
        private const string PROPERTY_NAME_NEXT_EPISODE = "next_episode";
        private const string PROPERTY_NAME_LAST_EPISODE = "last_episode";

        public Task<ITraktShowWatchedProgress> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktShowWatchedProgress));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktShowWatchedProgress> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktShowWatchedProgress));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktShowWatchedProgress> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktShowWatchedProgress));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var seasonsArrayReader = new SeasonArrayJsonReader();
                var seasonWatchedProgressArrayReader = new SeasonWatchedProgressArrayJsonReader();
                var episodeObjectReader = new EpisodeObjectJsonReader();

                ITraktShowWatchedProgress traktShowWatchedProgress = new TraktShowWatchedProgress();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_AIRED:
                            traktShowWatchedProgress.Aired = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case PROPERTY_NAME_COMPLETED:
                            traktShowWatchedProgress.Completed = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case PROPERTY_NAME_LAST_WATCHED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktShowWatchedProgress.LastWatchedAt = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_SEASONS:
                            traktShowWatchedProgress.Seasons = await seasonWatchedProgressArrayReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_HIDDEN_SEASONS:
                            traktShowWatchedProgress.HiddenSeasons = await seasonsArrayReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_NEXT_EPISODE:
                            traktShowWatchedProgress.NextEpisode = await episodeObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_LAST_EPISODE:
                            traktShowWatchedProgress.LastEpisode = await episodeObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktShowWatchedProgress;
            }

            return await Task.FromResult(default(ITraktShowWatchedProgress));
        }
    }
}
