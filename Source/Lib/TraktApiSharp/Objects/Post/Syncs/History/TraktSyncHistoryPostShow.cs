namespace TraktApiSharp.Objects.Post.Syncs.History
{
    using Attributes;
    using Get.Shows;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class TraktSyncHistoryPostShow
    {
        [JsonProperty(PropertyName = "watched_at")]
        public DateTime? WatchedAt { get; set; }

        [JsonProperty(PropertyName = "title")]
        [Nullable]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "year")]
        public int? Year { get; set; }

        [JsonProperty(PropertyName = "ids")]
        public TraktShowIds Ids { get; set; }

        [JsonProperty(PropertyName = "seasons")]
        [Nullable]
        public IEnumerable<TraktSyncHistoryPostShowSeason> Seasons { get; set; }
    }
}
