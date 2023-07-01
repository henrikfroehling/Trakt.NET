namespace TraktNet.Objects.Get.Syncs.Activities
{
    using System;

    /// <summary>A collection of UTC datetimes of last activities for movies.</summary>
    public class TraktSyncMoviesLastActivities : ITraktSyncMoviesLastActivities
    {
        /// <summary>Gets or sets the UTC datetime, when a movie was lastly watched.</summary>
        public DateTime? WatchedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when a movie was lastly collected.</summary>
        public DateTime? CollectedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when a movie was lastly rated.</summary>
        public DateTime? RatedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when a movie was lastly added to the watchlist.</summary>
        public DateTime? WatchlistedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when a movie was lastly favorited.</summary>
        public DateTime? FavoritedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when a movie was lastly recommended.</summary>
        public DateTime? RecommendationsAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when a movie was lastly commented.</summary>
        public DateTime? CommentedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when a movie was lastly paused.</summary>
        public DateTime? PausedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when a movie was lastly hidden.</summary>
        public DateTime? HiddenAt { get; set; }
    }
}
