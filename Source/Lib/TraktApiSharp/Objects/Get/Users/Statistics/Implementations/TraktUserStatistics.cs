namespace TraktApiSharp.Objects.Get.Users.Statistics.Implementations
{
    using Newtonsoft.Json;

    /// <summary>A collection of Trakt user statistics.</summary>
    public class TraktUserStatistics
    {
        /// <summary>
        /// Gets or sets a collection of Trakt user statistics for movies.
        /// See also <seealso cref="TraktUserMoviesStatistics" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "movies")]
        public TraktUserMoviesStatistics Movies { get; set; }

        /// <summary>
        /// Gets or sets a collection of Trakt user statistics for shows.
        /// See also <seealso cref="TraktUserShowsStatistics" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "shows")]
        public TraktUserShowsStatistics Shows { get; set; }

        /// <summary>
        /// Gets or sets a collection of Trakt user statistics for seasons.
        /// See also <seealso cref="TraktUserSeasonsStatistics" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "seasons")]
        public TraktUserSeasonsStatistics Seasons { get; set; }

        /// <summary>
        /// Gets or sets a collection of Trakt user statistics for episodes.
        /// See also <seealso cref="TraktUserEpisodesStatistics" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "episodes")]
        public TraktUserEpisodesStatistics Episodes { get; set; }

        /// <summary>
        /// Gets or sets a collection of Trakt user statistics about an user's network.
        /// See also <seealso cref="TraktUserNetworkStatistics" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "network")]
        public TraktUserNetworkStatistics Network { get; set; }

        /// <summary>
        /// Gets or sets a collection of Trakt user statistics for ratings.
        /// See also <seealso cref="TraktUserRatingsStatistics" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "ratings")]
        public TraktUserRatingsStatistics Ratings { get; set; }
    }
}
