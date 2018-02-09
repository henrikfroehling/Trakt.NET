namespace TraktApiSharp.Objects.Get.Shows.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RecentlyUpdatedShowArrayJsonWriter : AArrayJsonWriter<ITraktRecentlyUpdatedShow>
    {
        public override async Task WriteArrayAsync(JsonTextWriter jsonWriter, IEnumerable<ITraktRecentlyUpdatedShow> objects, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            var recentlyUpdatedShowObjectJsonWriter = new RecentlyUpdatedShowObjectJsonWriter();
            var writerTasks = new List<Task>();
            await jsonWriter.WriteStartArrayAsync(cancellationToken).ConfigureAwait(false);

            foreach (ITraktRecentlyUpdatedShow traktRecentlyUpdatedShow in objects)
                writerTasks.Add(recentlyUpdatedShowObjectJsonWriter.WriteObjectAsync(jsonWriter, traktRecentlyUpdatedShow, cancellationToken));

            await Task.WhenAll(writerTasks).ConfigureAwait(false);
            await jsonWriter.WriteEndArrayAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
