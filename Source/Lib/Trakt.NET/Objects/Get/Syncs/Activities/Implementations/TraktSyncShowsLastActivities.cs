namespace TraktNet.Objects.Get.Syncs.Activities
{
    using System;

    /// <summary>A collection of UTC datetimes of last activities for shows.</summary>
    public class TraktSyncShowsLastActivities : ITraktSyncShowsLastActivities
    {
        /// <summary>Gets or sets the UTC datetime, when a show was lastly rated.</summary>
        public DateTime? RatedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when a show was lastly added to the watchlist.</summary>
        public DateTime? WatchlistedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when a show was lastly commented.</summary>
        public DateTime? CommentedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when a show was lastly hidden.</summary>
        public DateTime? HiddenAt { get; set; }
    }
}
