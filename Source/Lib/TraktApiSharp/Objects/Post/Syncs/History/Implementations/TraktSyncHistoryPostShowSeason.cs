namespace TraktApiSharp.Objects.Post.Syncs.History
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A Trakt history post season, containing the required season number and optional episodes
    /// and an optional datetime, when the season was watched.
    /// </summary>
    public class TraktSyncHistoryPostShowSeason : ITraktSyncHistoryPostShowSeason
    {
        /// <summary>Gets or sets the optional UTC datetime, when the Trakt season was watched.</summary>
        public DateTime? WatchedAt { get; set; }

        /// <summary>Gets or sets the required season number of the Trakt season.</summary>
        public int Number { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncHistoryPostShowEpisode" />s.
        /// <para>
        /// If no episodes are set, the whole Trakt season will be added to the history.
        /// Otherwise, only the specified episodes will be added to the history.
        /// </para>
        /// </summary>
        public IEnumerable<ITraktSyncHistoryPostShowEpisode> Episodes { get; set; }
    }
}
