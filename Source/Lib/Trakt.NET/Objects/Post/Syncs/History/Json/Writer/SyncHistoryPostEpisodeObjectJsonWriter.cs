namespace TraktNet.Objects.Post.Syncs.History.Json.Writer
{
    using Extensions;
    using Get.Episodes.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncHistoryPostEpisodeObjectJsonWriter : AObjectJsonWriter<ITraktSyncHistoryPostEpisode>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktSyncHistoryPostEpisode obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.WatchedAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_HISTORY_POST_EPISODE_PROPERTY_NAME_WATCHED_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.WatchedAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            if (obj.Ids != null)
            {
                var episodeIdsObjectJsonWriter = new EpisodeIdsObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_HISTORY_POST_EPISODE_PROPERTY_NAME_IDS, cancellationToken).ConfigureAwait(false);
                await episodeIdsObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Ids, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
