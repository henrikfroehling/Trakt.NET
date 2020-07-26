namespace TraktNet.Objects.Get.Users.Statistics.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserRatingsStatisticsArrayJsonReader : ArrayJsonReader<ITraktUserRatingsStatistics>
    {
        public override async Task<IEnumerable<ITraktUserRatingsStatistics>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserRatingsStatistics>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userRatingsStatisticsReader = new UserRatingsStatisticsObjectJsonReader();
                var userRatingsStatisticss = new List<ITraktUserRatingsStatistics>();
                ITraktUserRatingsStatistics userRatingsStatistics = await userRatingsStatisticsReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userRatingsStatistics != null)
                {
                    userRatingsStatisticss.Add(userRatingsStatistics);
                    userRatingsStatistics = await userRatingsStatisticsReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return userRatingsStatisticss;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserRatingsStatistics>));
        }
    }
}
