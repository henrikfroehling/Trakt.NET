namespace TraktApiSharp.Objects.Get.Seasons.JsonReader
{
    using Episodes.JsonReader;
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ITraktSeasonCollectionProgressObjectJsonReader : ITraktObjectJsonReader<ITraktSeasonCollectionProgress>
    {
        private const string PROPERTY_NAME_NUMBER = "number";
        private const string PROPERTY_NAME_AIRED = "aired";
        private const string PROPERTY_NAME_COMPLETED = "completed";
        private const string PROPERTY_NAME_EPISODES = "episodes";

        public Task<ITraktSeasonCollectionProgress> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktSeasonCollectionProgress));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktSeasonCollectionProgress> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktSeasonCollectionProgress));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktSeasonCollectionProgress> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktSeasonCollectionProgress));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var episodeCollectionProgressArrayReader = new TraktEpisodeCollectionProgressArrayJsonReader();
                ITraktSeasonCollectionProgress traktSeasonCollectionProgress = new TraktSeasonCollectionProgress();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_NUMBER:
                            traktSeasonCollectionProgress.Number = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case PROPERTY_NAME_AIRED:
                            traktSeasonCollectionProgress.Aired = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case PROPERTY_NAME_COMPLETED:
                            traktSeasonCollectionProgress.Completed = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case PROPERTY_NAME_EPISODES:
                            traktSeasonCollectionProgress.Episodes = await episodeCollectionProgressArrayReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktSeasonCollectionProgress;
            }

            return await Task.FromResult(default(ITraktSeasonCollectionProgress));
        }
    }
}
