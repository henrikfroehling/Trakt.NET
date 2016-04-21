namespace TraktApiSharp.Objects.Post.Syncs.Watchlist
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktSyncWatchlistPostShowSeasonItem
    {
        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktSyncWatchlistPostShowEpisodeItem> Episodes { get; set; }
    }
}
