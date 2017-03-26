namespace TraktApiSharp.Objects.Get.Users.Statistics.Implementations
{
    using Newtonsoft.Json;

    /// <summary>A collection of Trakt user statistics.</summary>
    public class TraktUserStatistics : ITraktUserStatistics
    {
        /// <summary>
        /// Gets or sets a collection of Trakt user statistics for movies.
        /// See also <seealso cref="ITraktUserMoviesStatistics" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "movies")]
        public ITraktUserMoviesStatistics Movies { get; set; }

        /// <summary>
        /// Gets or sets a collection of Trakt user statistics for shows.
        /// See also <seealso cref="ITraktUserShowsStatistics" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "shows")]
        public ITraktUserShowsStatistics Shows { get; set; }

        /// <summary>
        /// Gets or sets a collection of Trakt user statistics for seasons.
        /// See also <seealso cref="ITraktUserSeasonsStatistics" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "seasons")]
        public ITraktUserSeasonsStatistics Seasons { get; set; }

        /// <summary>
        /// Gets or sets a collection of Trakt user statistics for episodes.
        /// See also <seealso cref="ITraktUserEpisodesStatistics" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "episodes")]
        public ITraktUserEpisodesStatistics Episodes { get; set; }

        /// <summary>
        /// Gets or sets a collection of Trakt user statistics about an user's network.
        /// See also <seealso cref="ITraktUserNetworkStatistics" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "network")]
        public ITraktUserNetworkStatistics Network { get; set; }

        /// <summary>
        /// Gets or sets a collection of Trakt user statistics for ratings.
        /// See also <seealso cref="ITraktUserRatingsStatistics" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "ratings")]
        public ITraktUserRatingsStatistics Ratings { get; set; }
    }
}
