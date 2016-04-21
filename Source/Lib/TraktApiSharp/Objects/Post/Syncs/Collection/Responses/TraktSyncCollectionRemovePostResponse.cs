namespace TraktApiSharp.Objects.Post.Syncs.Collection.Responses
{
    using Newtonsoft.Json;
    using Syncs.Responses;

    public class TraktSyncCollectionRemovePostResponse
    {
        [JsonProperty(PropertyName = "deleted")]
        public TraktSyncPostResponseGroup Deleted { get; set; }

        [JsonProperty(PropertyName = "not_found")]
        public TraktSyncPostResponseNotFound NotFound { get; set; }
    }
}
