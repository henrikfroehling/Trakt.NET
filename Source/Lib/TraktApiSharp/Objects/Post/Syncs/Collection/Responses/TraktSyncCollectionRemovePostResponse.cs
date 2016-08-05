namespace TraktApiSharp.Objects.Post.Syncs.Collection.Responses
{
    using Attributes;
    using Newtonsoft.Json;
    using Syncs.Responses;

    public class TraktSyncCollectionRemovePostResponse
    {
        [JsonProperty(PropertyName = "deleted")]
        [Nullable]
        public TraktSyncPostResponseGroup Deleted { get; set; }

        [JsonProperty(PropertyName = "not_found")]
        [Nullable]
        public TraktSyncPostResponseNotFound NotFound { get; set; }
    }
}
