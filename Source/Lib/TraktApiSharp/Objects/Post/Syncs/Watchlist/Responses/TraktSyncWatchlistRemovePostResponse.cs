namespace TraktApiSharp.Objects.Post.Syncs.Watchlist.Responses
{
    using Newtonsoft.Json;
    using Syncs.Responses;

    public class TraktSyncWatchlistRemovePostResponse
    {
        [JsonProperty(PropertyName = "deleted")]
        public TraktSyncPostResponseGroup Deleted { get; set; }

        [JsonProperty(PropertyName = "not_found")]
        public TraktSyncPostResponseNotFound NotFound { get; set; }
    }
}
