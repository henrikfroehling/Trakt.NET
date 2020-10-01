namespace TraktNet.Objects.Post.Builder.Interfaces
{
    using Capabilities;
    using Post.Syncs.Collection;

    public interface ITraktSyncCollectionPostBuilder
        : ITraktPostBuilder<ITraktSyncCollectionPost>,
          ITraktPostBuilderWithMovie<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderWithShow<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderWithShows<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderWithEpisode<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>
    {
    }
}
