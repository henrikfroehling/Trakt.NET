namespace TraktNet.Objects.Post.Syncs.Collection
{
    using Basic;
    using Get.Episodes;
    using System;

    public interface ITraktSyncCollectionPostEpisode : ITraktMetadata
    {
        DateTime? CollectedAt { get; set; }

        ITraktEpisodeIds Ids { get; set; }
    }
}
