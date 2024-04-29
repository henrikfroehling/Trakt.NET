﻿namespace TraktNet.Objects.Post.Syncs.Watchlist
{
    using Get.Shows;
    using System.Collections.Generic;

    /// <summary>
    /// A Trakt watchlist post show, containing the required show ids.
    /// <para>Can also contain optional seasons.</para>
    /// </summary>
    public interface ITraktSyncWatchlistPostShow
    {
        /// <summary>Gets or sets the optional title of the Trakt show.<para>Nullable</para></summary>
        string Title { get; set; }

        /// <summary>Gets or sets the optional year of the Trakt show.</summary>
        int? Year { get; set; }

        /// <summary>Gets or sets the required show ids. See also <seealso cref="ITraktShowIds" />.</summary>
        ITraktShowIds Ids { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncWatchlistPostShowSeason" />s.
        /// <para>
        /// If no seasons are set, the whole Trakt show will be added to the watchlist.
        /// Otherwise, only the specified seasons and / or episodes will be added to the watchlist.
        /// </para>
        /// </summary>
        IList<ITraktSyncWatchlistPostShowSeason> Seasons { get; set; }

        /// <summary>Gets or sets the show notes.</summary>
        string Notes { get; set; }
    }
}
