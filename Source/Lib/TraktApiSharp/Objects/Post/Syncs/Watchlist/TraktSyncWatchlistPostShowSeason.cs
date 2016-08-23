namespace TraktApiSharp.Objects.Post.Syncs.Watchlist
{
    using Attributes;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>A Trakt watchlist post season, containing the required season number and optional episodes.</summary>
    public class TraktSyncWatchlistPostShowSeason
    {
        /// <summary>Gets or sets the required season number of the Trakt season.</summary>
        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncWatchlistPostShowEpisode" />s.
        /// <para>
        /// If no episodes are set, the whole Trakt season will be added to the watchlist.
        /// Otherwise, only the specified episodes will be added to the watchlist.
        /// </para>
        /// </summary>
        [JsonProperty(PropertyName = "episodes")]
        [Nullable]
        public IEnumerable<TraktSyncWatchlistPostShowEpisode> Episodes { get; set; }
    }
}
