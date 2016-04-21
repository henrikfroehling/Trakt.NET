namespace TraktApiSharp.Objects.Post.Syncs.History.Responses
{
    using Newtonsoft.Json;
    using Syncs.Responses;

    public class TraktSyncHistoryRemovePostResponse
    {
        [JsonProperty(PropertyName = "deleted")]
        public TraktSyncPostResponseGroup Deleted { get; set; }

        [JsonProperty(PropertyName = "not_found")]
        public TraktSyncHistoryRemovePostResponseNotFound NotFound { get; set; }
    }
}
