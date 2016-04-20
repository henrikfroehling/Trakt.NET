namespace TraktApiSharp.Objects.Get.Syncs
{
    using Newtonsoft.Json;
    using System;

    public class TraktSyncShowsLastActivities
    {
        [JsonProperty(PropertyName = "rated_at")]
        public DateTime? RatedAt { get; set; }

        [JsonProperty(PropertyName = "watchlisted_at")]
        public DateTime? WatchlistedAt { get; set; }

        [JsonProperty(PropertyName = "commented_at")]
        public DateTime? CommentedAt { get; set; }
    }
}
