namespace TraktApiSharp.Objects.Post.Syncs.History
{
    using Attributes;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class TraktSyncHistoryPostShowSeason
    {
        [JsonProperty(PropertyName = "watched_at")]
        public DateTime? WatchedAt { get; set; }

        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        [Nullable]
        public IEnumerable<TraktSyncHistoryPostShowEpisode> Episodes { get; set; }
    }
}
