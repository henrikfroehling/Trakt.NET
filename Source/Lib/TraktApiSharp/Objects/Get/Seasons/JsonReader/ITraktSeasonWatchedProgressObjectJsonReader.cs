namespace TraktApiSharp.Objects.Get.Seasons.JsonReader
{
    using Episodes.JsonReader;
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ITraktSeasonWatchedProgressObjectJsonReader : ITraktObjectJsonReader<ITraktSeasonWatchedProgress>
    {
        private const string PROPERTY_NAME_NUMBER = "number";
        private const string PROPERTY_NAME_AIRED = "aired";
        private const string PROPERTY_NAME_COMPLETED = "completed";
        private const string PROPERTY_NAME_EPISODES = "episodes";

        public Task<ITraktSeasonWatchedProgress> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktSeasonWatchedProgress> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return null;

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var episodeWatchedProgressArrayReader = new ITraktEpisodeWatchedProgressArrayJsonReader();
                ITraktSeasonWatchedProgress traktSeasonWatchedProgress = new TraktSeasonWatchedProgress();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_NUMBER:
                            traktSeasonWatchedProgress.Number = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case PROPERTY_NAME_AIRED:
                            traktSeasonWatchedProgress.Aired = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case PROPERTY_NAME_COMPLETED:
                            traktSeasonWatchedProgress.Completed = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case PROPERTY_NAME_EPISODES:
                            traktSeasonWatchedProgress.Episodes = await episodeWatchedProgressArrayReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktSeasonWatchedProgress;
            }

            return null;
        }
    }
}
