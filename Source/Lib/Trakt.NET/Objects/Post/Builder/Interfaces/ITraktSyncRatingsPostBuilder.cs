namespace TraktNet.Objects.Post
{
    using Capabilities;
    using Post.Syncs.Ratings;

    public interface ITraktSyncRatingsPostBuilder
        : ITraktPostBuilder<ITraktSyncRatingsPost>,
          ITraktPostBuilderWithMovie<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>,
          ITraktPostBuilderWithMovies<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>,
          ITraktPostBuilderMovieWithRating<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>,
          ITraktPostBuilderWithShow<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>,
          ITraktPostBuilderWithShows<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>,
          ITraktPostBuilderShowWithSeasons<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>,
          ITraktPostBuilderShowWithSeasonsCollection<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost, PostRatingsSeasons>,
          ITraktPostBuilderShowWithRating<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>,
          ITraktPostBuilderShowWithRatingWithSeasons<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>,
          ITraktPostBuilderShowWithRatingWithSeasonsCollection<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost, PostRatingsSeasons>,
          ITraktPostBuilderWithEpisode<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>,
          ITraktPostBuilderWithEpisodes<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>,
          ITraktPostBuilderEpisodeWithRating<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>
    {
    }
}
