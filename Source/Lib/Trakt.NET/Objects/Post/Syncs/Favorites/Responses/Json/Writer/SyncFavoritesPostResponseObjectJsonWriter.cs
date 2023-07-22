namespace TraktNet.Objects.Post.Syncs.Favorites.Responses.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using Objects.Post.Responses.Json.Writer;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncFavoritesPostResponseObjectJsonWriter : AObjectJsonWriter<ITraktSyncFavoritesPostResponse>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktSyncFavoritesPostResponse obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Added != null)
            {
                var syncPostResponseGroupObjectJsonWriter = new SyncFavoritesPostResponseGroupObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_ADDED, cancellationToken).ConfigureAwait(false);
                await syncPostResponseGroupObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Added, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Existing != null)
            {
                var syncPostResponseGroupObjectJsonWriter = new SyncFavoritesPostResponseGroupObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_EXISTING, cancellationToken).ConfigureAwait(false);
                await syncPostResponseGroupObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Existing, cancellationToken).ConfigureAwait(false);
            }

            if (obj.NotFound != null)
            {
                var syncPostResponseNotFoundGroupObjectJsonWriter = new SyncFavoritesPostResponseNotFoundGroupObjectJsonWriter();
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
