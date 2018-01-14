namespace TraktApiSharp.Objects.Get.Episodes.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class EpisodeCollectionProgressArrayJsonWriter : AArrayJsonWriter<ITraktEpisodeCollectionProgress>
    {
        public override async Task WriteArrayAsync(JsonTextWriter jsonWriter, IEnumerable<ITraktEpisodeCollectionProgress> objects, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            var episodeCollectionProgressObjectJsonWriter = new EpisodeCollectionProgressObjectJsonWriter();
            await jsonWriter.WriteStartArrayAsync(cancellationToken);

            foreach (ITraktEpisodeCollectionProgress traktEpisodeCollectionProgress in objects)
                await episodeCollectionProgressObjectJsonWriter.WriteObjectAsync(jsonWriter, traktEpisodeCollectionProgress, cancellationToken);

            await jsonWriter.WriteEndArrayAsync(cancellationToken);
        }
    }
}
