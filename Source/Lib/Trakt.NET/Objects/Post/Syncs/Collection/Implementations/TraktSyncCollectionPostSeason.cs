namespace TraktNet.Objects.Post.Syncs.Collection
{
    using Get.Seasons;
    using Objects.Basic;
    using System;

    /// <summary>
    /// A Trakt collection post season, containing the required season ids,
    /// optional metadata and an optional datetime, when the season was collected.
    /// </summary>
    public class TraktSyncCollectionPostSeason : TraktMetadata, ITraktSyncCollectionPostSeason
    {
        /// <summary>Gets or sets the optional UTC datetime, when the Trakt season was collected.</summary>
        public DateTime? CollectedAt { get; set; }

        /// <summary>Gets or sets the required season ids. See also <seealso cref="ITraktSeasonIds" />.</summary>
        public ITraktSeasonIds Ids { get; set; }
    }
}
