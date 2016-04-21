namespace TraktApiSharp.Objects.Post.Syncs.History
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktSyncHistoryRemovePost : TraktSyncHistoryPost
    {
        [JsonProperty(PropertyName = "ids")]
        public IEnumerable<int> HistoryIds { get; set; }
    }
}
