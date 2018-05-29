namespace TraktApiSharp.Objects.Post.Syncs.History.Responses
{
    using Syncs.Responses;

    /// <summary>A collection containing the number of movies, shows, seasons, episodes and history item ids.</summary>
    public class TraktSyncHistoryRemovePostResponseGroup : TraktSyncPostResponseGroup, ITraktSyncHistoryRemovePostResponseGroup
    {
        /// <summary>Gets or sets the number of history item ids.</summary>
        public int? HistoryIds { get; set; }
    }
}
