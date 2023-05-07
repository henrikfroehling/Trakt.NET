namespace TraktNet.Objects.Post.Syncs.Watchlist
{
    using System.Collections.Generic;

    /// <summary>A Trakt watchlist post season, containing the required season number and optional episodes.</summary>
    public interface ITraktSyncWatchlistPostShowSeason
    {
        /// <summary>Gets or sets the required season number of the Trakt season.</summary>
        int Number { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncWatchlistPostShowEpisode" />s.
        /// <para>
        /// If no episodes are set, the whole Trakt season will be added to the watchlist.
        /// Otherwise, only the specified episodes will be added to the watchlist.
        /// </para>
        /// </summary>
        IList<ITraktSyncWatchlistPostShowEpisode> Episodes { get; set; }
    }
}
