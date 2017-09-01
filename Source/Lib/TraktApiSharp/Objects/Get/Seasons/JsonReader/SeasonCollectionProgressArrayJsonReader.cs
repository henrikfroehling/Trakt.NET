namespace TraktApiSharp.Objects.Get.Seasons.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SeasonCollectionProgressArrayJsonReader : IArrayJsonReader<ITraktSeasonCollectionProgress>
    {
        public Task<IEnumerable<ITraktSeasonCollectionProgress>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktSeasonCollectionProgress>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktSeasonCollectionProgress>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktSeasonCollectionProgress>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktSeasonCollectionProgress>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSeasonCollectionProgress>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var seasonCollectionProgressReader = new SeasonCollectionProgressObjectJsonReader();
                //var seasonCollectionProgressReadingTasks = new List<Task<ITraktSeasonCollectionProgress>>();
                var traktSeasonCollectionProgresses = new List<ITraktSeasonCollectionProgress>();

                //seasonCollectionProgressReadingTasks.Add(seasonCollectionProgressReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktSeasonCollectionProgress traktSeasonCollectionProgress = await seasonCollectionProgressReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktSeasonCollectionProgress != null)
                {
                    traktSeasonCollectionProgresses.Add(traktSeasonCollectionProgress);
                    //seasonCollectionProgressReadingTasks.Add(seasonCollectionProgressReader.ReadObjectAsync(jsonReader, cancellationToken));
                    traktSeasonCollectionProgress = await seasonCollectionProgressReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readSeasonCollectionProgresses = await Task.WhenAll(seasonCollectionProgressReadingTasks);
                //return (IEnumerable<ITraktSeasonCollectionProgress>)readSeasonCollectionProgresses.GetEnumerator();
                return traktSeasonCollectionProgresses;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSeasonCollectionProgress>));
        }
    }
}
