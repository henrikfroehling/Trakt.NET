namespace TraktApiSharp.Objects.Post.Syncs.Collection.Responses
{
    using Attributes;
    using Newtonsoft.Json;
    using Syncs.Responses;

    public class TraktSyncCollectionPostResponse
    {
        [JsonProperty(PropertyName = "added")]
        [Nullable]
        public TraktSyncPostResponseGroup Added { get; set; }

        [JsonProperty(PropertyName = "updated")]
        [Nullable]
        public TraktSyncPostResponseGroup Updated { get; set; }

        [JsonProperty(PropertyName = "existing")]
        [Nullable]
        public TraktSyncPostResponseGroup Existing { get; set; }

        [JsonProperty(PropertyName = "not_found")]
        [Nullable]
        public TraktSyncPostResponseNotFound NotFound { get; set; }
    }
}
