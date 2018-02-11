namespace TraktApiSharp.Objects.Get.Syncs.Playback.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncPlaybackProgressItemArrayJsonWriter : AArrayJsonWriter<ITraktSyncPlaybackProgressItem>
    {
        public override async Task WriteArrayAsync(JsonTextWriter jsonWriter, IEnumerable<ITraktSyncPlaybackProgressItem> objects, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            var syncPlaybackProgressItemObjectJsonWriter = new SyncPlaybackProgressItemObjectJsonWriter();
            var writerTasks = new List<Task>();
            await jsonWriter.WriteStartArrayAsync(cancellationToken).ConfigureAwait(false);

            foreach (ITraktSyncPlaybackProgressItem traktSyncPlaybackProgressItem in objects)
                writerTasks.Add(syncPlaybackProgressItemObjectJsonWriter.WriteObjectAsync(jsonWriter, traktSyncPlaybackProgressItem, cancellationToken));

            await Task.WhenAll(writerTasks).ConfigureAwait(false);
            await jsonWriter.WriteEndArrayAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
