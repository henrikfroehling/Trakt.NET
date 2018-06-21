namespace TraktNet.Objects.Post.Syncs.Collection
{
    using Basic;
    using Get.Shows;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A Trakt collection post show, containing the required show ids,
    /// optional metadata and an optional datetime, when the show was collected.
    /// <para>Can also contain optional seasons.</para>
    /// </summary>
    public class TraktSyncCollectionPostShow : ITraktSyncCollectionPostShow
    {
        /// <summary>Gets or sets the optional UTC datetime, when the Trakt show was collected.</summary>
        public DateTime? CollectedAt { get; set; }

        /// <summary>Gets or sets the optional title of the Trakt show.<para>Nullable</para></summary>
        public string Title { get; set; }

        /// <summary>Gets or sets the optional year of the Trakt show.</summary>
        public int? Year { get; set; }

        /// <summary>Gets or sets the required show ids. See also <seealso cref="ITraktShowIds" />.</summary>
        public ITraktShowIds Ids { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncCollectionPostShowSeason" />s.
        /// <para>
        /// If no seasons are set, the whole Trakt show will be added to the collection.
        /// Otherwise, only the specified seasons and / or episodes will be added to the collection.
        /// </para>
        /// </summary>
        public IEnumerable<ITraktSyncCollectionPostShowSeason> Seasons { get; set; }

        /// <summary>
        /// Gets or sets optional metadata about the Trakt show. See also <seealso cref="ITraktMetadata" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktMetadata Metadata { get; set; }
    }
}
