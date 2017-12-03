namespace TraktApiSharp.Objects.Get.Seasons.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SeasonWatchedProgressArrayJsonReader : IArrayJsonReader<ITraktSeasonWatchedProgress>
    {
        public Task<IEnumerable<ITraktSeasonWatchedProgress>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktSeasonWatchedProgress>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktSeasonWatchedProgress>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktSeasonWatchedProgress>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktSeasonWatchedProgress>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
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
