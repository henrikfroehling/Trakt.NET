namespace TraktApiSharp.Objects.Post.Syncs.History.Respones
{
    using Newtonsoft.Json;
    using Responses;

    public class TraktSyncHistoryPostResponse
    {
        [JsonProperty(PropertyName = "added")]
        public TraktSyncPostResponseGroup Added { get; set; }

        [JsonProperty(PropertyName = "not_found")]
        public TraktSyncPostResponseNotFound NotFound { get; set; }
    }
}
