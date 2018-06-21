namespace TraktNet.Objects.Post.Syncs.History
{
    using Get.Episodes;
    using System;

    /// <summary>
    /// A Trakt history post episode, containing the required episode ids
    /// and an optional datetime, when the episode was watched.
    /// </summary>
    public class TraktSyncHistoryPostEpisode : ITraktSyncHistoryPostEpisode
    {
        /// <summary>Gets or sets the optional UTC datetime, when the Trakt episode was watched.</summary>
        public DateTime? WatchedAt { get; set; }

        /// <summary>Gets or sets the required episode ids. See also <seealso cref="ITraktEpisodeIds" />.</summary>
        public ITraktEpisodeIds Ids { get; set; }
    }
}
