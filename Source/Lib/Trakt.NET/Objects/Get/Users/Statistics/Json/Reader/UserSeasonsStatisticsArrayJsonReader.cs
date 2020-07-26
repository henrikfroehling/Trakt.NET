namespace TraktNet.Objects.Get.Users.Statistics.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserSeasonsStatisticsArrayJsonReader : ArrayJsonReader<ITraktUserSeasonsStatistics>
    {
        public override async Task<IEnumerable<ITraktUserSeasonsStatistics>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserSeasonsStatistics>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userSeasonsStatisticsReader = new UserSeasonsStatisticsObjectJsonReader();
                var userSeasonsStatisticss = new List<ITraktUserSeasonsStatistics>();
                ITraktUserSeasonsStatistics userSeasonsStatistics = await userSeasonsStatisticsReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userSeasonsStatistics != null)
                {
                    userSeasonsStatisticss.Add(userSeasonsStatistics);
                    userSeasonsStatistics = await userSeasonsStatisticsReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return userSeasonsStatisticss;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserSeasonsStatistics>));
        }
    }
}
