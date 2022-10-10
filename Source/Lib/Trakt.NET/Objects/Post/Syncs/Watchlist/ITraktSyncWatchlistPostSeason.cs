namespace TraktNet.Objects.Post.Syncs.Watchlist
{
    using Get.Seasons;

    /// <summary>A Trakt watchlist post season, containing the required season ids.</summary>
    public interface ITraktSyncWatchlistPostSeason
    {
        /// <summary>Gets or sets the required season ids. See also <seealso cref="ITraktSeasonIds" />.</summary>
        ITraktSeasonIds Ids { get; set; }

        /// <summary>Gets or sets the season notes.</summary>
        string Notes { get; set; }
    }
}
