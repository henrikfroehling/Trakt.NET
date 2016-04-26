namespace TraktApiSharp.Objects.Post.Syncs.History
{
    using Get.Shows;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class TraktSyncHistoryPostShowItem
    {
        [JsonProperty(PropertyName = "watched_at")]
        public DateTime? WatchedAt { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "year")]
        public int? Year { get; set; }

        [JsonProperty(PropertyName = "ids")]
        public TraktShowIds Ids { get; set; }

        [JsonProperty(PropertyName = "seasons")]
        public IEnumerable<TraktSyncHistoryPostShowSeasonItem> Seasons { get; set; }
    }
}
