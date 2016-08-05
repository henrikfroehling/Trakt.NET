namespace TraktApiSharp.Objects.Post.Syncs.History.Responses
{
    using Attributes;
    using Newtonsoft.Json;
    using Syncs.Responses;

    public class TraktSyncHistoryPostResponse
    {
        [JsonProperty(PropertyName = "added")]
        [Nullable]
        public TraktSyncPostResponseGroup Added { get; set; }

        [JsonProperty(PropertyName = "not_found")]
        [Nullable]
        public TraktSyncPostResponseNotFound NotFound { get; set; }
    }
}
