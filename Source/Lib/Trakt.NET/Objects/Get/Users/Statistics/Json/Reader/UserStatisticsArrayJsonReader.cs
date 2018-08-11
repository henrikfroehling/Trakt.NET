namespace TraktNet.Objects.Get.Users.Statistics.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserStatisticsArrayJsonReader : AArrayJsonReader<ITraktUserStatistics>
    {
        public override async Task<IEnumerable<ITraktUserStatistics>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserStatistics>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userStatisticsReader = new UserStatisticsObjectJsonReader();
                var userStatisticss = new List<ITraktUserStatistics>();
                ITraktUserStatistics userStatistics = await userStatisticsReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userStatistics != null)
                {
                    userStatisticss.Add(userStatistics);
                    userStatistics = await userStatisticsReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return userStatisticss;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserStatistics>));
        }
    }
}
