namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses
{
    using Attributes;
    using Newtonsoft.Json;
    using Syncs.Responses;

    public class TraktSyncRatingsPostResponse
    {
        [JsonProperty(PropertyName = "added")]
        [Nullable]
        public TraktSyncPostResponseGroup Added { get; set; }

        [JsonProperty(PropertyName = "not_found")]
        [Nullable]
        public TraktSyncRatingsPostResponseNotFound NotFound { get; set; }
    }
}
