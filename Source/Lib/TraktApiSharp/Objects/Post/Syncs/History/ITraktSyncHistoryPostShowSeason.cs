namespace TraktApiSharp.Objects.Post.Syncs.History
{
    using System;
    using System.Collections.Generic;

    public interface ITraktSyncHistoryPostShowSeason
    {
        DateTime? WatchedAt { get; set; }

        int Number { get; set; }

        IEnumerable<ITraktSyncHistoryPostShowEpisode> Episodes { get; set; }
    }
}
