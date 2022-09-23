namespace TraktNet.Objects.Post.Syncs.Watchlist
{
    using Get.Episodes;

    /// <summary>A Trakt watchlist post episode, containing the required episode ids.</summary>
    public interface ITraktSyncWatchlistPostEpisode
    {
        /// <summary>Gets or sets the required episode ids. See also <seealso cref="ITraktEpisodeIds" />.</summary>
        ITraktEpisodeIds Ids { get; set; }

        /// <summary>Gets or sets the episode notes.</summary>
        string Notes { get; set; }
    }
}
