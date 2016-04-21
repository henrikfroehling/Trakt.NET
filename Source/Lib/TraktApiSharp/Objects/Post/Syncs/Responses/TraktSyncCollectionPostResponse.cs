namespace TraktApiSharp.Objects.Post.Syncs.Responses
{
    using Newtonsoft.Json;

    public class TraktSyncCollectionPostResponse
    {
        [JsonProperty(PropertyName = "added")]
        public TraktSyncCollectionPostResponseGroup Added { get; set; }

        [JsonProperty(PropertyName = "updated")]
        public TraktSyncCollectionPostResponseGroup Updated { get; set; }

        [JsonProperty(PropertyName = "existing")]
        public TraktSyncCollectionPostResponseGroup Existing { get; set; }

        [JsonProperty(PropertyName = "not_found")]
        public TraktSyncCollectionPostResponseNotFound NotFound { get; set; }
    }
}
