namespace TraktNet.Objects.Post.Syncs.History.Responses
{
    using Syncs.Responses;
    using System.Collections.Generic;

    /// <summary>A collection containing the ids of movies, shows, seasons, episodes and history items, which were not found.</summary>
    public interface ITraktSyncHistoryRemovePostResponseNotFoundGroup : ITraktSyncPostResponseNotFoundGroup
    {
        /// <summary>Gets or sets a list of Trakt history item ids, which were not found.<para>Nullable</para></summary>
        IList<ulong> HistoryIds { get; set; }
    }
}
