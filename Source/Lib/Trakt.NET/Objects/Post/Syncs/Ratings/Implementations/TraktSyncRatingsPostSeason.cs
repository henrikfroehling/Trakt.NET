namespace TraktNet.Objects.Post.Syncs.Ratings
{
    using Get.Seasons;
    using System;

    /// <summary>
    /// A Trakt ratings post season, containing the required season ids,
    /// a rating and an optional datetime, when the season was rated.
    /// </summary>
    public class TraktSyncRatingsPostSeason : ITraktSyncRatingsPostSeason
    {
        /// <summary>Gets or sets the required season ids. See also <seealso cref="ITraktSeasonIds" />.</summary>
        public ITraktSeasonIds Ids { get; set; }

        /// <summary>Gets or sets the rating for the season.</summary>
        public int Rating { get; set; }

        /// <summary>Gets or sets the optional UTC datetime, when the Trakt season was rated.</summary>
        public DateTime? RatedAt { get; set; }
    }
}
