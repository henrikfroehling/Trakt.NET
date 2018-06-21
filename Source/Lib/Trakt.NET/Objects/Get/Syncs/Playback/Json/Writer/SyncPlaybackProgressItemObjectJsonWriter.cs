namespace TraktNet.Objects.Get.Syncs.Playback.Json.Writer
{
    using Episodes.Json.Writer;
    using Extensions;
    using Movies.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using Shows.Json.Writer;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncPlaybackProgressItemObjectJsonWriter : AObjectJsonWriter<ITraktSyncPlaybackProgressItem>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktSyncPlaybackProgressItem obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_PLAYBACK_PROGRESS_ITEM_PROPERTY_NAME_ID, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteValueAsync(obj.Id, cancellationToken).ConfigureAwait(false);

            if (obj.Progress.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_PLAYBACK_PROGRESS_ITEM_PROPERTY_NAME_PROGRESS, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Progress, cancellationToken).ConfigureAwait(false);
            }

            if (obj.PausedAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_PLAYBACK_PROGRESS_ITEM_PROPERTY_NAME_PAUSED_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.PausedAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            if (obj.Type != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_PLAYBACK_PROGRESS_ITEM_PROPERTY_NAME_TYPE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Type.ObjectName, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Movie != null)
            {
                var movieObjectJsonWriter = new MovieObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_PLAYBACK_PROGRESS_ITEM_PROPERTY_NAME_MOVIE, cancellationToken).ConfigureAwait(false);
                await movieObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Movie, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Episode != null)
            {
                var episodeObjectJsonWriter = new EpisodeObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_PLAYBACK_PROGRESS_ITEM_PROPERTY_NAME_EPISODE, cancellationToken).ConfigureAwait(false);
                await episodeObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Episode, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Show != null)
            {
                var showObjectJsonWriter = new ShowObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_PLAYBACK_PROGRESS_ITEM_PROPERTY_NAME_SHOW, cancellationToken).ConfigureAwait(false);
                await showObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Show, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
