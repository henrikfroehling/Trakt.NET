namespace TraktNet.PostBuilder
{
    using TraktNet.Objects.Post.Syncs.Recommendations;

    public interface ITraktSyncRecommendationsPostBuilder
        : ITraktPostBuilder<ITraktSyncRecommendationsPost>,
          ITraktPostBuilderWithMovie<ITraktSyncRecommendationsPostBuilder, ITraktSyncRecommendationsPost>,
          ITraktPostBuilderWithMovies<ITraktSyncRecommendationsPostBuilder, ITraktSyncRecommendationsPost>,
          ITraktPostBuilderMovieWithNotes<ITraktSyncRecommendationsPostBuilder, ITraktSyncRecommendationsPost>,
          ITraktPostBuilderWithMoviesWithNotes<ITraktSyncRecommendationsPostBuilder, ITraktSyncRecommendationsPost>,
          ITraktPostBuilderWithShow<ITraktSyncRecommendationsPostBuilder, ITraktSyncRecommendationsPost>,
          ITraktPostBuilderWithShows<ITraktSyncRecommendationsPostBuilder, ITraktSyncRecommendationsPost>,
          ITraktPostBuilderShowWithNotes<ITraktSyncRecommendationsPostBuilder, ITraktSyncRecommendationsPost>,
          ITraktPostBuilderWithShowsWithNotes<ITraktSyncRecommendationsPostBuilder, ITraktSyncRecommendationsPost>
    {
    }
}
