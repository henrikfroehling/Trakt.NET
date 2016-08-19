namespace TraktApiSharp.Objects.Post.Syncs.History.Responses
{
    using Attributes;
    using Newtonsoft.Json;
    using Syncs.Responses;
    using System.Collections.Generic;

    public class TraktSyncHistoryRemovePostResponseNotFound : TraktSyncPostResponseNotFound
    {
        [JsonProperty(PropertyName = "ids")]
        [Nullable]
        public IEnumerable<uint> Ids { get; set; }
    }
}
