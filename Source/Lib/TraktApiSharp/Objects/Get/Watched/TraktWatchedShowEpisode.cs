namespace TraktApiSharp.Objects.Get.Watched
{
    using Newtonsoft.Json;
    using System;

    /// <summary>Contains information about a watched Trakt episode.</summary>
    public class TraktWatchedShowEpisode
    {
        /// <summary>Gets or sets the number of the watched episode.</summary>
        [JsonProperty(PropertyName = "number")]
        public int? Number { get; set; }

        /// <summary>Gets or sets the number of plays for the watched episode.</summary>
        [JsonProperty(PropertyName = "plays")]
        public int? Plays { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the episode was last watched.</summary>
        [JsonProperty(PropertyName = "last_watched_at")]
        public DateTime? LastWatchedAt { get; set; }
    }
}
