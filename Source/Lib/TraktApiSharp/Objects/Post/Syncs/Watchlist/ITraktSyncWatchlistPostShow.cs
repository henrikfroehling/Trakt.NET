namespace TraktApiSharp.Objects.Post.Syncs.Watchlist
{
    using Get.Shows;
    using System.Collections.Generic;

    public interface ITraktSyncWatchlistPostShow
    {
        string Title { get; set; }

        int? Year { get; set; }

        ITraktShowIds Ids { get; set; }

        IEnumerable<ITraktSyncWatchlistPostShowSeason> Seasons { get; set; }
    }
}
