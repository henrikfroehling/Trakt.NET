namespace TraktApiSharp.Objects.Post.Syncs.History.Implementations
{
    using System;

    /// <summary>
    /// A Trakt history post episode, containing the required episode number
    /// and an optional datetime, when the episode was watched.
    /// </summary>
    public class TraktSyncHistoryPostShowEpisode : ITraktSyncHistoryPostShowEpisode
    {
        /// <summary>Gets or sets the optional UTC datetime, when the Trakt episode was watched.</summary>
        public DateTime? WatchedAt { get; set; }

        /// <summary>Gets or sets the required season number of the Trakt episode.</summary>
        public int Number { get; set; }
    }
}
