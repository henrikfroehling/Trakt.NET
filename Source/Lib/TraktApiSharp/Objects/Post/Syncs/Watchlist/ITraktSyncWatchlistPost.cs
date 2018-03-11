namespace TraktApiSharp.Objects.Post.Syncs.Watchlist
{
    using System.Collections.Generic;

    public interface ITraktSyncWatchlistPost
    {
        IEnumerable<ITraktSyncWatchlistPostMovie> Movies { get; set; }

        IEnumerable<ITraktSyncWatchlistPostShow> Shows { get; set; }

        IEnumerable<ITraktSyncWatchlistPostEpisode> Episodes { get; set; }
    }
}
