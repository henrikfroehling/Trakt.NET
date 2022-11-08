namespace TraktNet.Objects.Post.Syncs.Watchlist
{
    using Requests.Interfaces;
    using System.Collections.Generic;

    /// <summary>
    /// A Trakt watchlist post, containing all movies, shows, seasons and / or episodes,
    /// which should be added to the user's watchlist.
    /// </summary>
    public interface ITraktSyncWatchlistPost : IRequestBody
    {
        /// <summary>
        /// An optional list of <see cref="ITraktSyncWatchlistPostMovie" />s.
        /// <para>Each <see cref="ITraktSyncWatchlistPostMovie" /> must have at least a valid Trakt id.</para>
        /// </summary>
        IEnumerable<ITraktSyncWatchlistPostMovie> Movies { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncWatchlistPostShow" />s.
        /// <para>Each <see cref="ITraktSyncWatchlistPostShow" /> must have at least a valid Trakt id.</para>
        /// </summary>
        IEnumerable<ITraktSyncWatchlistPostShow> Shows { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncWatchlistPostSeason" />s.
        /// <para>Each <see cref="ITraktSyncWatchlistPostSeason" /> must have at least a valid Trakt id.</para>
        /// </summary>
        IEnumerable<ITraktSyncWatchlistPostSeason> Seasons { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncWatchlistPostEpisode" />s.
        /// <para>Each <see cref="ITraktSyncWatchlistPostEpisode" /> must have at least a valid Trakt id.</para>
        /// </summary>
        IEnumerable<ITraktSyncWatchlistPostEpisode> Episodes { get; set; }
    }
}
