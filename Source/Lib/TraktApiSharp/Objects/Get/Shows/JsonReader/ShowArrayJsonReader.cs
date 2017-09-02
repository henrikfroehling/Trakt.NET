namespace TraktApiSharp.Objects.Get.Shows.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ShowArrayJsonReader : IArrayJsonReader<ITraktShow>
    {
        public Task<IEnumerable<ITraktShow>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktShow>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktShow>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktShow>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktShow>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktShow>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var movieReader = new ShowObjectJsonReader();
                //var traktShowReadingTasks = new List<Task<ITraktShow>>();
                var traktShows = new List<ITraktShow>();

                //traktShowReadingTasks.Add(movieReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktShow traktShow = await movieReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktShow != null)
                {
                    traktShows.Add(traktShow);
                    //traktShowReadingTasks.Add(movieReader.ReadObjectAsync(jsonReader, cancellationToken));
                    traktShow = await movieReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readShows = await Task.WhenAll(traktShowReadingTasks);
                //return (IEnumerable<ITraktShow>)readShows.GetEnumerator();
                return traktShows;
            }

            return await Task.FromResult(default(IEnumerable<ITraktShow>));
        }
    }
}
