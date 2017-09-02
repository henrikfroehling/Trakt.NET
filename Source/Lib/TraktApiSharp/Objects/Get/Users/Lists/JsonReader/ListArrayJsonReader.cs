namespace TraktApiSharp.Objects.Get.Users.Lists.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ListArrayJsonReader : IArrayJsonReader<ITraktList>
    {
        public Task<IEnumerable<ITraktList>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktList>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktList>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktList>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktList>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktList>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var listReader = new TraktListObjectJsonReader();
                //var listReadingTasks = new List<Task<ITraktList>>();
                var lists = new List<ITraktList>();

                //listReadingTasks.Add(listReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktList list = await listReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (list != null)
                {
                    lists.Add(list);
                    //listReadingTasks.Add(listReader.ReadObjectAsync(jsonReader, cancellationToken));
                    list = await listReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readLists = await Task.WhenAll(listReadingTasks);
                //return (IEnumerable<ITraktList>)readLists.GetEnumerator();
                return lists;
            }

            return await Task.FromResult(default(IEnumerable<ITraktList>));
        }
    }
}
