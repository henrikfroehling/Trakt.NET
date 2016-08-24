namespace TraktApiSharp.Objects.Post.Syncs.Watchlist
{
    using Get.Shows.Episodes;
    using Newtonsoft.Json;

    /// <summary>A Trakt watchlist post episode, containing the required episode ids.</summary>
    public class TraktSyncWatchlistPostEpisode
    {
        /// <summary>Gets or sets the required episode ids. See also <seealso cref="TraktEpisodeIds" />.</summary>
        [JsonProperty(PropertyName = "ids")]
        public TraktEpisodeIds Ids { get; set; }
    }
}
