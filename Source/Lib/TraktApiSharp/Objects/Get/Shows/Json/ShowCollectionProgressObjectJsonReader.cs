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

    internal class ShowCollectionProgressObjectJsonReader : IObjectJsonReader<ITraktShowCollectionProgress>
    {
        private const string PROPERTY_NAME_AIRED = "aired";
        private const string PROPERTY_NAME_COMPLETED = "completed";
        private const string PROPERTY_NAME_LAST_COLLECTED_AT = "last_collected_at";
        private const string PROPERTY_NAME_SEASONS = "seasons";
        private const string PROPERTY_NAME_HIDDEN_SEASONS = "hidden_seasons";
        private const string PROPERTY_NAME_NEXT_EPISODE = "next_episode";
        private const string PROPERTY_NAME_LAST_EPISODE = "last_episode";

        public Task<ITraktShowCollectionProgress> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktShowCollectionProgress));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktShowCollectionProgress> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktShowCollectionProgress));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktShowCollectionProgress> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktShowCollectionProgress));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var seasonsArrayReader = new SeasonArrayJsonReader();
                var seasonCollectionProgressArrayReader = new SeasonCollectionProgressArrayJsonReader();
                var episodeObjectReader = new EpisodeObjectJsonReader();

                ITraktShowCollectionProgress traktShowCollectionProgress = new TraktShowCollectionProgress();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_AIRED:
                            traktShowCollectionProgress.Aired = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case PROPERTY_NAME_COMPLETED:
                            traktShowCollectionProgress.Completed = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case PROPERTY_NAME_LAST_COLLECTED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktShowCollectionProgress.LastCollectedAt = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_SEASONS:
                            traktShowCollectionProgress.Seasons = await seasonCollectionProgressArrayReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_HIDDEN_SEASONS:
                            traktShowCollectionProgress.HiddenSeasons = await seasonsArrayReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_NEXT_EPISODE:
                            traktShowCollectionProgress.NextEpisode = await episodeObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_LAST_EPISODE:
                            traktShowCollectionProgress.LastEpisode = await episodeObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktShowCollectionProgress;
            }

            return await Task.FromResult(default(ITraktShowCollectionProgress));
        }
    }
}
