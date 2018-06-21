namespace TraktNet.Objects.Get.Users.Statistics.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserShowsStatisticsObjectJsonReader : AObjectJsonReader<ITraktUserShowsStatistics>
    {
        public override async Task<ITraktUserShowsStatistics> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktUserShowsStatistics));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktUserShowsStatistics userShowsStatistics = new TraktUserShowsStatistics();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.USER_SHOWS_STATISTICS_PROPERTY_NAME_WATCHED:
                            userShowsStatistics.Watched = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.USER_SHOWS_STATISTICS_PROPERTY_NAME_COLLECTED:
                            userShowsStatistics.Collected = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.USER_SHOWS_STATISTICS_PROPERTY_NAME_RATINGS:
                            userShowsStatistics.Ratings = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.USER_SHOWS_STATISTICS_PROPERTY_NAME_COMMENTS:
                            userShowsStatistics.Comments = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return userShowsStatistics;
            }

            return await Task.FromResult(default(ITraktUserShowsStatistics));
        }
    }
}
