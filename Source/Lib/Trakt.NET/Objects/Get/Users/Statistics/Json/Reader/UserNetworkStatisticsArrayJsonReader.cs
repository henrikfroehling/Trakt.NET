namespace TraktNet.Objects.Get.Users.Statistics.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserNetworkStatisticsArrayJsonReader : AArrayJsonReader<ITraktUserNetworkStatistics>
    {
        public override async Task<IEnumerable<ITraktUserNetworkStatistics>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserNetworkStatistics>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userNetworkStatisticsReader = new UserNetworkStatisticsObjectJsonReader();
                var userNetworkStatisticss = new List<ITraktUserNetworkStatistics>();
                ITraktUserNetworkStatistics userNetworkStatistics = await userNetworkStatisticsReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userNetworkStatistics != null)
                {
                    userNetworkStatisticss.Add(userNetworkStatistics);
                    userNetworkStatistics = await userNetworkStatisticsReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return userNetworkStatisticss;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserNetworkStatistics>));
        }
    }
}
