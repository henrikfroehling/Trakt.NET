namespace TraktNet.Objects.Post.Syncs.Ratings
{
    using System;

    /// <summary>
    /// A Trakt ratings post episode, containing the required episode number,
    /// an optional rating and an optional datetime, when the episode was rated.
    /// </summary>
    public interface ITraktSyncRatingsPostShowEpisode
    {
        /// <summary>Gets or sets the optional UTC datetime, when the Trakt episode was rated.</summary>
        DateTime? RatedAt { get; set; }

        /// <summary>Gets or sets an optional rating for the episode.</summary>
        int? Rating { get; set; }

        /// <summary>Gets or sets the required season number of the Trakt episode.</summary>
        int Number { get; set; }
    }
}
