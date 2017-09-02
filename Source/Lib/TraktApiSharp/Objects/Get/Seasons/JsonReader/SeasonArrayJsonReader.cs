namespace TraktApiSharp.Objects.Get.Seasons.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SeasonArrayJsonReader : IArrayJsonReader<ITraktSeason>
    {
        public Task<IEnumerable<ITraktSeason>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktSeason>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktSeason>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktSeason>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktSeason>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSeason>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var seasonReader = new SeasonObjectJsonReader();
                //var traktSeasonReadingTasks = new List<Task<ITraktSeason>>();
                var traktSeasons = new List<ITraktSeason>();

                //traktSeasonReadingTasks.Add(seasonReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktSeason traktSeason = await seasonReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktSeason != null)
                {
                    traktSeasons.Add(traktSeason);
                    //traktSeasonReadingTasks.Add(seasonReader.ReadObjectAsync(jsonReader, cancellationToken));
                    traktSeason = await seasonReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readSeasons = await Task.WhenAll(traktSeasonReadingTasks);
                //return (IEnumerable<ITraktSeason>)readSeasons.GetEnumerator();
                return traktSeasons;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSeason>));
        }
    }
}
