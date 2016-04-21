namespace TraktApiSharp.Objects.Post.Syncs.History
{
    using Get.Shows.Episodes;
    using Newtonsoft.Json;
    using System;

    public class TraktSyncHistoryPostEpisodeItem
    {
        [JsonProperty(PropertyName = "watched_at")]
        public DateTime? WatchedAt { get; set; }

        [JsonProperty(PropertyName = "ids")]
        public TraktEpisodeIds Ids { get; set; }
    }
}
