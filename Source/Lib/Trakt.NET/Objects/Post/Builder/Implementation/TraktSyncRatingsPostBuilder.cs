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

        public ITraktPostBuilderEpisodeAddedRating<ITraktPostBuilderAddEpisodeWithRating<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>, ITraktSyncRatingsPost> AddEpisode(ITraktEpisode episode)
        {
            throw new System.NotImplementedException();
        }

        public ITraktPostBuilderMovieAddedRating<ITraktPostBuilderAddMovieWithRating<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>, ITraktSyncRatingsPost> AddMovie(ITraktMovie movie)
        {
            throw new System.NotImplementedException();
        }

        public ITraktPostBuilderShowAddedSeasonsCollection<ITraktPostBuilderAddShowWithSeasonsCollection<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost, PostRatingsSeasons>, ITraktSyncRatingsPost, PostRatingsSeasons> AddShow(ITraktShow show)
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

        public ITraktPostBuilderAddShowWithSeasonsCollection<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost, PostRatingsSeasons> WithShow(ITraktShow show)
        {
            throw new System.NotImplementedException();
        }

        public ITraktSyncRatingsPostBuilder WithShows(IEnumerable<ITraktShow> shows)
        {
            throw new System.NotImplementedException();
        }

        ITraktPostBuilderShowAddedRatingWithSeasonsCollection<ITraktPostBuilderAddShowWithRatingWithSeasonsCollection<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost, PostRatingsSeasons>, ITraktSyncRatingsPost, PostRatingsSeasons> ITraktPostBuilderAddShowWithRatingWithSeasonsCollection<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost, PostRatingsSeasons>.AddShow(ITraktShow show)
        {
            throw new System.NotImplementedException();
        }

        ITraktPostBuilderAddEpisodeWithRating<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost> ITraktPostBuilderWithEpisode<ITraktPostBuilderAddEpisodeWithRating<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>, ITraktSyncRatingsPost>.WithEpisode(ITraktEpisode episode)
        {
            throw new System.NotImplementedException();
        }

        ITraktPostBuilderAddEpisodeWithRating<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost> ITraktPostBuilderWithEpisode<ITraktPostBuilderAddEpisodeWithRating<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>, ITraktSyncRatingsPost>.WithEpisodes(IEnumerable<ITraktEpisode> episodes)
        {
            throw new System.NotImplementedException();
        }

        ITraktPostBuilderAddMovieWithRating<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost> ITraktPostBuilderWithMovie<ITraktPostBuilderAddMovieWithRating<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>, ITraktSyncRatingsPost>.WithMovie(ITraktMovie movie)
        {
            throw new System.NotImplementedException();
        }

        ITraktPostBuilderAddMovieWithRating<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost> ITraktPostBuilderWithMovie<ITraktPostBuilderAddMovieWithRating<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>, ITraktSyncRatingsPost>.WithMovies(IEnumerable<ITraktMovie> movies)
        {
            throw new System.NotImplementedException();
        }

        ITraktPostBuilderAddShowWithRatingWithSeasonsCollection<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost, PostRatingsSeasons> ITraktPostBuilderWithShow<ITraktPostBuilderAddShowWithRatingWithSeasonsCollection<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost, PostRatingsSeasons>, ITraktSyncRatingsPost>.WithShow(ITraktShow show)
        {
            throw new System.NotImplementedException();
        }

        ITraktSyncRatingsPostBuilder ITraktPostBuilderWithShow<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>.WithShow(ITraktShow show)
        {
            throw new System.NotImplementedException();
        }
    }
}
