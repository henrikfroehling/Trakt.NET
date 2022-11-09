namespace TraktNet.Objects.Post.Syncs.History
{
    using System;

    /// <summary>
    /// A Trakt history post episode, containing the required episode number
    /// and an optional datetime, when the episode was watched.
    /// </summary>
    public interface ITraktSyncHistoryPostShowEpisode : ITraktSyncHistoryRemovePostShowEpisode
    {
        /// <summary>Gets or sets the optional UTC datetime, when the Trakt episode was watched.</summary>
        DateTime? WatchedAt { get; set; }
    }
}
