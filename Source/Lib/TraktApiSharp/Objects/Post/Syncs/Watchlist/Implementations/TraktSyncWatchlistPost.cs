namespace TraktApiSharp.Objects.Post.Syncs.Watchlist.Implementations
{
    using System.Collections.Generic;

    /// <summary>
    /// A Trakt watchlist post, containing all movies, shows and / or episodes,
    /// which should be added to the user's watchlist.
    /// </summary>
    public class TraktSyncWatchlistPost : ITraktSyncWatchlistPost
    {
        /// <summary>
        /// An optional list of <see cref="ITraktSyncWatchlistPostMovie" />s.
        /// <para>Each <see cref="ITraktSyncWatchlistPostMovie" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public IEnumerable<ITraktSyncWatchlistPostMovie> Movies { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncWatchlistPostShow" />s.
        /// <para>Each <see cref="ITraktSyncWatchlistPostShow" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public IEnumerable<ITraktSyncWatchlistPostShow> Shows { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncWatchlistPostEpisode" />s.
        /// <para>Each <see cref="ITraktSyncWatchlistPostEpisode" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public IEnumerable<ITraktSyncWatchlistPostEpisode> Episodes { get; set; }

        /// <summary>Returns a new <see cref="TraktSyncWatchlistPostBuilder" /> instance.</summary>
        /// <returns>A new <see cref="TraktSyncWatchlistPostBuilder" /> instance.</returns>
        public static TraktSyncWatchlistPostBuilder Builder() => new TraktSyncWatchlistPostBuilder();
    }
}
