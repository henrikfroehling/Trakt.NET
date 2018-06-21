namespace TraktNet.Objects.Post.Syncs.History.Json.Writer
{
    using Extensions;
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncHistoryPostShowSeasonObjectJsonWriter : AObjectJsonWriter<ITraktSyncHistoryPostShowSeason>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktSyncHistoryPostShowSeason obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.WatchedAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_HISTORY_POST_SHOW_SEASON_PROPERTY_NAME_WATCHED_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.WatchedAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_HISTORY_POST_SHOW_SEASON_PROPERTY_NAME_NUMBER, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteValueAsync(obj.Number, cancellationToken).ConfigureAwait(false);

            if (obj.Episodes != null)
            {
                var syncHistoryPostShowEpisodeArrayJsonWriter = new ArrayJsonWriter<ITraktSyncHistoryPostShowEpisode>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_HISTORY_POST_SHOW_SEASON_PROPERTY_NAME_EPISODES, cancellationToken).ConfigureAwait(false);
                await syncHistoryPostShowEpisodeArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Episodes, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
