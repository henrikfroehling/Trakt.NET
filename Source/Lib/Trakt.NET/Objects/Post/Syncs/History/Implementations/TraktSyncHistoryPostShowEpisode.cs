namespace TraktNet.Objects.Post.Syncs.History
{
    using System;

    /// <summary>
    /// A Trakt history post episode, containing the required episode number
    /// and an optional datetime, when the episode was watched.
    /// </summary>
    public class TraktSyncHistoryPostShowEpisode : TraktSyncHistoryRemovePostShowEpisode, ITraktSyncHistoryPostShowEpisode
    {
        /// <summary>Gets or sets the optional UTC datetime, when the Trakt episode was watched.</summary>
        public DateTime? WatchedAt { get; set; }
    }
}
