namespace TraktApiSharp.Objects.Post.Syncs.History.Responses
{
    using Syncs.Responses;

    public interface ITraktSyncHistoryRemovePostResponseGroup : ITraktSyncPostResponseGroup
    {
        int? HistoryIds { get; set; }
    }
}
