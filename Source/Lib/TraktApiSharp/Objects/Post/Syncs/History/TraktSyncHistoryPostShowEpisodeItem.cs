namespace TraktApiSharp.Objects.Post.Syncs.History
{
    using Newtonsoft.Json;
    using System;

    public class TraktSyncHistoryPostShowEpisodeItem
    {
        [JsonProperty(PropertyName = "watched_at")]
        public DateTime? WatchedAt { get; set; }

        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }
    }
}
