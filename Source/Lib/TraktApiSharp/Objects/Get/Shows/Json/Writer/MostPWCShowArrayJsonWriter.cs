namespace TraktApiSharp.Objects.Get.Shows.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MostPWCShowArrayJsonWriter : AArrayJsonWriter<ITraktMostPWCShow>
    {
        public override async Task WriteArrayAsync(JsonTextWriter jsonWriter, IEnumerable<ITraktMostPWCShow> objects, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            var mostPWCShowObjectJsonWriter = new MostPWCShowObjectJsonWriter();
            var writerTasks = new List<Task>();
            await jsonWriter.WriteStartArrayAsync(cancellationToken).ConfigureAwait(false);

            foreach (ITraktMostPWCShow traktMostPWCShow in objects)
                writerTasks.Add(mostPWCShowObjectJsonWriter.WriteObjectAsync(jsonWriter, traktMostPWCShow, cancellationToken));

            await Task.WhenAll(writerTasks).ConfigureAwait(false);
            await jsonWriter.WriteEndArrayAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
