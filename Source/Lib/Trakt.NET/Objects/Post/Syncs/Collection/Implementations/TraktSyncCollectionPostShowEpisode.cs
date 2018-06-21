namespace TraktNet.Objects.Post.Syncs.Collection
{
    /// <summary>A Trakt collection post episode, containing the required episode number.</summary>
    public class TraktSyncCollectionPostShowEpisode : ITraktSyncCollectionPostShowEpisode
    {
        /// <summary>Gets or sets the required season number of the Trakt episode.</summary>
        public int Number { get; set; }
    }
}
