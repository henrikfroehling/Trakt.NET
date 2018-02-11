namespace TraktApiSharp.Objects.Get.History.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class HistoryItemArrayJsonWriter : AArrayJsonWriter<ITraktHistoryItem>
    {
        public override async Task WriteArrayAsync(JsonTextWriter jsonWriter, IEnumerable<ITraktHistoryItem> objects, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            var historyItemObjectJsonWriter = new HistoryItemObjectJsonWriter();
            var writerTasks = new List<Task>();
            await jsonWriter.WriteStartArrayAsync(cancellationToken).ConfigureAwait(false);

            foreach (ITraktHistoryItem traktHistoryItem in objects)
                writerTasks.Add(historyItemObjectJsonWriter.WriteObjectAsync(jsonWriter, traktHistoryItem, cancellationToken));

            await Task.WhenAll(writerTasks).ConfigureAwait(false);
            await jsonWriter.WriteEndArrayAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
