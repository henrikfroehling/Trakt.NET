namespace TraktNet.Objects.Post.Syncs.Watchlist.Responses
{
    using Syncs.Responses;

    public interface ITraktSyncWatchlistRemovePostResponse
    {
        ITraktSyncPostResponseGroup Deleted { get; set; }

        ITraktSyncPostResponseNotFoundGroup NotFound { get; set; }
    }
}
