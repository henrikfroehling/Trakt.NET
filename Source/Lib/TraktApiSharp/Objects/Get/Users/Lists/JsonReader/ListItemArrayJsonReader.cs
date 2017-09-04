namespace TraktApiSharp.Objects.Get.Users.Lists.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ListItemArrayJsonReader : IArrayJsonReader<ITraktListItem>
    {
        public Task<IEnumerable<ITraktListItem>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktListItem>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktListItem>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktListItem>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktListItem>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktListItem>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var listItemReader = new ListItemObjectJsonReader();
                //var listItemReadingTasks = new List<Task<ITraktListItem>>();
                var listItems = new List<ITraktListItem>();

                //listItemReadingTasks.Add(listItemReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktListItem listItem = await listItemReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (listItem != null)
                {
                    listItems.Add(listItem);
                    //listItemReadingTasks.Add(listItemReader.ReadObjectAsync(jsonReader, cancellationToken));
                    listItem = await listItemReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readListItems = await Task.WhenAll(listItemReadingTasks);
                //return (IEnumerable<ITraktListItem>)readListItems.GetEnumerator();
                return listItems;
            }

            return await Task.FromResult(default(IEnumerable<ITraktListItem>));
        }
    }
}
