namespace TraktNet.Objects.Post.Syncs.Collection
{
    using Basic;
    using System;

    /// <summary>A Trakt collection post episode, containing the required episode number.</summary>
    public class TraktSyncCollectionPostShowEpisode : TraktMetadata, ITraktSyncCollectionPostShowEpisode
    {
        /// <summary>Gets or sets the required season number of the Trakt episode.</summary>
        public int Number { get; set; }

        public DateTime? CollectedAt { get; set; }
    }
}
