namespace TraktApiSharp.Objects.Post.Syncs.Watchlist
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktSyncWatchlistPostShowSeason
    {
        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktSyncWatchlistPostShowEpisode> Episodes { get; set; }
    }
}
