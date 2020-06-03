namespace TraktNet.Objects.Post.Syncs.Collection.Responses.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using Syncs.Responses.Json.Writer;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncCollectionPostResponseObjectJsonWriter : AObjectJsonWriter<ITraktSyncCollectionPostResponse>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktSyncCollectionPostResponse obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            var syncPostResponseGroupObjectJsonWriter = new SyncPostResponseGroupObjectJsonWriter();
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Added != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_COLLECTION_POST_RESPONSE_PROPERTY_NAME_ADDED, cancellationToken).ConfigureAwait(false);
                await syncPostResponseGroupObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Added, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Updated != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_COLLECTION_POST_RESPONSE_PROPERTY_NAME_UPDATED, cancellationToken).ConfigureAwait(false);
                await syncPostResponseGroupObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Updated, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Existing != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_COLLECTION_POST_RESPONSE_PROPERTY_NAME_EXISTING, cancellationToken).ConfigureAwait(false);
                await syncPostResponseGroupObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Existing, cancellationToken).ConfigureAwait(false);
            }

            if (obj.NotFound != null)
            {
                var syncCollectionPostResponseNotFoundGroupObjectJsonWriter = new SyncPostResponseNotFoundGroupObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_COLLECTION_POST_RESPONSE_PROPERTY_NAME_NOT_FOUND, cancellationToken).ConfigureAwait(false);
                await syncCollectionPostResponseNotFoundGroupObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.NotFound, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
