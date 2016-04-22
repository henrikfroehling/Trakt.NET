namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses
{
    using Newtonsoft.Json;
    using Syncs.Responses;

    public class TraktSyncRatingsRemovePostResponse
    {
        [JsonProperty(PropertyName = "deleted")]
        public TraktSyncPostResponseGroup Deleted { get; set; }

        [JsonProperty(PropertyName = "not_found")]
        public TraktSyncPostResponseNotFound NotFound { get; set; }
    }
}
