namespace TraktNet.Objects.Post.Syncs.Watchlist.Responses
{
    using Syncs.Responses;

    public interface ITraktSyncWatchlistPostResponse
    {
        ITraktSyncPostResponseGroup Added { get; set; }

        ITraktSyncPostResponseGroup Existing { get; set; }

        ITraktSyncPostResponseNotFoundGroup NotFound { get; set; }
    }
}
