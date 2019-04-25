namespace TraktNet.Objects.Get.Users.Statistics
{
    /// <summary>A collection of Trakt user statistics.</summary>
    public interface ITraktUserStatistics
    {
        /// <summary>
        /// Gets or sets a collection of Trakt user statistics for movies.
        /// See also <seealso cref="ITraktUserMoviesStatistics" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktUserMoviesStatistics Movies { get; set; }

        /// <summary>
        /// Gets or sets a collection of Trakt user statistics for shows.
        /// See also <seealso cref="ITraktUserShowsStatistics" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktUserShowsStatistics Shows { get; set; }

        /// <summary>
        /// Gets or sets a collection of Trakt user statistics for seasons.
        /// See also <seealso cref="ITraktUserSeasonsStatistics" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktUserSeasonsStatistics Seasons { get; set; }

        /// <summary>
        /// Gets or sets a collection of Trakt user statistics for episodes.
        /// See also <seealso cref="ITraktUserEpisodesStatistics" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktUserEpisodesStatistics Episodes { get; set; }

        /// <summary>
        /// Gets or sets a collection of Trakt user statistics about an user's network.
        /// See also <seealso cref="ITraktUserNetworkStatistics" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktUserNetworkStatistics Network { get; set; }

        /// <summary>
        /// Gets or sets a collection of Trakt user statistics for ratings.
        /// See also <seealso cref="ITraktUserRatingsStatistics" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktUserRatingsStatistics Ratings { get; set; }
    }
}
