namespace TraktApiSharp.Objects.Post.Syncs.Watchlist
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktSyncWatchlistPost
    {
        [JsonProperty(PropertyName = "movies")]
        public IEnumerable<TraktSyncWatchlistPostMovie> Movies { get; set; }

        [JsonProperty(PropertyName = "shows")]
        public IEnumerable<TraktSyncWatchlistPostShow> Shows { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktSyncWatchlistPostEpisode> Episodes { get; set; }
    }
}
