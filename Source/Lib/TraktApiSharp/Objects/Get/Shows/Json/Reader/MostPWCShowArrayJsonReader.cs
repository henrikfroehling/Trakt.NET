namespace TraktApiSharp.Objects.Get.Shows.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MostPWCShowArrayJsonReader : IArrayJsonReader<ITraktMostPWCShow>
    {
        public Task<IEnumerable<ITraktMostPWCShow>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktMostPWCShow>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktMostPWCShow>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktMostPWCShow>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktMostPWCShow>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktMostPWCShow>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var mostPWCShowReader = new MostPWCShowObjectJsonReader();
                //var traktMostPWCShowReadingTasks = new List<Task<ITraktMostPWCShow>>();
                var traktMostPWCShows = new List<ITraktMostPWCShow>();

                //traktMostPWCShowReadingTasks.Add(mostPWCShowReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktMostPWCShow traktMostPWCShow = await mostPWCShowReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktMostPWCShow != null)
                {
                    traktMostPWCShows.Add(traktMostPWCShow);
                    //traktMostPWCShowReadingTasks.Add(mostPWCShowReader.ReadObjectAsync(jsonReader, cancellationToken));
                    traktMostPWCShow = await mostPWCShowReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readMostPWCShows = await Task.WhenAll(traktMostPWCShowReadingTasks);
                //return (IEnumerable<ITraktMostPWCShow>)readMostPWCShows.GetEnumerator();
                return traktMostPWCShows;
            }

            return await Task.FromResult(default(IEnumerable<ITraktMostPWCShow>));
        }
    }
}
