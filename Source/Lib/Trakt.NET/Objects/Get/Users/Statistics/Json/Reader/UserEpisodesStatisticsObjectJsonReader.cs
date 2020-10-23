namespace TraktNet.Objects.Get.Users.Statistics.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserEpisodesStatisticsObjectJsonReader : AObjectJsonReader<ITraktUserEpisodesStatistics>
    {
        public override async Task<ITraktUserEpisodesStatistics> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktUserEpisodesStatistics userEpisodesStatistics = new TraktUserEpisodesStatistics();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_PLAYS:
                            userEpisodesStatistics.Plays = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_WATCHED:
                            userEpisodesStatistics.Watched = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_MINUTES:
                            userEpisodesStatistics.Minutes = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_COLLECTED:
                            userEpisodesStatistics.Collected = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_RATINGS:
                            userEpisodesStatistics.Ratings = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_COMMENTS:
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
