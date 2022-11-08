namespace TraktNet.Objects.Post.Syncs.History
{
    using Get.Episodes;

    /// <summary>A Trakt history remove post episode, containing the required episode ids.</summary>
    public interface ITraktSyncHistoryRemovePostEpisode
    {
        /// <summary>Gets or sets the required episode ids. See also <seealso cref="ITraktEpisodeIds" />.</summary>
        ITraktEpisodeIds Ids { get; set; }
    }
}
