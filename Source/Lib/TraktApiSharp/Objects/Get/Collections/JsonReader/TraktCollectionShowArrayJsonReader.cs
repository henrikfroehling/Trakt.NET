namespace TraktApiSharp.Objects.Get.Collections.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TraktCollectionShowArrayJsonReader : ITraktArrayJsonReader<ITraktCollectionShow>
    {
        public Task<IEnumerable<ITraktCollectionShow>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktCollectionShow>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktCollectionShow>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktCollectionShow>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktCollectionShow>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktCollectionShow>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var calendarShowReader = new TraktCollectionShowObjectJsonReader();
                //var calendarShowReadingTasks = new List<Task<ITraktCollectionShow>>();
                var calendarShows = new List<ITraktCollectionShow>();

                //calendarShowReadingTasks.Add(calendarShowReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktCollectionShow calendarShow = await calendarShowReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (calendarShow != null)
                {
                    calendarShows.Add(calendarShow);
                    //calendarShowReadingTasks.Add(calendarShowReader.ReadObjectAsync(jsonReader, cancellationToken));
                    calendarShow = await calendarShowReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readCollectionShows = await Task.WhenAll(calendarShowReadingTasks);
                //return (IEnumerable<ITraktCollectionShow>)readCollectionShows.GetEnumerator();
                return calendarShows;
            }

            return await Task.FromResult(default(IEnumerable<ITraktCollectionShow>));
        }
    }
}
