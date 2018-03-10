namespace TraktApiSharp.Objects.Post.Syncs.History
{
    using Get.Shows;
    using System;
    using System.Collections.Generic;

    public interface ITraktSyncHistoryPostShow
    {
        DateTime? WatchedAt { get; set; }

        string Title { get; set; }

        int? Year { get; set; }

        ITraktShowIds Ids { get; set; }

        IEnumerable<ITraktSyncHistoryPostShowSeason> Seasons { get; set; }
    }
}
