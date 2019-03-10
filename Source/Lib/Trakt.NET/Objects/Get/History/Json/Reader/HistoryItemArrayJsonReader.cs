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
                var historyItems = new List<ITraktHistoryItem>();
                ITraktHistoryItem historyItem = await historyItemReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (historyItem != null)
                {
                    historyItems.Add(historyItem);
                    historyItem = await historyItemReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return historyItems;
            }

            return await Task.FromResult(default(IEnumerable<ITraktHistoryItem>));
        }
    }
}
