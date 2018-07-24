namespace TraktNet.Objects.Post.Syncs.Collection
{
    using Basic;
    using Get.Episodes;
    using System;

    /// <summary>
    /// A Trakt collection post episode, containing the required episode ids,
    /// optional metadata and an optional datetime, when the episode was collected.
    /// </summary>
    public class TraktSyncCollectionPostEpisode : TraktMetadata, ITraktSyncCollectionPostEpisode
    {
        /// <summary>Gets or sets the optional UTC datetime, when the Trakt episode was collected.</summary>
        public DateTime? CollectedAt { get; set; }

        /// <summary>Gets or sets the required episode ids. See also <seealso cref="ITraktEpisodeIds" />.</summary>
        public ITraktEpisodeIds Ids { get; set; }
    }
}
