namespace TraktApiSharp.Objects.Post.Syncs.History
{
    using Attributes;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A Trakt history post season, containing the required season number and optional episodes
    /// and an optional datetime, when the season was watched.
    /// </summary>
    public class TraktSyncHistoryPostShowSeason
    {
        /// <summary>Gets or sets the optional UTC datetime, when the Trakt season was watched.</summary>
        [JsonProperty(PropertyName = "watched_at")]
        public DateTime? WatchedAt { get; set; }

        /// <summary>Gets or sets the required season number of the Trakt season.</summary>
        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncHistoryPostShowEpisode" />s.
        /// <para>
        /// If no episodes are set, the whole Trakt season will be added to the history.
        /// Otherwise, only the specified episodes will be added to the history.
        /// </para>
        /// </summary>
        [JsonProperty(PropertyName = "episodes")]
        [Nullable]
        public IEnumerable<TraktSyncHistoryPostShowEpisode> Episodes { get; set; }
    }
}
