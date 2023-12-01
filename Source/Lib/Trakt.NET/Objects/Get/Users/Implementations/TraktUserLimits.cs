namespace TraktNet.Objects.Get.Users
{
    /// <summary>A collection of Trakt user limits.</summary>
    public class TraktUserLimits : ITraktUserLimits
    {
        /// <summary>
        /// Gets or sets the user's list limits.
        /// See also <seealso cref="ITraktUserListLimits" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktUserListLimits List { get; set; }

        /// <summary>
        /// Gets or sets the user's watchlist limits.
        /// See also <seealso cref="ITraktUserWatchlistLimits" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktUserWatchlistLimits Watchlist { get; set; }

        /// <summary>
        /// Gets or sets the user's recommendations limits.
        /// See also <seealso cref="ITraktUserRecommendationsLimits" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktUserRecommendationsLimits Recommendations { get; set; }

        /// <summary>
        /// Gets or sets the user's favorites limits.
        /// See also <seealso cref="ITraktUserFavoritesLimits" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktUserFavoritesLimits Favorites { get; set; }
    }
}
