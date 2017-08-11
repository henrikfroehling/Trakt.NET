namespace TraktApiSharp.Objects.Post.Syncs.Watchlist.Responses.Implementations
{
    using Syncs.Responses;

    /// <summary>
    /// Represents the response for a watchlist remove post. See also <see cref="TraktSyncWatchlistPost" />.
    /// <para>Contains the number of deleted and not found movies, shows, seasons and episodes.</para>
    /// </summary>
    public class TraktSyncWatchlistRemovePostResponse : ITraktSyncWatchlistRemovePostResponse
    {
        /// <summary>
        /// A collection containing the number of deleted movies, shows, seasons and episodes.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktSyncPostResponseGroup Deleted { get; set; }

        /// <summary>
        /// A collection containing the ids of movies, shows, seasons and episodes, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktSyncPostResponseNotFoundGroup NotFound { get; set; }
    }
}
