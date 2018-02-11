namespace TraktApiSharp.Objects.Get.People.Credits.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PersonMovieCreditsCrewItemArrayJsonWriter : AArrayJsonWriter<ITraktPersonMovieCreditsCrewItem>
    {
        public override async Task WriteArrayAsync(JsonTextWriter jsonWriter, IEnumerable<ITraktPersonMovieCreditsCrewItem> objects, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            var personMovieCreditsCrewItemObjectJsonWriter = new PersonMovieCreditsCrewItemObjectJsonWriter();
            var writerTasks = new List<Task>();
            await jsonWriter.WriteStartArrayAsync(cancellationToken).ConfigureAwait(false);

            foreach (ITraktPersonMovieCreditsCrewItem personMovieCreditsCrewItem in objects)
                writerTasks.Add(personMovieCreditsCrewItemObjectJsonWriter.WriteObjectAsync(jsonWriter, personMovieCreditsCrewItem, cancellationToken));

            await Task.WhenAll(writerTasks).ConfigureAwait(false);
            await jsonWriter.WriteEndArrayAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
