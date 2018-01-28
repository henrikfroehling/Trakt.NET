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
            await jsonWriter.WriteStartArrayAsync(cancellationToken);

            foreach (ITraktSeasonCollectionProgress traktSeasonCollectionProgress in objects)
                await seasonCollectionProgressObjectJsonWriter.WriteObjectAsync(jsonWriter, traktSeasonCollectionProgress, cancellationToken);

            await jsonWriter.WriteEndArrayAsync(cancellationToken);
        }
    }
}
