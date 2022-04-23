namespace TraktNet.Objects.Post
{
    using Capabilities;
    using Post.Syncs.Collection;

    public interface ITraktSyncCollectionPostBuilder
        : ITraktPostBuilder<ITraktSyncCollectionPost>,
          ITraktPostBuilderWithMovie<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderWithMovies<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderWithMoviesWithMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderMovieWithCollectedAt<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderMovieWithMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderWithShow<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderWithShows<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderWithShowsWithMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderShowWithSeasons<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderShowWithSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons>,
          ITraktPostBuilderShowWithCollectedAt<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderShowWithCollectedAtWithSeasons<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderShowWithCollectedAtWithSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons>,
          ITraktPostBuilderShowWithMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderShowWithMetadataWithSeasons<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderShowWithMetadataWithSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons>,
          ITraktPostBuilderWithEpisode<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderWithEpisodes<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderWithEpisodesWithMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderEpisodeWithCollectedAt<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>,
          ITraktPostBuilderEpisodeWithMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>
    {
    }
}
