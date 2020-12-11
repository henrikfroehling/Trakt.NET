namespace TraktNet.Objects.Post
{
    using Capabilities;
    using Post.Syncs.History;

    public interface ITraktSyncHistoryRemovePostBuilder
        : ITraktPostBuilder<ITraktSyncHistoryRemovePost>,
          ITraktPostBuilderWithMovie<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost>,
          ITraktPostBuilderWithMovies<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost>,
          ITraktPostBuilderAddMovieWithWatchedAt<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost>,
          ITraktPostBuilderWithShow<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost>,
          ITraktPostBuilderWithShows<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost>,
          ITraktPostBuilderAddShowWithSeasons<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost>,
          ITraktPostBuilderAddShowWithSeasonsCollection<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost, PostHistorySeasons>,
          ITraktPostBuilderAddShowWithWatchedAt<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost>,
          ITraktPostBuilderAddShowWithWatchedAtWithSeasons<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost>,
          ITraktPostBuilderAddShowWithWatchedAtWithSeasonsCollection<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost, PostHistorySeasons>,
          ITraktPostBuilderWithEpisode<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost>,
          ITraktPostBuilderWithEpisodes<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost>,
          ITraktPostBuilderAddEpisodeWithWatchedAt<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost>
    {
        ITraktSyncHistoryRemovePostBuilder AddHistoryIds(ulong[] historyIds);

        ITraktSyncHistoryRemovePostBuilder AddHistoryIds(ulong historyId, params ulong[] historyIds);
    }
}
