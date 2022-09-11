namespace TraktNet.Objects.Get.Users
{
    /// <summary>A collection of Trakt user watchlist limits.</summary>
    public interface ITraktUserWatchlistLimits
    {
        /// <summary>Gets or sets the number maximum watchlist's item count.</summary>
        int? ItemCount { get; set; }
    }
}
