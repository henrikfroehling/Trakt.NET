namespace TraktApiSharp.Objects.Post.Syncs.Watchlist.Responses
{
    using Attributes;
    using Newtonsoft.Json;
    using Syncs.Responses;

    public class TraktSyncWatchlistPostResponse
    {
        [JsonProperty(PropertyName = "added")]
        [Nullable]
        public TraktSyncPostResponseGroup Added { get; set; }

        [JsonProperty(PropertyName = "existing")]
        [Nullable]
        public TraktSyncPostResponseGroup Existing { get; set; }

        [JsonProperty(PropertyName = "not_found")]
        [Nullable]
        public TraktSyncPostResponseNotFound NotFound { get; set; }
    }
}
