namespace TraktApiSharp.Objects.Get.Shows.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TrendingShowArrayJsonReader : IArrayJsonReader<ITraktTrendingShow>
    {
        public Task<IEnumerable<ITraktTrendingShow>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktTrendingShow>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktTrendingShow>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktTrendingShow>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktTrendingShow>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktTrendingShow>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var trendingShowReader = new TrendingShowObjectJsonReader();
                //var traktTrendingShowReadingTasks = new List<Task<ITraktTrendingShow>>();
                var traktTrendingShows = new List<ITraktTrendingShow>();

                //traktTrendingShowReadingTasks.Add(trendingShowReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktTrendingShow traktTrendingShow = await trendingShowReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktTrendingShow != null)
                {
                    traktTrendingShows.Add(traktTrendingShow);
                    //traktTrendingShowReadingTasks.Add(trendingShowReader.ReadObjectAsync(jsonReader, cancellationToken));
                    traktTrendingShow = await trendingShowReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readTrendingShows = await Task.WhenAll(traktTrendingShowReadingTasks);
                //return (IEnumerable<ITraktTrendingShow>)readTrendingShows.GetEnumerator();
                return traktTrendingShows;
            }

            return await Task.FromResult(default(IEnumerable<ITraktTrendingShow>));
        }
    }
}
