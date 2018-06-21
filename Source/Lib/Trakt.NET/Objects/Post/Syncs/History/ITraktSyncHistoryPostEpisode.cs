namespace TraktNet.Objects.Post.Syncs.History
{
    using Get.Episodes;
    using System;

    public interface ITraktSyncHistoryPostEpisode
    {
        DateTime? WatchedAt { get; set; }

        ITraktEpisodeIds Ids { get; set; }
    }
}
