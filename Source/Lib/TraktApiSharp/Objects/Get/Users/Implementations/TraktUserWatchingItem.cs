namespace TraktApiSharp.Objects.Get.Users.Implementations
{
    using Enums;
    using Episodes;
    using Movies;
    using Newtonsoft.Json;
    using Shows;
    using System;
    using TraktApiSharp.Objects.Get.Episodes.Implementations;
    using TraktApiSharp.Objects.Get.Movies.Implementations;
    using TraktApiSharp.Objects.Get.Shows.Implementations;

    /// <summary>Contains information about a movie or an episode a Trakt user is currently watching.</summary>
    public class TraktUserWatchingItem
    {
        /// <summary>Gets or sets the UTC datetime, when the movie or episode started.</summary>
        [JsonProperty(PropertyName = "started_at")]
        public DateTime? StartedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the movie or episode expires.</summary>
        [JsonProperty(PropertyName = "expires_at")]
        public DateTime? ExpiresAt { get; set; }

        /// <summary>
        /// Gets or sets the action type for the movie or episode.
        /// See also <seealso cref="TraktHistoryActionType" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "action")]
        [JsonConverter(typeof(TraktEnumerationConverter<TraktHistoryActionType>))]
        public TraktHistoryActionType Action { get; set; }

        /// <summary>
        /// Gets or sets the object type, which this watching item contains.
        /// See also <seealso cref="TraktSyncType" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof(TraktEnumerationConverter<TraktSyncType>))]
        public TraktSyncType Type { get; set; }

        /// <summary>
        /// Gets or sets the movie, if <see cref="Type" /> is <see cref="TraktSyncType.Movie" />.
        /// See also <seealso cref="TraktMovie" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "movie")]
        public TraktMovie Movie { get; set; }

        /// <summary>
        /// Gets or sets the show, if <see cref="Type" /> is <see cref="TraktSyncType.Episode" />.
        /// See also <seealso cref="TraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "show")]
        public TraktShow Show { get; set; }

        /// <summary>
        /// Gets or sets the episode, if <see cref="Type" /> is <see cref="TraktSyncType.Episode" />.
        /// See also <seealso cref="TraktEpisode" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "episode")]
        public TraktEpisode Episode { get; set; }
    }
}
