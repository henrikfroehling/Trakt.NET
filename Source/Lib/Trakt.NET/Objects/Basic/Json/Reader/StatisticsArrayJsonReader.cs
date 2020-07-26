namespace TraktNet.Objects.Basic.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class StatisticsArrayJsonReader : ArrayJsonReader<ITraktStatistics>
    {
        public override async Task<IEnumerable<ITraktStatistics>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktStatistics>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var statisticsReader = new StatisticsObjectJsonReader();
                var statisticss = new List<ITraktStatistics>();
                ITraktStatistics statistics = await statisticsReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (statistics != null)
                {
                    statisticss.Add(statistics);
                    statistics = await statisticsReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return statisticss;
            }

            return await Task.FromResult(default(IEnumerable<ITraktStatistics>));
        }
    }
}
