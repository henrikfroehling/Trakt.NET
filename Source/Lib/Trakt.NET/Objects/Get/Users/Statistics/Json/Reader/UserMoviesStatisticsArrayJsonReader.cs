namespace TraktNet.Objects.Get.Users.Statistics.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserMoviesStatisticsArrayJsonReader : ArrayJsonReader<ITraktUserMoviesStatistics>
    {
        public override async Task<IEnumerable<ITraktUserMoviesStatistics>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserMoviesStatistics>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userMoviesStatisticsReader = new UserMoviesStatisticsObjectJsonReader();
                var userMoviesStatisticss = new List<ITraktUserMoviesStatistics>();
                ITraktUserMoviesStatistics userMoviesStatistics = await userMoviesStatisticsReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userMoviesStatistics != null)
                {
                    userMoviesStatisticss.Add(userMoviesStatistics);
                    userMoviesStatistics = await userMoviesStatisticsReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return userMoviesStatisticss;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserMoviesStatistics>));
        }
    }
}
