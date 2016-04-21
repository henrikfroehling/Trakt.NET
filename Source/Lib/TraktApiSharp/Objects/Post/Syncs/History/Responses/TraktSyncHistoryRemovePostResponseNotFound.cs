namespace TraktApiSharp.Objects.Post.Syncs.History.Responses
{
    using Newtonsoft.Json;
    using Syncs.Responses;
    using System.Collections.Generic;

    public class TraktSyncHistoryRemovePostResponseNotFound : TraktSyncPostResponseNotFound
    {
        [JsonProperty(PropertyName = "ids")]
        public IEnumerable<int> Ids { get; set; }
    }
}
