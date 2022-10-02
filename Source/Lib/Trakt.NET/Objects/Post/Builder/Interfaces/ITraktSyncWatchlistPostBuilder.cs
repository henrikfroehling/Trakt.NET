namespace TraktNet.Objects.Post
{
    using Capabilities;
    using Post.Syncs.Watchlist;

    public interface ITraktSyncWatchlistPostBuilder
        : ITraktPostBuilder<ITraktSyncWatchlistPost>,
          ITraktPostBuilderWithMovie<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost>,
          ITraktPostBuilderWithMovies<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost>,
          ITraktPostBuilderMovieWithNotes<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost>,
          ITraktPostBuilderWithMoviesWithNotes<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost>,
          ITraktPostBuilderWithShow<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost>,
          ITraktPostBuilderWithShows<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost>,
          ITraktPostBuilderShowWithSeasons<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost>,
          ITraktPostBuilderShowWithSeasonsCollection<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost, PostSeasonsOld>,
          ITraktPostBuilderShowWithNotes<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost>,
          ITraktPostBuilderWithShowsWithNotes<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost>,
          ITraktPostBuilderWithEpisode<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost>,
          ITraktPostBuilderWithEpisodes<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost>,
          ITraktPostBuilderEpisodeWithNotes<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost>,
          ITraktPostBuilderWithEpisodesWithNotes<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost>
    {
    }
}
