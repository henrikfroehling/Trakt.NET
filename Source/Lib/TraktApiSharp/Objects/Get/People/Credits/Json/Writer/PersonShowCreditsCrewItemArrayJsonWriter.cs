namespace TraktApiSharp.Objects.Get.People.Credits.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PersonShowCreditsCrewItemArrayJsonWriter : AArrayJsonWriter<ITraktPersonShowCreditsCrewItem>
    {
        public override async Task WriteArrayAsync(JsonTextWriter jsonWriter, IEnumerable<ITraktPersonShowCreditsCrewItem> objects, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            var personShowCreditsCrewItemObjectJsonWriter = new PersonShowCreditsCrewItemObjectJsonWriter();
            var writerTasks = new List<Task>();
            await jsonWriter.WriteStartArrayAsync(cancellationToken).ConfigureAwait(false);

            foreach (ITraktPersonShowCreditsCrewItem personShowCreditsCrewItem in objects)
                writerTasks.Add(personShowCreditsCrewItemObjectJsonWriter.WriteObjectAsync(jsonWriter, personShowCreditsCrewItem, cancellationToken));

            await Task.WhenAll(writerTasks).ConfigureAwait(false);
            await jsonWriter.WriteEndArrayAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
