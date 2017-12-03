namespace TraktApiSharp.Objects.Get.Users.Statistics.Json.Reader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserEpisodesStatisticsObjectJsonReader : IObjectJsonReader<ITraktUserEpisodesStatistics>
    {
        public Task<ITraktUserEpisodesStatistics> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktUserEpisodesStatistics));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktUserEpisodesStatistics> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktUserEpisodesStatistics));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktUserEpisodesStatistics> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktUserEpisodesStatistics));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktUserEpisodesStatistics userEpisodesStatistics = new TraktUserEpisodesStatistics();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.USER_EPISODES_STATISTICS_PROPERTY_NAME_PLAYS:
                            userEpisodesStatistics.Plays = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.USER_EPISODES_STATISTICS_PROPERTY_NAME_WATCHED:
                            userEpisodesStatistics.Watched = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.USER_EPISODES_STATISTICS_PROPERTY_NAME_MINUTES:
                            userEpisodesStatistics.Minutes = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.USER_EPISODES_STATISTICS_PROPERTY_NAME_COLLECTED:
                            userEpisodesStatistics.Collected = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.USER_EPISODES_STATISTICS_PROPERTY_NAME_RATINGS:
                            userEpisodesStatistics.Ratings = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.USER_EPISODES_STATISTICS_PROPERTY_NAME_COMMENTS:
                            userEpisodesStatistics.Comments = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return userEpisodesStatistics;
            }

            return await Task.FromResult(default(ITraktUserEpisodesStatistics));
        }
    }
}
