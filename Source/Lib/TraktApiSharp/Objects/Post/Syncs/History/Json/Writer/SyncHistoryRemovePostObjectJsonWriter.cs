namespace TraktNet.Objects.Post.Syncs.History.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncHistoryRemovePostObjectJsonWriter : ASyncHistoryPostObjectJsonWriter<ITraktSyncHistoryRemovePost>
    {
        protected override async Task WriteSyncHistoryObjectAsync(JsonTextWriter jsonWriter, ITraktSyncHistoryRemovePost obj, CancellationToken cancellationToken = default)
        {
            await base.WriteSyncHistoryObjectAsync(jsonWriter, obj, cancellationToken).ConfigureAwait(false);

            if (obj.HistoryIds != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_HISTORY_REMOVE_POST_PROPERTY_NAME_IDS, cancellationToken).ConfigureAwait(false);
                await JsonWriterHelper.WriteUnsignedLongArrayAsync(jsonWriter, obj.HistoryIds, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
