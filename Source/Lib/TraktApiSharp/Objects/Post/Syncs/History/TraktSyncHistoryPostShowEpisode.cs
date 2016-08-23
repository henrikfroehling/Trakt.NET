namespace TraktApiSharp.Objects.Post.Syncs.History
{
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// A Trakt history post episode, containing the required episode number
    /// and an optional datetime, when the episode was watched.
    /// </summary>
    public class TraktSyncHistoryPostShowEpisode
    {
        /// <summary>Gets or sets the optional UTC datetime, when the Trakt episode was watched.</summary>
        [JsonProperty(PropertyName = "watched_at")]
        public DateTime? WatchedAt { get; set; }

        /// <summary>Gets or sets the required season number of the Trakt episode.</summary>
        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }
    }
}
