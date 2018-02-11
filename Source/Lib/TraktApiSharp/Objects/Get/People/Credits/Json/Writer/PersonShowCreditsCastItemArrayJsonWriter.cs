namespace TraktApiSharp.Objects.Get.People.Credits.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PersonShowCreditsCastItemArrayJsonWriter : AArrayJsonWriter<ITraktPersonShowCreditsCastItem>
    {
        public override async Task WriteArrayAsync(JsonTextWriter jsonWriter, IEnumerable<ITraktPersonShowCreditsCastItem> objects, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            var personShowCreditsCastItemObjectJsonWriter = new PersonShowCreditsCastItemObjectJsonWriter();
            var writerTasks = new List<Task>();
            await jsonWriter.WriteStartArrayAsync(cancellationToken).ConfigureAwait(false);

            foreach (ITraktPersonShowCreditsCastItem personShowCreditsCastItem in objects)
                writerTasks.Add(personShowCreditsCastItemObjectJsonWriter.WriteObjectAsync(jsonWriter, personShowCreditsCastItem, cancellationToken));

            await Task.WhenAll(writerTasks).ConfigureAwait(false);
            await jsonWriter.WriteEndArrayAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
