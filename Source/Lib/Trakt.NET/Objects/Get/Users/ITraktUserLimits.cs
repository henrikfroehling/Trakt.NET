namespace TraktNet.Objects.Get.Users
{
    /// <summary>A collection of Trakt user limits.</summary>
    public interface ITraktUserLimits
    {
        /// <summary>
        /// Gets or sets the user's list limits.
        /// See also <seealso cref="ITraktUserListLimits" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktUserListLimits List { get; set; }

        /// <summary>
        /// Gets or sets the user's watchlist limits.
        /// See also <seealso cref="ITraktUserWatchlistLimits" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktUserWatchlistLimits Watchlist { get; set; }

        /// <summary>
        /// Gets or sets the user's recommendations limits.
        /// See also <seealso cref="ITraktUserRecommendationsLimits" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktUserRecommendationsLimits Recommendations { get; set; }

        /// <summary>
        /// Gets or sets the user's favorites limits.
        /// See also <seealso cref="ITraktUserFavoritesLimits" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktUserFavoritesLimits Favorites { get; set; }
    }
}
