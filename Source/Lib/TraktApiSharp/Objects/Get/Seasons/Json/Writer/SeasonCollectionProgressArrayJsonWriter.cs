namespace TraktApiSharp.Objects.Get.Seasons.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SeasonCollectionProgressArrayJsonWriter : AArrayJsonWriter<ITraktSeasonCollectionProgress>
    {
        public override async Task WriteArrayAsync(JsonTextWriter jsonWriter, IEnumerable<ITraktSeasonCollectionProgress> objects, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            var seasonCollectionProgressObjectJsonWriter = new SeasonCollectionProgressObjectJsonWriter();
            var writerTasks = new List<Task>();
            await jsonWriter.WriteStartArrayAsync(cancellationToken).ConfigureAwait(false);

            foreach (ITraktSeasonCollectionProgress traktSeasonCollectionProgress in objects)
                writerTasks.Add(seasonCollectionProgressObjectJsonWriter.WriteObjectAsync(jsonWriter, traktSeasonCollectionProgress, cancellationToken));

            await Task.WhenAll(writerTasks).ConfigureAwait(false);
            await jsonWriter.WriteEndArrayAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
