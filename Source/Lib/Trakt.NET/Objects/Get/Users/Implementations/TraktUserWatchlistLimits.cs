namespace TraktNet.Objects.Get.Users
{
    /// <summary>A collection of Trakt user watchlist limits.</summary>
    public class TraktUserWatchlistLimits : ITraktUserWatchlistLimits
    {
        /// <summary>Gets or sets the number maximum watchlist's item count.</summary>
        public int? ItemCount { get; set; }
    }
}
