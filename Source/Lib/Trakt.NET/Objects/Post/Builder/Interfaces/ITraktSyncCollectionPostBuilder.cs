namespace TraktNet.Objects.Post.Builder.Interfaces
{
    using Capabilities;
    using Post.Syncs.Collection;

    public interface ITraktSyncCollectionPostBuilder
        : ITraktPostBuilder<ITraktSyncCollectionPost>,
          ITraktPostBuilderWithMoviesWithMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderAddMovieWithCollectedAt<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderAddMovieWithMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderWithShowsWithMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderAddShowWithSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons>,
          ITraktPostBuilderAddShowWithCollectedAtWithSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons>,
          ITraktPostBuilderAddShowWithMetadataWithSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons>,
          ITraktPostBuilderWithEpisodesWithMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderAddEpisodeWithCollectedAt<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderAddEpisodeWithMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>
    {
    }
}
