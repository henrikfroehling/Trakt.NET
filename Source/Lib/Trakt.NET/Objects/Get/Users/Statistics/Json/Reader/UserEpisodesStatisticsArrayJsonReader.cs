namespace TraktNet.Objects.Get.Users.Statistics.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserEpisodesStatisticsArrayJsonReader : AArrayJsonReader<ITraktUserEpisodesStatistics>
    {
        public override async Task<IEnumerable<ITraktUserEpisodesStatistics>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserEpisodesStatistics>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userEpisodesStatisticsReader = new UserEpisodesStatisticsObjectJsonReader();
                var userEpisodesStatisticss = new List<ITraktUserEpisodesStatistics>();
                ITraktUserEpisodesStatistics userEpisodesStatistics = await userEpisodesStatisticsReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userEpisodesStatistics != null)
                {
                    userEpisodesStatisticss.Add(userEpisodesStatistics);
                    userEpisodesStatistics = await userEpisodesStatisticsReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return userEpisodesStatisticss;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserEpisodesStatistics>));
        }
    }
}
