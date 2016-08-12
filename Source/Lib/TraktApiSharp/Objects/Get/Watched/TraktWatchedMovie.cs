namespace TraktApiSharp.Objects.Get.Watched
{
    using Attributes;
    using Movies;
    using Newtonsoft.Json;
    using System;

    /// <summary>Contains information about a watched Trakt movie.</summary>
    public class TraktWatchedMovie
    {
        /// <summary>Gets or sets the number of plays for the watched movie.</summary>
        [JsonProperty(PropertyName = "plays")]
        public int? Plays { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the movie was last watched.</summary>
        [JsonProperty(PropertyName = "last_watched_at")]
        public DateTime? LastWatchedAt { get; set; }

        /// <summary>Gets or sets the Trakt movie. See also <seealso cref="TraktMovie" />.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "movie")]
        [Nullable]
        public TraktMovie Movie { get; set; }
    }
}
