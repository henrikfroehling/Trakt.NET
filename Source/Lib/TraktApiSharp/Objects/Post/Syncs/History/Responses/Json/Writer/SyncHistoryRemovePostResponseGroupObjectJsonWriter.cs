namespace TraktApiSharp.Objects.Post.Syncs.History.Responses.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using Syncs.Responses.Json.Writer;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncHistoryRemovePostResponseGroupObjectJsonWriter : ASyncPostResponseGroupObjectJsonWriter<ITraktSyncHistoryRemovePostResponseGroup>
    {
        protected override async Task WriteSyncPostResponseObjectAsync(JsonTextWriter jsonWriter, ITraktSyncHistoryRemovePostResponseGroup obj, CancellationToken cancellationToken = default)
        {
            await base.WriteSyncPostResponseObjectAsync(jsonWriter, obj, cancellationToken).ConfigureAwait(false);

            if (obj.HistoryIds.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_HISTORY_REMOVE_POST_RESPONSE_GROUP_PROPERTY_NAME_IDS, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.HistoryIds, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
