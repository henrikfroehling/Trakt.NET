namespace TraktNet.Objects.Post.Syncs.Watchlist.Json.Writer
{
    using Get.Episodes.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncWatchlistPostEpisodeObjectJsonWriter : AObjectJsonWriter<ITraktSyncWatchlistPostEpisode>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktSyncWatchlistPostEpisode obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Ids != null)
            {
                var episodeIdsObjectJsonWriter = new EpisodeIdsObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_WATCHLIST_POST_EPISODE_PROPERTY_NAME_IDS, cancellationToken).ConfigureAwait(false);
                await episodeIdsObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Ids, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
