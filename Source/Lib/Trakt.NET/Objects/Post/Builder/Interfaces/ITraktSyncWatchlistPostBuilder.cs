namespace TraktNet.Objects.Post.Builder.Interfaces
{
    using Capabilities;
    using Post.Syncs.Watchlist;

    public interface ITraktSyncWatchlistPostBuilder
        : ITraktPostBuilder<ITraktSyncWatchlistPost>,
          ITraktPostBuilderWithMovie<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost>,
          ITraktPostBuilderAddShowWithSeasonsCollection<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost, PostSeasons>,
          ITraktPostBuilderWithShows<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost>,
          ITraktPostBuilderWithEpisode<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost>
    {
    }
}
