namespace TraktApiSharp.Objects.Get.Users.Statistics.Json.Reader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserSeasonsStatisticsObjectJsonReader : AObjectJsonReader<ITraktUserSeasonsStatistics>
    {
        public override async Task<ITraktUserSeasonsStatistics> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
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
                        case JsonProperties.USER_SEASONS_STATISTICS_PROPERTY_NAME_RATINGS:
                            userSeasonsStatistics.Ratings = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.USER_SEASONS_STATISTICS_PROPERTY_NAME_COMMENTS:
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
