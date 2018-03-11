namespace TraktApiSharp.Objects.Post.Syncs.Watchlist.Responses.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using Syncs.Responses.Json.Writer;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncWatchlistPostResponseObjectJsonWriter : AObjectJsonWriter<ITraktSyncWatchlistPostResponse>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktSyncWatchlistPostResponse obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            var syncPostResponseGroupObjectJsonWriter = new SyncPostResponseGroupObjectJsonWriter();
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Added != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_WATCHLIST_POST_RESPONSE_PROPERTY_NAME_ADDED, cancellationToken).ConfigureAwait(false);
                await syncPostResponseGroupObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Added, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Existing != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_WATCHLIST_POST_RESPONSE_PROPERTY_NAME_EXISTING, cancellationToken).ConfigureAwait(false);
                await syncPostResponseGroupObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Existing, cancellationToken).ConfigureAwait(false);
            }

            if (obj.NotFound != null)
            {
                var syncPostResponseNotFoundGroupObjectJsonWriter = new SyncPostResponseNotFoundGroupObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_WATCHLIST_POST_RESPONSE_PROPERTY_NAME_NOT_FOUND, cancellationToken).ConfigureAwait(false);
                await syncPostResponseNotFoundGroupObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.NotFound, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
