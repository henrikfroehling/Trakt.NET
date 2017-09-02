namespace TraktApiSharp.Objects.Get.History.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class HistoryItemArrayJsonReader : IArrayJsonReader<ITraktHistoryItem>
    {
        public Task<IEnumerable<ITraktHistoryItem>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktHistoryItem>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktHistoryItem>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktHistoryItem>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktHistoryItem>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktHistoryItem>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var historyItemReader = new HistoryItemObjectJsonReader();
                //var historyItemReadingTasks = new List<Task<ITraktHistoryItem>>();
                var historyItems = new List<ITraktHistoryItem>();

                //historyItemReadingTasks.Add(historyItemReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktHistoryItem historyItem = await historyItemReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (historyItem != null)
                {
                    historyItems.Add(historyItem);
                    //historyItemReadingTasks.Add(historyItemReader.ReadObjectAsync(jsonReader, cancellationToken));
                    historyItem = await historyItemReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readHistoryItems = await Task.WhenAll(historyItemReadingTasks);
                //return (IEnumerable<ITraktHistoryItem>)readHistoryItems.GetEnumerator();
                return historyItems;
            }

            return await Task.FromResult(default(IEnumerable<ITraktHistoryItem>));
        }
    }
}
