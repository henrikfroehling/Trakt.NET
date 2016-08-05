namespace TraktApiSharp.Objects.Post.Syncs.Watchlist
{
    using Attributes;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktSyncWatchlistPostShowSeason
    {
        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        [Nullable]
        public IEnumerable<TraktSyncWatchlistPostShowEpisode> Episodes { get; set; }
    }
}
