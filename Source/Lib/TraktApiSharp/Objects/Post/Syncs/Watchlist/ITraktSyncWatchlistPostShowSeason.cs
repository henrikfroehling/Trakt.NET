namespace TraktApiSharp.Objects.Post.Syncs.Watchlist
{
    using System.Collections.Generic;

    public interface ITraktSyncWatchlistPostShowSeason
    {
        int Number { get; set; }

        IEnumerable<ITraktSyncWatchlistPostShowEpisode> Episodes { get; set; }
    }
}
