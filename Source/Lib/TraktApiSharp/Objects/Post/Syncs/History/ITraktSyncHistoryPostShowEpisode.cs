namespace TraktApiSharp.Objects.Post.Syncs.History
{
    using System;

    public interface ITraktSyncHistoryPostShowEpisode
    {
        DateTime? WatchedAt { get; set; }

        int Number { get; set; }
    }
}
