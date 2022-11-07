namespace TraktNet.Objects.Post.Syncs.History
{
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Shows;

    /// <summary>
    /// A Trakt history post show, containing the required show ids.
    /// <para>Can also contain optional seasons.</para>
    /// </summary>
    public class TraktSyncHistoryRemovePostShow : ITraktSyncHistoryRemovePostShow
    {
        /// <summary>Gets or sets the optional title of the Trakt show.<para>Nullable</para></summary>
        public string Title { get; set; }

        /// <summary>Gets or sets the optional year of the Trakt show.</summary>
        public int? Year { get; set; }

        /// <summary>Gets or sets the required show ids. See also <seealso cref="ITraktShowIds" />.</summary>
        public ITraktShowIds Ids { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncHistoryRemovePostShowSeason" />s.
        /// <para>
        /// If no seasons are set, the whole Trakt show will be added to the history.
        /// Otherwise, only the specified seasons and / or episodes will be added to the history.
        /// </para>
        /// </summary>
        public IEnumerable<ITraktSyncHistoryRemovePostShowSeason> Seasons { get; set; }
    }
}
