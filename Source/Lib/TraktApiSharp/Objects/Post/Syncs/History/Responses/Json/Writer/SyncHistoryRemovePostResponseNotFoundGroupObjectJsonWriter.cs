namespace TraktNet.Objects.Post.Syncs.History.Responses.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using Syncs.Responses.Json.Writer;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncHistoryRemovePostResponseNotFoundGroupObjectJsonWriter : ASyncPostResponseNotFoundGroupObjectJsonWriter<ITraktSyncHistoryRemovePostResponseNotFoundGroup>
    {
        protected override async Task WriteSyncPostResponseObjectAsync(JsonTextWriter jsonWriter, ITraktSyncHistoryRemovePostResponseNotFoundGroup obj, CancellationToken cancellationToken = default)
        {
            await base.WriteSyncPostResponseObjectAsync(jsonWriter, obj, cancellationToken).ConfigureAwait(false);

            if (obj.HistoryIds != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_HISTORY_REMOVE_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_IDS, cancellationToken).ConfigureAwait(false);
                await JsonWriterHelper.WriteUnsignedLongArrayAsync(jsonWriter, obj.HistoryIds, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
