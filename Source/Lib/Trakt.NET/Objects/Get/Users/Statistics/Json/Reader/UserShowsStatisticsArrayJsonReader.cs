namespace TraktNet.Objects.Get.Users.Statistics.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserShowsStatisticsArrayJsonReader : AArrayJsonReader<ITraktUserShowsStatistics>
    {
        public override async Task<IEnumerable<ITraktUserShowsStatistics>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserShowsStatistics>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userShowsStatisticsReader = new UserShowsStatisticsObjectJsonReader();
                var userShowsStatisticss = new List<ITraktUserShowsStatistics>();
                ITraktUserShowsStatistics userShowsStatistics = await userShowsStatisticsReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userShowsStatistics != null)
                {
                    userShowsStatisticss.Add(userShowsStatistics);
                    userShowsStatistics = await userShowsStatisticsReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return userShowsStatisticss;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserShowsStatistics>));
        }
    }
}
