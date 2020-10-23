namespace TraktNet.Objects.Post.Builder
{
    using Capabilities;
    using Post.Syncs.Ratings;

    public interface ITraktSyncRatingsPostBuilder
        : ITraktPostBuilder<ITraktSyncRatingsPost>,
          ITraktPostBuilderWithMovie<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>,
          ITraktPostBuilderWithMovies<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>,
          ITraktPostBuilderAddMovieWithRating<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>,
          ITraktPostBuilderWithShow<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>,
          ITraktPostBuilderWithShows<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>,
          ITraktPostBuilderAddShowWithSeasons<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>,
          ITraktPostBuilderAddShowWithSeasonsCollection<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost, PostRatingsSeasons>,
          ITraktPostBuilderAddShowWithRating<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>,
          ITraktPostBuilderAddShowWithRatingWithSeasons<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>,
          ITraktPostBuilderAddShowWithRatingWithSeasonsCollection<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost, PostRatingsSeasons>,
          ITraktPostBuilderWithEpisode<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>,
          ITraktPostBuilderWithEpisodes<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>,
          ITraktPostBuilderAddEpisodeWithRating<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>
    {
    }
}
