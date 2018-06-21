namespace TraktNet.Objects.Post.Syncs.History.Responses
{
    public interface ITraktSyncHistoryRemovePostResponse
    {
        ITraktSyncHistoryRemovePostResponseGroup Deleted { get; set; }

        ITraktSyncHistoryRemovePostResponseNotFoundGroup NotFound { get; set; }
    }
}
