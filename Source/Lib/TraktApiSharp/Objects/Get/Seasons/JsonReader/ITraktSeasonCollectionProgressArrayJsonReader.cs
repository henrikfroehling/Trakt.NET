namespace TraktApiSharp.Objects.Get.Seasons.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ITraktSeasonCollectionProgressArrayJsonReader : ITraktArrayJsonReader<ITraktSeasonCollectionProgress>
    {
        public Task<IEnumerable<ITraktSeasonCollectionProgress>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktSeasonCollectionProgress>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return null;

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var seasonCollectionProgressReader = new ITraktSeasonCollectionProgressObjectJsonReader();
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

            return null;
        }
    }
}
