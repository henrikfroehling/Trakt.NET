namespace TraktApiSharp.Objects.Post.Syncs.History
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktSyncHistoryPostShowSeasonItem
    {
        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktSyncHistoryPostShowEpisodeItem> Episodes { get; set; }
    }
}
