namespace TraktApiSharp.Objects.Get.Syncs.Activities
{
    using Newtonsoft.Json;
    using System;

    /// <summary>A collection of UTC datetimes of last activities for episodes.</summary>
    public class TraktSyncEpisodesLastActivities
    {
        /// <summary>Gets or sets the UTC datetime, when an episode was lastly watched.</summary>
        [JsonProperty(PropertyName = "watched_at")]
        public DateTime? WatchedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when an episode was lastly collected.</summary>
        [JsonProperty(PropertyName = "collected_at")]
        public DateTime? CollectedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when an episode was lastly rated.</summary>
        [JsonProperty(PropertyName = "rated_at")]
        public DateTime? RatedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when an episode was lastly added to the watchlist.</summary>
        [JsonProperty(PropertyName = "watchlisted_at")]
        public DateTime? WatchlistedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when an episode was lastly commented.</summary>
        [JsonProperty(PropertyName = "commented_at")]
        public DateTime? CommentedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when an episode was lastly paused.</summary>
        [JsonProperty(PropertyName = "paused_at")]
        public DateTime? PausedAt { get; set; }
    }
}
