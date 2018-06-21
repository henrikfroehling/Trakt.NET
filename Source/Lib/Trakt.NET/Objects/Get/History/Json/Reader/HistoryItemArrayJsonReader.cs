namespace TraktNet.Objects.Get.History.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class HistoryItemArrayJsonReader : AArrayJsonReader<ITraktHistoryItem>
    {
        public override async Task<IEnumerable<ITraktHistoryItem>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
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
