namespace TraktApiSharp.Objects.Post.Syncs.History.Responses
{
    using Attributes;
    using Newtonsoft.Json;
    using Syncs.Responses;

    public class TraktSyncHistoryRemovePostResponse
    {
        [JsonProperty(PropertyName = "deleted")]
        [Nullable]
        public TraktSyncPostResponseGroup Deleted { get; set; }

        [JsonProperty(PropertyName = "not_found")]
        [Nullable]
        public TraktSyncHistoryRemovePostResponseNotFound NotFound { get; set; }
    }
}
