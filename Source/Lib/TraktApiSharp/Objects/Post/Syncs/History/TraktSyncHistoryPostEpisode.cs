namespace TraktApiSharp.Objects.Post.Syncs.History
{
    using Get.Shows.Episodes;
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// A Trakt history post episode, containing the required episode ids
    /// and an optional datetime, when the episode was watched.
    /// </summary>
    public class TraktSyncHistoryPostEpisode
    {
        /// <summary>Gets or sets the optional UTC datetime, when the Trakt episode was watched.</summary>
        [JsonProperty(PropertyName = "watched_at")]
        public DateTime? WatchedAt { get; set; }

        /// <summary>Gets or sets the required episode ids. See also <seealso cref="TraktEpisodeIds" />.</summary>
        [JsonProperty(PropertyName = "ids")]
        public TraktEpisodeIds Ids { get; set; }
    }
}
