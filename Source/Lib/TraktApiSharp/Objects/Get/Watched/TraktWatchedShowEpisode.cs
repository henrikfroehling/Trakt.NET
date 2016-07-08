namespace TraktApiSharp.Objects.Get.Watched
{
    using Newtonsoft.Json;
    using System;

    public class TraktWatchedShowEpisode
    {
        [JsonProperty(PropertyName = "number")]
        public int? Number { get; set; }

        [JsonProperty(PropertyName = "plays")]
        public int? Plays { get; set; }

        [JsonProperty(PropertyName = "last_watched_at")]
        public DateTime? LastWatchedAt { get; set; }
    }
}
