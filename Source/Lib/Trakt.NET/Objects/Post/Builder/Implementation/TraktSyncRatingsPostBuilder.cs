namespace TraktNet.Objects.Post.Builder.Implementation
{
    using Interfaces;
    using Objects.Get.Episodes;
    using Objects.Get.Movies;
    using Objects.Get.Shows;
    using Objects.Post.Builder.Interfaces.Capabilities;
    using Objects.Post.Syncs.Ratings;
    using System.Collections.Generic;

    public class TraktSyncRatingsPostBuilder : ITraktSyncRatingsPostBuilder
    {
        internal TraktSyncRatingsPostBuilder()
        {
        }

        public ITraktPostBuilderEpisodeAddedRating<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost> AddRatedEpisode(ITraktEpisode episode)
        {
            throw new System.NotImplementedException();
        }

        public ITraktPostBuilderMovieAddedRating<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost> AddRatedMovie(ITraktMovie movie)
        {
            throw new System.NotImplementedException();
        }

        public ITraktPostBuilderShowAddedRating<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost> AddRatedShow(ITraktShow show)
        {
            throw new System.NotImplementedException();
        }

        public ITraktPostBuilderShowAddedRatingWithSeasons<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost> AddRatedShowAndSeasons(ITraktShow show)
        {
            throw new System.NotImplementedException();
        }

        public ITraktPostBuilderShowAddedRatingWithSeasonsCollection<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost, PostRatingsSeasons> AddRatedShowAndSeasonsCollection(ITraktShow show)
        {
            throw new System.NotImplementedException();
        }

        public ITraktPostBuilderShowAddedSeasons<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost> AddShowAndSeasons(ITraktShow show)
        {
            throw new System.NotImplementedException();
        }

        public ITraktPostBuilderShowAddedSeasonsCollection<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost, PostRatingsSeasons> AddShowAndSeasonsCollection(ITraktShow show)
        {
            throw new System.NotImplementedException();
        }

        public ITraktSyncRatingsPost Build()
        {
            throw new System.NotImplementedException();
        }

        public ITraktSyncRatingsPostBuilder WithEpisode(ITraktEpisode episode)
        {
            throw new System.NotImplementedException();
        }

        public ITraktSyncRatingsPostBuilder WithEpisodes(IEnumerable<ITraktEpisode> episodes)
        {
            throw new System.NotImplementedException();
        }

        public ITraktSyncRatingsPostBuilder WithMovie(ITraktMovie movie)
        {
            throw new System.NotImplementedException();
        }

        public ITraktSyncRatingsPostBuilder WithMovies(IEnumerable<ITraktMovie> movies)
        {
            throw new System.NotImplementedException();
        }

        public ITraktSyncRatingsPostBuilder WithShow(ITraktShow show)
        {
            throw new System.NotImplementedException();
        }

        public ITraktSyncRatingsPostBuilder WithShows(IEnumerable<ITraktShow> shows)
        {
            throw new System.NotImplementedException();
        }
    }
}
