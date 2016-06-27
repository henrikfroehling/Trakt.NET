namespace TraktApiSharp.Objects.Post.Syncs.Watchlist
{
    using Get.Shows.Episodes;
    using Newtonsoft.Json;

    public class TraktSyncWatchlistPostEpisode
    {
        [JsonProperty(PropertyName = "ids")]
        public TraktEpisodeIds Ids { get; set; }
    }
}
