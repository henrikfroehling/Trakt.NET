namespace TraktApiSharp.Objects.Post.Syncs.Collection.Responses
{
    using Newtonsoft.Json;
    using Syncs.Responses;

    public class TraktSyncCollectionPostResponse
    {
        [JsonProperty(PropertyName = "added")]
        public TraktSyncPostResponseGroup Added { get; set; }

        [JsonProperty(PropertyName = "updated")]
        public TraktSyncPostResponseGroup Updated { get; set; }

        [JsonProperty(PropertyName = "existing")]
        public TraktSyncPostResponseGroup Existing { get; set; }

        [JsonProperty(PropertyName = "not_found")]
        public TraktSyncPostResponseNotFound NotFound { get; set; }
    }
}
