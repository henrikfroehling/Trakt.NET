namespace TraktNet.Objects.Post.Syncs.History
{
    using System;

    /// <summary>
    /// A Trakt history post movie, containing the required movie ids
    /// and an optional datetime, when the movie was watched.
    /// </summary>
    public interface ITraktSyncHistoryPostMovie : ITraktSyncHistoryRemovePostMovie
    {
        /// <summary>Gets or sets the optional UTC datetime, when the Trakt movie was watched.</summary>
        DateTime? WatchedAt { get; set; }
    }
}
