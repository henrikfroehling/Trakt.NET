namespace TraktNet.Objects.Post.Syncs.Watchlist
{
    /// <summary>
    /// A Trakt watchlist post, containing all movies, shows, seasons and / or episodes,
    /// which should be removed from the user's watchlist.
    /// </summary>
    public interface ITraktSyncWatchlistRemovePost : ITraktSyncWatchlistPost
    {
    }
}
