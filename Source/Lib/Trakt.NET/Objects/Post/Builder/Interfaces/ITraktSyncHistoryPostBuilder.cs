namespace TraktNet.Objects.Post.Builder.Interfaces
{
    using Capabilities;
    using Post.Syncs.History;

    public interface ITraktSyncHistoryPostBuilder
        : ITraktPostBuilder<ITraktSyncHistoryPost>,
          ITraktPostBuilderWithMovie<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost>,
          ITraktPostBuilderWithShows<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost>,
          ITraktPostBuilderWithEpisode<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost>
    {
    }
}
