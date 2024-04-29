namespace TraktNet.Objects.Post.Syncs.Favorites.Json.Writer
{
    using Newtonsoft.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktNet.Objects.Json;

    internal abstract class ASyncFavoritesPostObjectJsonWriter<TSyncFavoritesPost> : AObjectJsonWriter<TSyncFavoritesPost>
        where TSyncFavoritesPost : ITraktSyncFavoritesPost
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, TSyncFavoritesPost obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);
            await WriteFavoritesPostObjectAsync(jsonWriter, obj, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }

        protected virtual async Task WriteFavoritesPostObjectAsync(JsonTextWriter jsonWriter, TSyncFavoritesPost obj, CancellationToken cancellationToken = default)
        {
            if (obj.Movies != null)
            {
                var syncFavoritesPostMovieArrayJsonWriter = new ArrayJsonWriter<ITraktSyncFavoritesPostMovie>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_MOVIES, cancellationToken).ConfigureAwait(false);
                await syncFavoritesPostMovieArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Movies, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Shows != null)
            {
                var syncFavoritesPostShowArrayJsonWriter = new ArrayJsonWriter<ITraktSyncFavoritesPostShow>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SHOWS, cancellationToken).ConfigureAwait(false);
                await syncFavoritesPostShowArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Shows, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
