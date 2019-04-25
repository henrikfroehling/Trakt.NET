namespace TraktNet.Objects.Post.Syncs.Watchlist
{
    /// <summary>A Trakt watchlist post episode, containing the required episode number.</summary>
    public interface ITraktSyncWatchlistPostShowEpisode
    {
        /// <summary>Gets or sets the required season number of the Trakt episode.</summary>
        int Number { get; set; }
    }
}
