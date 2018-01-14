namespace TraktApiSharp.Objects.Get.Episodes.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class EpisodeWatchedProgressArrayJsonWriter : AArrayJsonWriter<ITraktEpisodeWatchedProgress>
    {
        public override async Task WriteArrayAsync(JsonTextWriter jsonWriter, IEnumerable<ITraktEpisodeWatchedProgress> objects, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            var episodeWatchedProgressObjectJsonWriter = new EpisodeWatchedProgressObjectJsonWriter();
            await jsonWriter.WriteStartArrayAsync(cancellationToken);

            foreach (ITraktEpisodeWatchedProgress traktEpisodeWatchedProgress in objects)
                await episodeWatchedProgressObjectJsonWriter.WriteObjectAsync(jsonWriter, traktEpisodeWatchedProgress, cancellationToken);

            await jsonWriter.WriteEndArrayAsync(cancellationToken);
        }
    }
}
