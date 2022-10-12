namespace TraktNet.Objects.Post.Syncs.History
{
    /// <summary>A Trakt history remove post episode, containing the required episode number.</summary>
    public interface ITraktSyncHistoryRemovePostShowEpisode
    {
        /// <summary>Gets or sets the required season number of the Trakt episode.</summary>
        int Number { get; set; }
    }
}
