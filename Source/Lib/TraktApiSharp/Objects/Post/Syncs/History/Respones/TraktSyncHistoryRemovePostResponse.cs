namespace TraktApiSharp.Objects.Post.Syncs.History.Respones
{
    using Newtonsoft.Json;
    using Responses;

    public class TraktSyncHistoryRemovePostResponse
    {
        [JsonProperty(PropertyName = "deleted")]
        public TraktSyncPostResponseGroup Deleted { get; set; }

        [JsonProperty(PropertyName = "not_found")]
        public TraktSyncHistoryRemovePostResponseNotFound NotFound { get; set; }
    }
}
