namespace TraktNet.Objects.Post.Builder.Interfaces
{
    using Capabilities;
    using Post.Syncs.History;

    public interface ITraktSyncHistoryPostBuilder
        : ITraktPostBuilder<ITraktSyncHistoryPost>,
          ITraktPostBuilderWithMovie<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost>,
          ITraktPostBuilderWithMovies<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost>,
          ITraktPostBuilderAddMovieWithWatchedAt<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost>,
          ITraktPostBuilderWithShow<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost>,
          ITraktPostBuilderWithShows<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost>,
          ITraktPostBuilderAddShowWithSeasons<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost>,
          ITraktPostBuilderAddShowWithSeasonsCollection<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost, PostHistorySeasons>,
          ITraktPostBuilderAddShowWithWatchedAt<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost>,
          ITraktPostBuilderAddShowWithWatchedAtWithSeasons<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost>,
          ITraktPostBuilderAddShowWithWatchedAtWithSeasonsCollection<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost, PostHistorySeasons>,
          ITraktPostBuilderWithEpisode<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost>,
          ITraktPostBuilderWithEpisodes<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost>,
          ITraktPostBuilderAddEpisodeWithWatchedAt<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost>
    {
    }
}
