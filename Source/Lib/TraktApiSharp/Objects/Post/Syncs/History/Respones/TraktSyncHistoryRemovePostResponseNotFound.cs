namespace TraktApiSharp.Objects.Post.Syncs.History.Respones
{
    using Newtonsoft.Json;
    using Responses;
    using System.Collections.Generic;

    public class TraktSyncHistoryRemovePostResponseNotFound : TraktSyncPostResponseNotFound
    {
        [JsonProperty(PropertyName = "ids")]
        public IEnumerable<int> Ids { get; set; }
    }
}
