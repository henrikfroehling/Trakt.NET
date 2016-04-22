namespace TraktApiSharp.Objects.Post.Syncs.Watchlist
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktSyncWatchlistPost
    {
        [JsonProperty(PropertyName = "movies")]
        public IEnumerable<TraktSyncWatchlistPostMovieItem> Movies { get; set; }

        [JsonProperty(PropertyName = "shows")]
        public IEnumerable<TraktSyncWatchlistPostShowItem> Shows { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktSyncWatchlistPostEpisodeItem> Episodes { get; set; }
    }
}
