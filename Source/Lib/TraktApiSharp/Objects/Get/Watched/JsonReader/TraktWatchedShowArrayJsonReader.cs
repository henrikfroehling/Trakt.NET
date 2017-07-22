namespace TraktApiSharp.Objects.Get.Watched.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TraktWatchedShowArrayJsonReader : ITraktArrayJsonReader<ITraktWatchedShow>
    {
        public Task<IEnumerable<ITraktWatchedShow>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktWatchedShow>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktWatchedShow>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktWatchedShow>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktWatchedShow>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktWatchedShow>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var watchedShowReader = new TraktWatchedShowObjectJsonReader();
                //var watchedShowReadingTasks = new List<Task<ITraktWatchedShow>>();
                var watchedShows = new List<ITraktWatchedShow>();

                //watchedShowReadingTasks.Add(watchedShowReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktWatchedShow watchedShow = await watchedShowReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (watchedShow != null)
                {
                    watchedShows.Add(watchedShow);
                    //watchedShowReadingTasks.Add(watchedShowReader.ReadObjectAsync(jsonReader, cancellationToken));
                    watchedShow = await watchedShowReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readWatchedShows = await Task.WhenAll(watchedShowReadingTasks);
                //return (IEnumerable<ITraktWatchedShow>)readWatchedShows.GetEnumerator();
                return watchedShows;
            }

            return await Task.FromResult(default(IEnumerable<ITraktWatchedShow>));
        }
    }
}
