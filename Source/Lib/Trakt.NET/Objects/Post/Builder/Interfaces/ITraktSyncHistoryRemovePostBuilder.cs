namespace TraktNet.Objects.Post
{
    using Capabilities;
    using Post.Syncs.History;

    public interface ITraktSyncHistoryRemovePostBuilder
        : ITraktPostBuilder<ITraktSyncHistoryRemovePost>,
          ITraktPostBuilderWithMovie<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost>,
          ITraktPostBuilderWithMovies<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost>,
          ITraktPostBuilderMovieWithWatchedAt<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost>,
          ITraktPostBuilderWithShow<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost>,
          ITraktPostBuilderWithShows<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost>,
          ITraktPostBuilderShowWithSeasons<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost>,
          ITraktPostBuilderShowWithSeasonsCollection<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost, PostHistorySeasons>,
          ITraktPostBuilderShowWithWatchedAt<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost>,
          ITraktPostBuilderShowWithWatchedAtWithSeasons<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost>,
          ITraktPostBuilderShowWithWatchedAtWithSeasonsCollection<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost, PostHistorySeasons>,
          ITraktPostBuilderWithEpisode<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost>,
          ITraktPostBuilderWithEpisodes<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost>,
          ITraktPostBuilderEpisodeWithWatchedAt<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost>
    {
        ITraktSyncHistoryRemovePostBuilder WithHistoryIds(ulong[] historyIds);

        ITraktSyncHistoryRemovePostBuilder WithHistoryIds(ulong historyId, params ulong[] historyIds);
    }
}
