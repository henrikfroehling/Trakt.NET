namespace TraktNet.Objects.Post.Builder.Interfaces
{
    using Capabilities;
    using Post.Syncs.Watchlist;

    public interface ITraktSyncWatchlistPostBuilder
        : ITraktPostBuilder<ITraktSyncWatchlistPost>,
          ITraktPostBuilderWithMovie<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost>,
          ITraktPostBuilderWithShow<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost>,
          ITraktPostBuilderWithShows<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost>,
          ITraktPostBuilderWithEpisode<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost>
    {
    }
}
