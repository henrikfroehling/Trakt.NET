namespace TraktNet.Objects.Post.Syncs.Collection
{
    using Get.Episodes;
    using Objects.Basic;
    using System;

    /// <summary>
    /// A Trakt collection post episode, containing the required episode ids,
    /// optional metadata and an optional datetime, when the episode was collected.
    /// </summary>
    public interface ITraktSyncCollectionPostEpisode : ITraktMetadata
    {
        /// <summary>Gets or sets the optional UTC datetime, when the Trakt episode was collected.</summary>
        DateTime? CollectedAt { get; set; }

        /// <summary>Gets or sets the required episode ids. See also <seealso cref="ITraktEpisodeIds" />.</summary>
        ITraktEpisodeIds Ids { get; set; }
    }
}
