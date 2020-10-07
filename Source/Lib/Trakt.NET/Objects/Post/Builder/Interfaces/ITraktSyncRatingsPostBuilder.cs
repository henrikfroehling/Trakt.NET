namespace TraktNet.Objects.Post.Builder.Interfaces
{
    using Capabilities;
    using Post.Syncs.Ratings;

    public interface ITraktSyncRatingsPostBuilder
        : ITraktPostBuilder<ITraktSyncRatingsPost>,
          ITraktPostBuilderWithMovie<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>,
          ITraktPostBuilderAddMovieWithRating<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>,
          ITraktPostBuilderAddShowWithSeasonsCollection<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost, PostRatingsSeasons>,
          ITraktPostBuilderAddShowWithRatingWithSeasonsCollection<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost, PostRatingsSeasons>,
          ITraktPostBuilderWithShows<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>,
          ITraktPostBuilderWithEpisode<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>,
          ITraktPostBuilderAddEpisodeWithRating<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>
    {
    }
}
