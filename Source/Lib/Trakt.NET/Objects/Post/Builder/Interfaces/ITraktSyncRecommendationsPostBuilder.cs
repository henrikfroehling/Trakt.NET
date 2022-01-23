namespace TraktNet.Objects.Post
{
    using Capabilities;
    using Post.Syncs.Recommendations;

    public interface ITraktSyncRecommendationsPostBuilder
        : ITraktPostBuilder<ITraktSyncRecommendationsPost>,
          ITraktPostBuilderWithMovie<ITraktSyncRecommendationsPostBuilder, ITraktSyncRecommendationsPost>,
          ITraktPostBuilderWithMovies<ITraktSyncRecommendationsPostBuilder, ITraktSyncRecommendationsPost>,
          ITraktPostBuilderAddMovieWithNotes<ITraktSyncRecommendationsPostBuilder, ITraktSyncRecommendationsPost>,
          ITraktPostBuilderWithMoviesWithNotes<ITraktSyncRecommendationsPostBuilder, ITraktSyncRecommendationsPost>,
          ITraktPostBuilderWithShow<ITraktSyncRecommendationsPostBuilder, ITraktSyncRecommendationsPost>,
          ITraktPostBuilderWithShows<ITraktSyncRecommendationsPostBuilder, ITraktSyncRecommendationsPost>,
          ITraktPostBuilderAddShowWithNotes<ITraktSyncRecommendationsPostBuilder, ITraktSyncRecommendationsPost>,
          ITraktPostBuilderWithShowsWithNotes<ITraktSyncRecommendationsPostBuilder, ITraktSyncRecommendationsPost>
    {
    }
}
