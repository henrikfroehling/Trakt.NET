namespace TraktNet.Objects.Post.Syncs.Watchlist.Json.Writer
{
    using Newtonsoft.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktNet.Objects.Json;

    internal abstract class ASyncWatchlistPostObjectJsonWriter<TSyncWatchlistPost> : AObjectJsonWriter<TSyncWatchlistPost>
        where TSyncWatchlistPost : ITraktSyncWatchlistPost
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, TSyncWatchlistPost obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);
            await WriteWatchlistPostObjectAsync(jsonWriter, obj, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }

        protected virtual async Task WriteWatchlistPostObjectAsync(JsonTextWriter jsonWriter, TSyncWatchlistPost obj, CancellationToken cancellationToken = default)
        {
            if (obj.Movies != null)
            {
                var syncWatchlistPostMovieArrayJsonWriter = new ArrayJsonWriter<ITraktSyncWatchlistPostMovie>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_MOVIES, cancellationToken).ConfigureAwait(false);
                await syncWatchlistPostMovieArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Movies, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Shows != null)
            {
                var syncWatchlistPostShowArrayJsonWriter = new ArrayJsonWriter<ITraktSyncWatchlistPostShow>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SHOWS, cancellationToken).ConfigureAwait(false);
                await syncWatchlistPostShowArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Shows, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Seasons != null)
            {
                var syncWatchlistPostSeasonArrayJsonWriter = new ArrayJsonWriter<ITraktSyncWatchlistPostSeason>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SEASONS, cancellationToken).ConfigureAwait(false);
                await syncWatchlistPostSeasonArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Seasons, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Episodes != null)
            {
                var syncWatchlistPostEpisodeArrayJsonWriter = new ArrayJsonWriter<ITraktSyncWatchlistPostEpisode>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_EPISODES, cancellationToken).ConfigureAwait(false);
                await syncWatchlistPostEpisodeArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Episodes, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
