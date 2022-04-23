namespace TraktNet.Objects.Post
{
    using Capabilities;
    using Post.Syncs.Watchlist;

    public interface ITraktSyncWatchlistPostBuilder
        : ITraktPostBuilder<ITraktSyncWatchlistPost>,
          ITraktPostBuilderWithMovie<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost>,
          ITraktPostBuilderWithMovies<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost>,
          ITraktPostBuilderWithShow<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost>,
          ITraktPostBuilderWithShows<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost>,
          ITraktPostBuilderShowWithSeasons<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost>,
          ITraktPostBuilderShowWithSeasonsCollection<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost, PostSeasons>,
          ITraktPostBuilderWithEpisode<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost>,
          ITraktPostBuilderWithEpisodes<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost>
    {
    }
}
