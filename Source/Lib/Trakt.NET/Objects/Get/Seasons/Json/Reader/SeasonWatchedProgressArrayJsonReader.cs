namespace TraktNet.Objects.Get.Seasons.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SeasonWatchedProgressArrayJsonReader : AArrayJsonReader<ITraktSeasonWatchedProgress>
    {
        public override async Task<IEnumerable<ITraktSeasonWatchedProgress>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSeasonWatchedProgress>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var seasonWatchedProgressReader = new SeasonWatchedProgressObjectJsonReader();
                //var seasonWatchedProgressReadingTasks = new List<Task<ITraktSeasonWatchedProgress>>();
                var traktSeasonWatchedProgresses = new List<ITraktSeasonWatchedProgress>();

                //seasonWatchedProgressReadingTasks.Add(seasonWatchedProgressReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktSeasonWatchedProgress traktSeasonWatchedProgress = await seasonWatchedProgressReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktSeasonWatchedProgress != null)
                {
                    traktSeasonWatchedProgresses.Add(traktSeasonWatchedProgress);
                    //seasonWatchedProgressReadingTasks.Add(seasonWatchedProgressReader.ReadObjectAsync(jsonReader, cancellationToken));
                    traktSeasonWatchedProgress = await seasonWatchedProgressReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readSeasonWatchedProgresses = await Task.WhenAll(seasonWatchedProgressReadingTasks);
                //return (IEnumerable<ITraktSeasonWatchedProgress>)readSeasonWatchedProgresses.GetEnumerator();
                return traktSeasonWatchedProgresses;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSeasonWatchedProgress>));
        }
    }
}
