namespace TraktApiSharp.Objects.Post.Syncs.Watchlist
{
    using Newtonsoft.Json;

    /// <summary>A Trakt watchlist post episode, containing the required episode number.</summary>
    public class TraktSyncWatchlistPostShowEpisode
    {
        /// <summary>Gets or sets the required season number of the Trakt episode.</summary>
        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }
    }
}
