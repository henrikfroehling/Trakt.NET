namespace TraktNet.Objects.Post
{
    using Capabilities;
    using Post.Syncs.History;

    public interface ITraktSyncHistoryPostBuilder
        : ITraktPostBuilder<ITraktSyncHistoryPost>,
          ITraktPostBuilderWithMovie<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost>,
          ITraktPostBuilderWithMovies<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost>,
          ITraktPostBuilderMovieWithWatchedAt<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost>,
          ITraktPostBuilderWithShow<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost>,
          ITraktPostBuilderWithShows<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost>,
          ITraktPostBuilderShowWithSeasons<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost>,
          ITraktPostBuilderShowWithSeasonsCollection<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost, PostHistorySeasons>,
          ITraktPostBuilderShowWithWatchedAt<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost>,
          ITraktPostBuilderShowWithWatchedAtWithSeasons<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost>,
          ITraktPostBuilderShowWithWatchedAtWithSeasonsCollection<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost, PostHistorySeasons>,
          ITraktPostBuilderWithEpisode<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost>,
          ITraktPostBuilderWithEpisodes<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost>,
          ITraktPostBuilderEpisodeWithWatchedAt<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost>
    {
    }
}
