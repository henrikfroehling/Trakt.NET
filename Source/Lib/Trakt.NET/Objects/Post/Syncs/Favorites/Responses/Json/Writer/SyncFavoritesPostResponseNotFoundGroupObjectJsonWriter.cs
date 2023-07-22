namespace TraktNet.Objects.Post.Syncs.Favorites.Responses.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncFavoritesPostResponseNotFoundGroupObjectJsonWriter : AObjectJsonWriter<ITraktSyncFavoritesPostResponseNotFoundGroup>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktSyncFavoritesPostResponseNotFoundGroup obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Movies != null)
            {
                var moviesArrayJsonWriter = new ArrayJsonWriter<ITraktSyncFavoritesPostMovie>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_MOVIES, cancellationToken).ConfigureAwait(false);
                await moviesArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Movies, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Shows != null)
            {
                var showsArrayJsonWriter = new ArrayJsonWriter<ITraktSyncFavoritesPostShow>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SHOWS, cancellationToken).ConfigureAwait(false);
                await showsArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Shows, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
