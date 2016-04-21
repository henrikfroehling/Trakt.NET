namespace TraktApiSharp.Objects.Get.Syncs.Activities
{
    using Newtonsoft.Json;
    using System;

    public class TraktSyncEpisodesLastActivities
    {
        [JsonProperty(PropertyName = "watched_at")]
        public DateTime? WatchedAt { get; set; }

        [JsonProperty(PropertyName = "collected_at")]
        public DateTime? CollectedAt { get; set; }

        [JsonProperty(PropertyName = "rated_at")]
        public DateTime? RatedAt { get; set; }

        [JsonProperty(PropertyName = "watchlisted_at")]
        public DateTime? WatchlistedAt { get; set; }

        [JsonProperty(PropertyName = "commented_at")]
        public DateTime? CommentedAt { get; set; }

        [JsonProperty(PropertyName = "paused_at")]
        public DateTime? PausedAt { get; set; }
    }
}
