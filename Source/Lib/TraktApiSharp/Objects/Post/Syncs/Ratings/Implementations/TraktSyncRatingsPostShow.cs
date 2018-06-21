namespace TraktNet.Objects.Post.Syncs.Ratings
{
    using Get.Shows;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A Trakt ratings post show, containing the required show ids,
    /// an optional rating and an optional datetime, when the show was rated.
    /// <para>Can also contain optional seasons.</para>
    /// </summary>
    public class TraktSyncRatingsPostShow : ITraktSyncRatingsPostShow
    {
        /// <summary>Gets or sets the optional UTC datetime, when the Trakt show was rated.</summary>
        public DateTime? RatedAt { get; set; }

        /// <summary>Gets or sets an optional rating for the show.</summary>
        public int? Rating { get; set; }

        /// <summary>Gets or sets the optional title of the Trakt show.<para>Nullable</para></summary>
        public string Title { get; set; }

        /// <summary>Gets or sets the optional year of the Trakt show.</summary>
        public int? Year { get; set; }

        /// <summary>Gets or sets the required show ids. See also <seealso cref="ITraktShowIds" />.</summary>
        public ITraktShowIds Ids { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncRatingsPostShowSeason" />s.
        /// <para>
        /// If no seasons are set, the whole Trakt show will be added to the ratings.
        /// Otherwise, only the specified seasons and / or episodes will be added to the ratings.
        /// </para>
        /// </summary>
        public IEnumerable<ITraktSyncRatingsPostShowSeason> Seasons { get; set; }
    }
}
