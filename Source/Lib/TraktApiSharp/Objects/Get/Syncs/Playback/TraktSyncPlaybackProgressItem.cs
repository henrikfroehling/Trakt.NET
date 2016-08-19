namespace TraktApiSharp.Objects.Get.Syncs.Playback
{
    using Attributes;
    using Enums;
    using Movies;
    using Newtonsoft.Json;
    using Shows;
    using Shows.Episodes;
    using System;

    /// <summary>Contains information about a Trakt playback progress, including the corresponding movie or episode.</summary>
    public class TraktSyncPlaybackProgressItem
    {
        /// <summary>Gets or sets the id of this progress item.</summary>
        [JsonProperty(PropertyName = "id")]
        public uint Id { get; set; }

        /// <summary>
        /// Gets or sets a value between 0 and 100 representing the watched progress percentage
        /// of the movie or episode.
        /// </summary>
        [JsonProperty(PropertyName = "progress")]
        public float? Progress { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the watched movie or episode was paused.</summary>
        [JsonProperty(PropertyName = "paused_at")]
        public DateTime? PausedAt { get; set; }

        /// <summary>
        /// Gets or sets the object type, which this progress item contains.
        /// See also <seealso cref="TraktSyncType" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof(TraktEnumerationConverter<TraktSyncType>))]
        [Nullable]
        public TraktSyncType Type { get; set; }

        /// <summary>
        /// Gets or sets the movie, if <see cref="Type" /> is <see cref="TraktSyncType.Movie" />.
        /// See also <seealso cref="TraktMovie" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "movie")]
        [Nullable]
        public TraktMovie Movie { get; set; }

        /// <summary>
        /// Gets or sets the episode, if <see cref="Type" /> is <see cref="TraktSyncType.Episode" />.
        /// See also <seealso cref="TraktEpisode" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "episode")]
        [Nullable]
        public TraktEpisode Episode { get; set; }

        /// <summary>
        /// Gets or sets the show, if <see cref="Type" /> is <see cref="TraktSyncType.Episode" />.
        /// See also <seealso cref="TraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "show")]
        [Nullable]
        public TraktShow Show { get; set; }
    }
}
