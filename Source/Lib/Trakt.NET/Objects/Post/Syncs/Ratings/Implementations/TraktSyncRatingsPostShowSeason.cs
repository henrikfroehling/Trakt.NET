namespace TraktNet.Objects.Post.Syncs.Ratings
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A Trakt ratings post season, containing the required season number and optional episodes,
    /// a rating and an optional datetime, when the season was rated.
    /// </summary>
    public class TraktSyncRatingsPostShowSeason : ITraktSyncRatingsPostShowSeason
    {
        /// <summary>Gets or sets the required season number of the Trakt season.</summary>
        public int Number { get; set; }

        /// <summary>Gets or sets the rating for the season.</summary>
        public int? Rating { get; set; }

        /// <summary>Gets or sets the optional UTC datetime, when the Trakt season was rated.</summary>
        public DateTime? RatedAt { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncRatingsPostShowEpisode" />s.
        /// <para>
        /// If no episodes are set, the whole Trakt season will be added to the ratings.
        /// Otherwise, only the specified episodes will be added to the ratings.
        /// </para>
        /// </summary>
        public IList<ITraktSyncRatingsPostShowEpisode> Episodes { get; set; }
    }
}
