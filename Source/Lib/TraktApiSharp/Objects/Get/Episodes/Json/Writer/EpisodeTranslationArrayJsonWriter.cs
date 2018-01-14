namespace TraktApiSharp.Objects.Get.Episodes.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class EpisodeTranslationArrayJsonWriter : AArrayJsonWriter<ITraktEpisodeTranslation>
    {
        public override async Task WriteArrayAsync(JsonTextWriter jsonWriter, IEnumerable<ITraktEpisodeTranslation> objects, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            var episodeTranslationObjectJsonWriter = new EpisodeTranslationObjectJsonWriter();
            await jsonWriter.WriteStartArrayAsync(cancellationToken);

            foreach (ITraktEpisodeTranslation traktEpisodeTranslation in objects)
                await episodeTranslationObjectJsonWriter.WriteObjectAsync(jsonWriter, traktEpisodeTranslation, cancellationToken);

            await jsonWriter.WriteEndArrayAsync(cancellationToken);
        }
    }
}
