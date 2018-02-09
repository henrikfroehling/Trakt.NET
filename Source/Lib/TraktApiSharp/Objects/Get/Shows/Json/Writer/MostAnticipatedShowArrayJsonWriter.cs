namespace TraktApiSharp.Objects.Get.Shows.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MostAnticipatedShowArrayJsonWriter : AArrayJsonWriter<ITraktMostAnticipatedShow>
    {
        public override async Task WriteArrayAsync(JsonTextWriter jsonWriter, IEnumerable<ITraktMostAnticipatedShow> objects, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            var mostAnticipatedShowObjectJsonWriter = new MostAnticipatedShowObjectJsonWriter();
            var writerTasks = new List<Task>();
            await jsonWriter.WriteStartArrayAsync(cancellationToken).ConfigureAwait(false);

            foreach (ITraktMostAnticipatedShow traktMostAnticipatedShow in objects)
                writerTasks.Add(mostAnticipatedShowObjectJsonWriter.WriteObjectAsync(jsonWriter, traktMostAnticipatedShow, cancellationToken));

            await Task.WhenAll(writerTasks).ConfigureAwait(false);
            await jsonWriter.WriteEndArrayAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
