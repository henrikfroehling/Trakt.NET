namespace TraktApiSharp.Objects.Get.Shows.Episodes
{
    using Newtonsoft.Json;
    using System;

    /// <summary>Represents the watched progress of a Trakt episode.</summary>
    public class TraktEpisodeWatchedProgress : TraktEpisodeProgress
    {
        /// <summary>Gets or sets the UTC datetime, when the last watch occured.</summary>
        [JsonProperty(PropertyName = "last_watched_at")]
        public DateTime? LastWatchedAt { get; set; }
    }
}
