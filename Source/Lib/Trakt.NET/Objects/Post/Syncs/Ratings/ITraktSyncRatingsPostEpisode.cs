namespace TraktNet.Objects.Post.Syncs.Ratings
{
    using Get.Episodes;
    using System;

    /// <summary>
    /// A Trakt ratings post episode, containing the required episode ids,
    /// a rating and an optional datetime, when the episode was rated.
    /// </summary>
    public interface ITraktSyncRatingsPostEpisode
    {
        /// <summary>Gets or sets the required episode ids. See also <seealso cref="ITraktEpisodeIds" />.</summary>
        ITraktEpisodeIds Ids { get; set; }

        /// <summary>Gets or sets the rating for the episode.</summary>
        int Rating { get; set; }

        /// <summary>Gets or sets the optional UTC datetime, when the Trakt episode was rated.</summary>
        DateTime? RatedAt { get; set; }
    }
}
