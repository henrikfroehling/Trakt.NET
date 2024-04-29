﻿namespace TraktNet.Objects.Post.Syncs.Ratings
{
    using Get.Shows;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A Trakt ratings post show, containing the required show ids,
    /// a rating and an optional datetime, when the show was rated.
    /// <para>Can also contain optional seasons.</para>
    /// </summary>
    public interface ITraktSyncRatingsPostShow
    {
        /// <summary>Gets or sets the optional title of the Trakt show.<para>Nullable</para></summary>
        string Title { get; set; }

        /// <summary>Gets or sets the optional year of the Trakt show.</summary>
        int? Year { get; set; }

        /// <summary>Gets or sets the required show ids. See also <seealso cref="ITraktShowIds" />.</summary>
        ITraktShowIds Ids { get; set; }

        /// <summary>Gets or sets the rating for the show.</summary>
        int? Rating { get; set; }

        /// <summary>Gets or sets the optional UTC datetime, when the Trakt show was rated.</summary>
        DateTime? RatedAt { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncRatingsPostShowSeason" />s.
        /// <para>
        /// If no seasons are set, the whole Trakt show will be added to the ratings.
        /// Otherwise, only the specified seasons and / or episodes will be added to the ratings.
        /// </para>
        /// </summary>
        IList<ITraktSyncRatingsPostShowSeason> Seasons { get; set; }
    }
}
