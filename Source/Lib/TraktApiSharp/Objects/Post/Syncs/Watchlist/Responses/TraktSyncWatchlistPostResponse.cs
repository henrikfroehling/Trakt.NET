namespace TraktApiSharp.Objects.Post.Syncs.Watchlist.Responses
{
    using Newtonsoft.Json;
    using Syncs.Responses;

    public class TraktSyncWatchlistPostResponse
    {
        [JsonProperty(PropertyName = "added")]
        public TraktSyncPostResponseGroup Added { get; set; }

        [JsonProperty(PropertyName = "existing")]
        public TraktSyncPostResponseGroup Existing { get; set; }

        [JsonProperty(PropertyName = "not_found")]
        public TraktSyncPostResponseNotFound NotFound { get; set; }
    }
}
