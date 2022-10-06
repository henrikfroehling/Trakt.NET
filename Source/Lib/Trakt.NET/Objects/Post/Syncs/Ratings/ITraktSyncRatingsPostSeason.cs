namespace TraktNet.Objects.Post.Syncs.Ratings
{
    using Get.Seasons;
    using System;

    /// <summary>
    /// A Trakt ratings post season, containing the required season ids,
    /// a rating and an optional datetime, when the season was rated.
    /// </summary>
    public interface ITraktSyncRatingsPostSeason
    {
        /// <summary>Gets or sets the required season ids. See also <seealso cref="ITraktSeasonIds" />.</summary>
        ITraktSeasonIds Ids { get; set; }

        /// <summary>Gets or sets the rating for the season.</summary>
        int Rating { get; set; }

        /// <summary>Gets or sets the optional UTC datetime, when the Trakt season was rated.</summary>
        DateTime? RatedAt { get; set; }
    }
}
