namespace TraktApiSharp.Objects.Post.Syncs.Collection
{
    using Basic;
    using Get.Episodes;
    using System;

    public interface ITraktSyncCollectionPostEpisode
    {
        DateTime? CollectedAt { get; set; }

        ITraktEpisodeIds Ids { get; set; }

        ITraktMetadata Metadata { get; set; }
    }
}
