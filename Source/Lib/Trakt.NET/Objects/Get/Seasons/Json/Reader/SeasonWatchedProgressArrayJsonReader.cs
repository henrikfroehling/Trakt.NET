namespace TraktNet.Objects.Get.Seasons.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SeasonWatchedProgressArrayJsonReader : ArrayJsonReader<ITraktSeasonWatchedProgress>
    {
        public override async Task<IEnumerable<ITraktSeasonWatchedProgress>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSeasonWatchedProgress>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var seasonWatchedProgressReader = new SeasonWatchedProgressObjectJsonReader();
                var traktSeasonWatchedProgresses = new List<ITraktSeasonWatchedProgress>();
                ITraktSeasonWatchedProgress traktSeasonWatchedProgress = await seasonWatchedProgressReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktSeasonWatchedProgress != null)
                {
                    traktSeasonWatchedProgresses.Add(traktSeasonWatchedProgress);
                    traktSeasonWatchedProgress = await seasonWatchedProgressReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return traktSeasonWatchedProgresses;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSeasonWatchedProgress>));
        }
    }
}
