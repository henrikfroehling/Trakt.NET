namespace TraktApiSharp.Objects.Get.Shows.Json.Writer
{
    using Episodes.Json.Writer;
    using Extensions;
    using Newtonsoft.Json;
    using Objects.Json;
    using Seasons.Json.Writer;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ShowCollectionProgressObjectJsonWriter : AObjectJsonWriter<ITraktShowCollectionProgress>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktShowCollectionProgress obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Aired.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHOW_COLLECTION_PROGRESS_PROPERTY_NAME_AIRED, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Aired, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Completed.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHOW_COLLECTION_PROGRESS_PROPERTY_NAME_COMPLETED, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Completed, cancellationToken).ConfigureAwait(false);
            }

            if (obj.LastCollectedAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHOW_COLLECTION_PROGRESS_PROPERTY_NAME_LAST_COLLECTED_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.LastCollectedAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            if (obj.Seasons != null)
            {
                var seasonCollectionProgressArrayJsonWriter = new SeasonCollectionProgressArrayJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHOW_COLLECTION_PROGRESS_PROPERTY_NAME_SEASONS, cancellationToken).ConfigureAwait(false);
                await seasonCollectionProgressArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Seasons, cancellationToken).ConfigureAwait(false);
            }

            if (obj.HiddenSeasons != null)
            {
                var seasonArrayJsonWriter = new SeasonArrayJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHOW_COLLECTION_PROGRESS_PROPERTY_NAME_HIDDEN_SEASONS, cancellationToken).ConfigureAwait(false);
                await seasonArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.HiddenSeasons, cancellationToken).ConfigureAwait(false);
            }

            var episodeObjectJsonWriter = new EpisodeObjectJsonWriter();

            if (obj.NextEpisode != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHOW_COLLECTION_PROGRESS_PROPERTY_NAME_NEXT_EPISODE, cancellationToken).ConfigureAwait(false);
                await episodeObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.NextEpisode, cancellationToken).ConfigureAwait(false);
            }

            if (obj.LastEpisode != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHOW_COLLECTION_PROGRESS_PROPERTY_NAME_LAST_EPISODE, cancellationToken).ConfigureAwait(false);
                await episodeObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.LastEpisode, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
