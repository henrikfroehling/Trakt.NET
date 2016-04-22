namespace TraktApiSharp.Objects.Get.Shows.Episodes
{
    using Newtonsoft.Json;
    using System;

    public class TraktEpisodeWatchedProgress : TraktEpisodeProgress
    {
        [JsonProperty(PropertyName = "last_watched_at")]
        public DateTime? LastWatchedAt { get; set; }
    }
}
