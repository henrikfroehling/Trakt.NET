namespace TraktApiSharp.Objects.Post.Syncs.Watchlist.Json.Writer
{
    using Get.Movies.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncWatchlistPostMovieObjectJsonWriter : AObjectJsonWriter<ITraktSyncWatchlistPostMovie>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktSyncWatchlistPostMovie obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (!string.IsNullOrEmpty(obj.Title))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_WATCHLIST_POST_MOVIE_PROPERTY_NAME_TITLE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Title, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Year.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_WATCHLIST_POST_MOVIE_PROPERTY_NAME_YEAR, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Year, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Ids != null)
            {
                var movieIdsObjectJsonWriter = new MovieIdsObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_WATCHLIST_POST_MOVIE_PROPERTY_NAME_IDS, cancellationToken).ConfigureAwait(false);
                await movieIdsObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Ids, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
