namespace TraktNet.Objects.Post.Syncs.History.Responses.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using Syncs.Responses.Json.Writer;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncHistoryPostResponseObjectJsonWriter : AObjectJsonWriter<ITraktSyncHistoryPostResponse>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktSyncHistoryPostResponse obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Added != null)
            {
                var syncPostResponseGroupObjectJsonWriter = new SyncPostResponseGroupObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_HISTORY_POST_RESPONSE_PROPERTY_NAME_ADDED, cancellationToken).ConfigureAwait(false);
                await syncPostResponseGroupObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Added, cancellationToken).ConfigureAwait(false);
            }

            if (obj.NotFound != null)
            {
                var syncPostResponseNotFoundGroupObjectJsonWriter = new SyncPostResponseNotFoundGroupObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_HISTORY_POST_RESPONSE_PROPERTY_NAME_NOT_FOUND, cancellationToken).ConfigureAwait(false);
                await syncPostResponseNotFoundGroupObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.NotFound, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
