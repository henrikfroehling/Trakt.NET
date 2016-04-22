namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses
{
    using Newtonsoft.Json;
    using Syncs.Responses;

    public class TraktSyncRatingsPostResponse
    {
        [JsonProperty(PropertyName = "added")]
        public TraktSyncPostResponseGroup Added { get; set; }

        [JsonProperty(PropertyName = "not_found")]
        public TraktSyncRatingsPostResponseNotFound NotFound { get; set; }
    }
}
