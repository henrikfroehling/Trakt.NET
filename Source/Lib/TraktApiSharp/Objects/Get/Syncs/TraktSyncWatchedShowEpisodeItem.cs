namespace TraktApiSharp.Objects.Get.Syncs
{
    using Newtonsoft.Json;
    using System;

    public class TraktSyncWatchedShowEpisodeItem
    {
        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }

        [JsonProperty(PropertyName = "plays")]
        public int Plays { get; set; }

        [JsonProperty(PropertyName = "last_watched_at")]
        public DateTime LastWatchedAt { get; set; }
    }
}
