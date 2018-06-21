namespace TraktNet.Objects.Get.Users.Statistics
{
    /// <summary>A collection of Trakt user statistics.</summary>
    public class TraktUserStatistics : ITraktUserStatistics
    {
        /// <summary>
        /// Gets or sets a collection of Trakt user statistics for movies.
        /// See also <seealso cref="ITraktUserMoviesStatistics" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktUserMoviesStatistics Movies { get; set; }

        /// <summary>
        /// Gets or sets a collection of Trakt user statistics for shows.
        /// See also <seealso cref="ITraktUserShowsStatistics" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktUserShowsStatistics Shows { get; set; }

        /// <summary>
        /// Gets or sets a collection of Trakt user statistics for seasons.
        /// See also <seealso cref="ITraktUserSeasonsStatistics" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktUserSeasonsStatistics Seasons { get; set; }

        /// <summary>
        /// Gets or sets a collection of Trakt user statistics for episodes.
        /// See also <seealso cref="ITraktUserEpisodesStatistics" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktUserEpisodesStatistics Episodes { get; set; }

        /// <summary>
        /// Gets or sets a collection of Trakt user statistics about an user's network.
        /// See also <seealso cref="ITraktUserNetworkStatistics" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktUserNetworkStatistics Network { get; set; }

        /// <summary>
        /// Gets or sets a collection of Trakt user statistics for ratings.
        /// See also <seealso cref="ITraktUserRatingsStatistics" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktUserRatingsStatistics Ratings { get; set; }
    }
}
