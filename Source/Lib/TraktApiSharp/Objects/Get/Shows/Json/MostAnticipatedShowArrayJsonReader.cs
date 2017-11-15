namespace TraktApiSharp.Objects.Get.Shows.Json
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MostAnticipatedShowArrayJsonReader : IArrayJsonReader<ITraktMostAnticipatedShow>
    {
        public Task<IEnumerable<ITraktMostAnticipatedShow>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktMostAnticipatedShow>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktMostAnticipatedShow>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktMostAnticipatedShow>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktMostAnticipatedShow>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktMostAnticipatedShow>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var mostAnticipatedShowReader = new MostAnticipatedShowObjectJsonReader();
                //var traktMostAnticipatedShowReadingTasks = new List<Task<ITraktMostAnticipatedShow>>();
                var traktMostAnticipatedShows = new List<ITraktMostAnticipatedShow>();

                //traktMostAnticipatedShowReadingTasks.Add(mostAnticipatedShowReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktMostAnticipatedShow traktMostAnticipatedShow = await mostAnticipatedShowReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktMostAnticipatedShow != null)
                {
                    traktMostAnticipatedShows.Add(traktMostAnticipatedShow);
                    //traktMostAnticipatedShowReadingTasks.Add(mostAnticipatedShowReader.ReadObjectAsync(jsonReader, cancellationToken));
                    traktMostAnticipatedShow = await mostAnticipatedShowReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readMostAnticipatedShows = await Task.WhenAll(traktMostAnticipatedShowReadingTasks);
                //return (IEnumerable<ITraktMostAnticipatedShow>)readMostAnticipatedShows.GetEnumerator();
                return traktMostAnticipatedShows;
            }

            return await Task.FromResult(default(IEnumerable<ITraktMostAnticipatedShow>));
        }
    }
}
