namespace TraktNet.Objects.Post.Syncs.History.Responses.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncHistoryRemovePostResponseObjectJsonWriter : AObjectJsonWriter<ITraktSyncHistoryRemovePostResponse>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktSyncHistoryRemovePostResponse obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Deleted != null)
            {
                var syncHistoryRemovePostResponseGroupObjectJsonWriter = new SyncHistoryRemovePostResponseGroupObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_HISTORY_REMOVE_POST_RESPONSE_PROPERTY_NAME_DELETED, cancellationToken).ConfigureAwait(false);
                await syncHistoryRemovePostResponseGroupObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Deleted, cancellationToken).ConfigureAwait(false);
            }

            if (obj.NotFound != null)
            {
                var syncHistoryRemovePostResponseNotFoundGroupObjectJsonWriter = new SyncHistoryRemovePostResponseNotFoundGroupObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_HISTORY_REMOVE_POST_RESPONSE_PROPERTY_NAME_NOT_FOUND, cancellationToken).ConfigureAwait(false);
                await syncHistoryRemovePostResponseNotFoundGroupObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.NotFound, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
