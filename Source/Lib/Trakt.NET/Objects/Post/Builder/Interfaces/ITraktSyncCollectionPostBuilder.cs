namespace TraktNet.Objects.Post
{
    using Capabilities;
    using Post.Syncs.Collection;

    public interface ITraktSyncCollectionPostBuilder
        : ITraktPostBuilder<ITraktSyncCollectionPost>,
          ITraktPostBuilderWithMovie<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderWithMovies<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderWithMoviesWithMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderAddMovieWithCollectedAt<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderAddMovieWithMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderWithShow<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderWithShows<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderWithShowsWithMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderAddShowWithSeasons<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderAddShowWithSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons>,
          ITraktPostBuilderAddShowWithCollectedAt<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderAddShowWithCollectedAtWithSeasons<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderAddShowWithCollectedAtWithSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons>,
          ITraktPostBuilderAddShowWithMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderAddShowWithMetadataWithSeasons<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderAddShowWithMetadataWithSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons>,
          ITraktPostBuilderWithEpisode<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderWithEpisodes<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderWithEpisodesWithMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderAddEpisodeWithCollectedAt<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderAddEpisodeWithMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>
    {
    }
}
