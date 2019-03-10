namespace TraktNet.Objects.Post.Syncs.Watchlist.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncWatchlistPostObjectJsonWriter : AObjectJsonWriter<ITraktSyncWatchlistPost>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktSyncWatchlistPost obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Movies != null)
            {
                var syncWatchlistPostMovieArrayJsonWriter = new ArrayJsonWriter<ITraktSyncWatchlistPostMovie>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_WATCHLIST_POST_PROPERTY_NAME_MOVIES, cancellationToken).ConfigureAwait(false);
                await syncWatchlistPostMovieArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Movies, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Shows != null)
            {
                var syncWatchlistPostShowArrayJsonWriter = new ArrayJsonWriter<ITraktSyncWatchlistPostShow>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_WATCHLIST_POST_PROPERTY_NAME_SHOWS, cancellationToken).ConfigureAwait(false);
                await syncWatchlistPostShowArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Shows, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Episodes != null)
            {
                var syncWatchlistPostEpisodeArrayJsonWriter = new ArrayJsonWriter<ITraktSyncWatchlistPostEpisode>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_WATCHLIST_POST_PROPERTY_NAME_EPISODES, cancellationToken).ConfigureAwait(false);
                await syncWatchlistPostEpisodeArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Episodes, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
