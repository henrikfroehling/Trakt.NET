namespace TraktApiSharp.Objects.Get.Users.Statistics.JsonReader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserRatingsStatisticsObjectJsonReader : IObjectJsonReader<ITraktUserRatingsStatistics>
    {
        private const string PROPERTY_NAME_TOTAL = "total";
        private const string PROPERTY_NAME_DISTRIBUTION = "distribution";

        public Task<ITraktUserRatingsStatistics> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktUserRatingsStatistics));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktUserRatingsStatistics> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktUserRatingsStatistics));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktUserRatingsStatistics> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktUserRatingsStatistics));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktUserRatingsStatistics userRatingsStatistics = new TraktUserRatingsStatistics();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_TOTAL:
                            userRatingsStatistics.Total = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case PROPERTY_NAME_DISTRIBUTION:
                            userRatingsStatistics.Distribution = await JsonReaderHelper.ReadDistributionAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return userRatingsStatistics;
            }

            return await Task.FromResult(default(ITraktUserRatingsStatistics));
        }
    }
}
