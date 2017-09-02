namespace TraktApiSharp.Objects.Get.Users.Statistics.JsonReader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserSeasonsStatisticsObjectJsonReader : IObjectJsonReader<ITraktUserSeasonsStatistics>
    {
        private const string PROPERTY_NAME_RATINGS = "ratings";
        private const string PROPERTY_NAME_COMMENTS = "comments";

        public Task<ITraktUserSeasonsStatistics> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktUserSeasonsStatistics));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktUserSeasonsStatistics> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktUserSeasonsStatistics));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktUserSeasonsStatistics> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktUserSeasonsStatistics));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktUserSeasonsStatistics userSeasonsStatistics = new TraktUserSeasonsStatistics();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_RATINGS:
                            userSeasonsStatistics.Ratings = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case PROPERTY_NAME_COMMENTS:
                            userSeasonsStatistics.Comments = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return userSeasonsStatistics;
            }

            return await Task.FromResult(default(ITraktUserSeasonsStatistics));
        }
    }
}
