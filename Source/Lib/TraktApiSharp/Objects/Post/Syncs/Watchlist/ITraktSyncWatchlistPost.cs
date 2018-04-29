namespace TraktApiSharp.Objects.Post.Syncs.Watchlist
{
    using Requests.Interfaces;
    using System.Collections.Generic;

    public interface ITraktSyncWatchlistPost : IRequestBody
    {
        IEnumerable<ITraktSyncWatchlistPostMovie> Movies { get; set; }

        IEnumerable<ITraktSyncWatchlistPostShow> Shows { get; set; }

        IEnumerable<ITraktSyncWatchlistPostEpisode> Episodes { get; set; }
    }
}
