namespace TraktApiSharp.Objects.Get.Users.Statistics.Json.Reader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserMoviesStatisticsObjectJsonReader : IObjectJsonReader<ITraktUserMoviesStatistics>
    {
        public Task<ITraktUserMoviesStatistics> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktUserMoviesStatistics));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktUserMoviesStatistics> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktUserMoviesStatistics));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktUserMoviesStatistics> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktUserMoviesStatistics));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktUserMoviesStatistics userMoviesStatistics = new TraktUserMoviesStatistics();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.USER_MOVIES_STATISTICS_PROPERTY_NAME_PLAYS:
                            userMoviesStatistics.Plays = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.USER_MOVIES_STATISTICS_PROPERTY_NAME_WATCHED:
                            userMoviesStatistics.Watched = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.USER_MOVIES_STATISTICS_PROPERTY_NAME_MINUTES:
                            userMoviesStatistics.Minutes = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.USER_MOVIES_STATISTICS_PROPERTY_NAME_COLLECTED:
                            userMoviesStatistics.Collected = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.USER_MOVIES_STATISTICS_PROPERTY_NAME_RATINGS:
                            userMoviesStatistics.Ratings = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.USER_MOVIES_STATISTICS_PROPERTY_NAME_COMMENTS:
                            userMoviesStatistics.Comments = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return userMoviesStatistics;
            }

            return await Task.FromResult(default(ITraktUserMoviesStatistics));
        }
    }
}
