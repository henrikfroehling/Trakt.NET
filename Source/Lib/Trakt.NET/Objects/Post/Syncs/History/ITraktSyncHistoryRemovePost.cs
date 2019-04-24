namespace TraktNet.Objects.Post.Syncs.History
{
    using System.Collections.Generic;

    /// <summary>
    /// A Trakt history remove post, containing all movies, shows, episodes and / or history ids,
    /// which should be removed from the user's history.
    /// </summary>
    public interface ITraktSyncHistoryRemovePost : ITraktSyncHistoryPost
    {
        /// <summary>An optional list of history ids, which should be removed.</summary>
        IEnumerable<ulong> HistoryIds { get; set; }
    }
}
