namespace TraktApiSharp.Objects.Post.Syncs.History
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class TraktSyncHistoryPostShowSeasonItem
    {
        [JsonProperty(PropertyName = "watched_at")]
        public DateTime? WatchedAt { get; set; }

        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktSyncHistoryPostShowEpisodeItem> Episodes { get; set; }
    }
}
