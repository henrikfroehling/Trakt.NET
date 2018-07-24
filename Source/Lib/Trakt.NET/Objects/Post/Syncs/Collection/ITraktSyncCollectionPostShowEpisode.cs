namespace TraktNet.Objects.Post.Syncs.Collection
{
    using Basic;
    using System;

    public interface ITraktSyncCollectionPostShowEpisode : ITraktMetadata
    {
        int Number { get; set; }

        DateTime? CollectedAt { get; set; }
    }
}
