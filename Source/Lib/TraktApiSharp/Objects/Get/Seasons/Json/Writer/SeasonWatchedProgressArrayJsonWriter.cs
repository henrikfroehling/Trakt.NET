namespace TraktApiSharp.Objects.Get.Seasons.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SeasonWatchedProgressArrayJsonWriter : AArrayJsonWriter<ITraktSeasonWatchedProgress>
    {
        public override async Task WriteArrayAsync(JsonTextWriter jsonWriter, IEnumerable<ITraktSeasonWatchedProgress> objects, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            var seasonWatchedProgressObjectJsonWriter = new SeasonWatchedProgressObjectJsonWriter();
            await jsonWriter.WriteStartArrayAsync(cancellationToken);

            foreach (ITraktSeasonWatchedProgress traktSeasonWatchedProgress in objects)
                await seasonWatchedProgressObjectJsonWriter.WriteObjectAsync(jsonWriter, traktSeasonWatchedProgress, cancellationToken);

            await jsonWriter.WriteEndArrayAsync(cancellationToken);
        }
    }
}
