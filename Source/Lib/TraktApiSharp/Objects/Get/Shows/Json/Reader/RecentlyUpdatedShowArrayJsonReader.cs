namespace TraktApiSharp.Objects.Get.Shows.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RecentlyUpdatedShowArrayJsonReader : IArrayJsonReader<ITraktRecentlyUpdatedShow>
    {
        public Task<IEnumerable<ITraktRecentlyUpdatedShow>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktRecentlyUpdatedShow>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktRecentlyUpdatedShow>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktRecentlyUpdatedShow>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktRecentlyUpdatedShow>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktRecentlyUpdatedShow>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var recentlyUpdatedShowReader = new RecentlyUpdatedShowObjectJsonReader();
                //var traktRecentlyUpdatedShowReadingTasks = new List<Task<ITraktRecentlyUpdatedShow>>();
                var traktRecentlyUpdatedShows = new List<ITraktRecentlyUpdatedShow>();

                //traktRecentlyUpdatedShowReadingTasks.Add(recentlyUpdatedShowReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktRecentlyUpdatedShow traktRecentlyUpdatedShow = await recentlyUpdatedShowReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktRecentlyUpdatedShow != null)
                {
                    traktRecentlyUpdatedShows.Add(traktRecentlyUpdatedShow);
                    //traktRecentlyUpdatedShowReadingTasks.Add(recentlyUpdatedShowReader.ReadObjectAsync(jsonReader, cancellationToken));
                    traktRecentlyUpdatedShow = await recentlyUpdatedShowReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readRecentlyUpdatedShows = await Task.WhenAll(traktRecentlyUpdatedShowReadingTasks);
                //return (IEnumerable<ITraktRecentlyUpdatedShow>)readRecentlyUpdatedShows.GetEnumerator();
                return traktRecentlyUpdatedShows;
            }

            return await Task.FromResult(default(IEnumerable<ITraktRecentlyUpdatedShow>));
        }
    }
}
