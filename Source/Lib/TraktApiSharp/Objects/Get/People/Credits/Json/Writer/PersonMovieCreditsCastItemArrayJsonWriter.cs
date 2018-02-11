namespace TraktApiSharp.Objects.Get.People.Credits.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PersonMovieCreditsCastItemArrayJsonWriter : AArrayJsonWriter<ITraktPersonMovieCreditsCastItem>
    {
        public override async Task WriteArrayAsync(JsonTextWriter jsonWriter, IEnumerable<ITraktPersonMovieCreditsCastItem> objects, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            var personMovieCreditsCastItemObjectJsonWriter = new PersonMovieCreditsCastItemObjectJsonWriter();
            var writerTasks = new List<Task>();
            await jsonWriter.WriteStartArrayAsync(cancellationToken).ConfigureAwait(false);

            foreach (ITraktPersonMovieCreditsCastItem personMovieCreditsCastItem in objects)
                writerTasks.Add(personMovieCreditsCastItemObjectJsonWriter.WriteObjectAsync(jsonWriter, personMovieCreditsCastItem, cancellationToken));

            await Task.WhenAll(writerTasks).ConfigureAwait(false);
            await jsonWriter.WriteEndArrayAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
