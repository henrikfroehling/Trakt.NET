namespace TraktApiSharp.Objects.Get.Seasons.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SeasonArrayJsonWriter : AArrayJsonWriter<ITraktSeason>
    {
        public override async Task WriteArrayAsync(JsonTextWriter jsonWriter, IEnumerable<ITraktSeason> objects, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            var seasonObjectJsonWriter = new SeasonObjectJsonWriter();
            await jsonWriter.WriteStartArrayAsync(cancellationToken);

            foreach (ITraktSeason traktSeason in objects)
                await seasonObjectJsonWriter.WriteObjectAsync(jsonWriter, traktSeason, cancellationToken);

            await jsonWriter.WriteEndArrayAsync(cancellationToken);
        }
    }
}
