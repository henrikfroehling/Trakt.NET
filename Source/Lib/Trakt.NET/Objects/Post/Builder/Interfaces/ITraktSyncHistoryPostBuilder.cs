namespace TraktNet.Objects.Post.Builder.Interfaces
{
    using Capabilities;
    using Post.Syncs.History;

    public interface ITraktSyncHistoryPostBuilder
        : ITraktPostBuilder<ITraktSyncHistoryPost>,
          ITraktPostBuilderAddMovieWithWatchedAt<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost>,
          ITraktPostBuilderWithShows<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost>,
          ITraktPostBuilderAddShowWithSeasonsCollection<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost, PostHistorySeasons>,
          ITraktPostBuilderAddShowWithWatchedAtWithSeasonsCollection<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost, PostHistorySeasons>,
          ITraktPostBuilderAddEpisodeWithWatchedAt<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost>
    {
    }
}
