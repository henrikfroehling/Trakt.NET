namespace TraktNet.Objects.Get.Users.Statistics.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserSeasonsStatisticsObjectJsonReader : AObjectJsonReader<ITraktUserSeasonsStatistics>
    {
        public override async Task<ITraktUserSeasonsStatistics> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktUserSeasonsStatistics userSeasonsStatistics = new TraktUserSeasonsStatistics();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_RATINGS:
                            userSeasonsStatistics.Ratings = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_COMMENTS:
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
