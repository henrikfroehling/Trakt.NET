namespace TraktNet.Objects.Post.Syncs.History
{
    using TraktNet.Objects.Get.Episodes;

    /// <summary>A Trakt history remove post episode, containing the required episode ids.</summary>
    public class TraktSyncHistoryRemovePostEpisode : ITraktSyncHistoryRemovePostEpisode
    {
        /// <summary>Gets or sets the required episode ids. See also <seealso cref="ITraktEpisodeIds" />.</summary>
        public ITraktEpisodeIds Ids { get; set; }
    }
}
