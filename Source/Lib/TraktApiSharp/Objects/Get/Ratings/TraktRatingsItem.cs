namespace TraktApiSharp.Objects.Get.Ratings
{
    using Attributes;
    using Enums;
    using Movies;
    using Newtonsoft.Json;
    using Shows;
    using Shows.Episodes;
    using Shows.Seasons;
    using System;

    /// <summary>A Trakt rating item, containing a movie, show, season and / or episode and information about it.</summary>
    public class TraktRatingsItem
    {
        /// <summary>Gets or sets the UTC datetime, when the movie, show, season and / or episode was rated.</summary>
        [JsonProperty(PropertyName = "rated_at")]
        public DateTime? RatedAt { get; set; }

        /// <summary>Gets or sets the rating of the movie, show, season and / or episode.</summary>
        [JsonProperty(PropertyName = "rating")]
        public int? Rating { get; set; }

        /// <summary>
        /// Gets or sets the object type, which this rating item contains.
        /// See also <seealso cref="TraktSyncRatingsItemType" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof(TraktEnumerationConverter<TraktSyncRatingsItemType>))]
        [Nullable]
        public TraktSyncRatingsItemType Type { get; set; }

        /// <summary>
        /// Gets or sets the movie, if <see cref="Type" /> is <see cref="TraktSyncRatingsItemType.Movie" />.
        /// See also <seealso cref="TraktMovie" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "movie")]
        [Nullable]
        public TraktMovie Movie { get; set; }

        /// <summary>
        /// Gets or sets the show, if <see cref="Type" /> is <see cref="TraktSyncRatingsItemType.Show" />.
        /// May also be set, if <see cref="Type" /> is <see cref="TraktSyncRatingsItemType.Episode" /> or
        /// <see cref="TraktSyncRatingsItemType.Season" />.
        /// <para>See also <seealso cref="TraktShow" />.</para>
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "show")]
        [Nullable]
        public TraktShow Show { get; set; }

        /// <summary>
        /// Gets or sets the season, if <see cref="Type" /> is <see cref="TraktSyncRatingsItemType.Season" />.
        /// See also <seealso cref="TraktSeason" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "season")]
        [Nullable]
        public TraktSeason Season { get; set; }

        /// <summary>
        /// Gets or sets the episode, if <see cref="Type" /> is <see cref="TraktSyncRatingsItemType.Episode" />.
        /// See also <seealso cref="TraktEpisode" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "episode")]
        [Nullable]
        public TraktEpisode Episode { get; set; }
    }
}
