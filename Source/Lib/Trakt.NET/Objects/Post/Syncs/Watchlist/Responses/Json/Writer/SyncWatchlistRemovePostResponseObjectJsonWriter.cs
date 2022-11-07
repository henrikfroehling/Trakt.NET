namespace TraktNet.Objects.Post.Syncs.Watchlist.Responses.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using Objects.Post.Responses.Json.Writer;
    using Syncs.Responses.Json.Writer;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncWatchlistRemovePostResponseObjectJsonWriter : AObjectJsonWriter<ITraktSyncWatchlistRemovePostResponse>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktSyncWatchlistRemovePostResponse obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Deleted != null)
            {
                var syncPostResponseGroupObjectJsonWriter = new SyncPostResponseGroupObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_DELETED, cancellationToken).ConfigureAwait(false);
                await syncPostResponseGroupObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Deleted, cancellationToken).ConfigureAwait(false);
            }

            if (obj.NotFound != null)
            {
                var syncPostResponseNotFoundGroupObjectJsonWriter = new SyncPostResponseNotFoundGroupObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_NOT_FOUND, cancellationToken).ConfigureAwait(false);
                await syncPostResponseNotFoundGroupObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.NotFound, cancellationToken).ConfigureAwait(false);
            }

            if (obj.List != null)
            {
                var postResponseListDataObjectJsonWriter = new PostResponseListDataObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_LIST, cancellationToken);
                await postResponseListDataObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.List, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
