namespace TraktNet.Objects.Post.Syncs.History
{
    using Get.Seasons;
    using System;

    /// <summary>
    /// A Trakt history post season, containing the required season ids
    /// and an optional datetime, when the season was watched.
    /// </summary>
    public interface ITraktSyncHistoryPostSeason
    {
        /// <summary>Gets or sets the optional UTC datetime, when the Trakt season was watched.</summary>
        DateTime? WatchedAt { get; set; }

        /// <summary>Gets or sets the required season ids. See also <seealso cref="ITraktSeasonIds" />.</summary>
        ITraktSeasonIds Ids { get; set; }
    }
}
