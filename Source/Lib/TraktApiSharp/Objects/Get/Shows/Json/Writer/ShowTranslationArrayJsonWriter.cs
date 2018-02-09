namespace TraktApiSharp.Objects.Get.Shows.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ShowTranslationArrayJsonWriter : AArrayJsonWriter<ITraktShowTranslation>
    {
        public override async Task WriteArrayAsync(JsonTextWriter jsonWriter, IEnumerable<ITraktShowTranslation> objects, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            var showTranslationObjectJsonWriter = new ShowTranslationObjectJsonWriter();
            var writerTasks = new List<Task>();
            await jsonWriter.WriteStartArrayAsync(cancellationToken).ConfigureAwait(false);

            foreach (ITraktShowTranslation traktShowTranslation in objects)
                writerTasks.Add(showTranslationObjectJsonWriter.WriteObjectAsync(jsonWriter, traktShowTranslation, cancellationToken));

            await Task.WhenAll(writerTasks).ConfigureAwait(false);
            await jsonWriter.WriteEndArrayAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
