namespace TraktNet.Objects.Post.Builder.Interfaces
{
    using Capabilities;
    using Post.Syncs.Ratings;

    public interface ITraktSyncRatingsPostBuilder
        : ITraktPostBuilder<ITraktSyncRatingsPost>,
          ITraktPostBuilderWithMovie<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>,
          ITraktPostBuilderWithShow<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>,
          ITraktPostBuilderWithShows<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>,
          ITraktPostBuilderWithEpisode<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>
    {
    }
}
