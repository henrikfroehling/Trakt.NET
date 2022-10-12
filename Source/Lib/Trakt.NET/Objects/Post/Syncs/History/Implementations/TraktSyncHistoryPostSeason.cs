﻿namespace TraktNet.Objects.Post.Syncs.History
{
    using System;

    /// <summary>
    /// A Trakt history post season, containing the required season ids
    /// and an optional datetime, when the season was watched.
    /// </summary>
    public class TraktSyncHistoryPostSeason : TraktSyncHistoryRemovePostSeason, ITraktSyncHistoryPostSeason
    {
        /// <summary>Gets or sets the optional UTC datetime, when the Trakt season was watched.</summary>
        public DateTime? WatchedAt { get; set; }
    }
}
