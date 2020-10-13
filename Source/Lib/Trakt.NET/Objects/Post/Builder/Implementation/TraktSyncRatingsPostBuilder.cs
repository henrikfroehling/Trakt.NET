namespace TraktNet.Objects.Post.Builder.Implementation
{
    using Helper;
    using Interfaces;
    using Interfaces.Capabilities;
    using Objects.Get.Episodes;
    using Objects.Get.Movies;
    using Objects.Get.Shows;
    using Objects.Post.Syncs.Ratings;
    using System.Collections.Generic;

    public class TraktSyncRatingsPostBuilder : ITraktSyncRatingsPostBuilder
    {
        private readonly List<ITraktMovie> _movies;
        private readonly List<ITraktShow> _shows;
        private readonly List<ITraktEpisode> _episodes;
        private readonly ITraktPostBuilderMovieAddedRating<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost> _ratedMovies;
        private readonly ITraktPostBuilderShowAddedRating<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost> _ratedShows;
        private readonly ITraktPostBuilderShowAddedRatingWithSeasons<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost> _ratedShowsWithSeasons;
        private readonly ITraktPostBuilderShowAddedRatingWithSeasonsCollection<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost, PostRatingsSeasons> _ratedShowsWithSeasonsCollection;
        private readonly ITraktPostBuilderShowAddedSeasons<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost> _showsWithSeasons;
        private readonly ITraktPostBuilderShowAddedSeasonsCollection<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost, PostRatingsSeasons> _showsWithSeasonsCollection;
        private readonly ITraktPostBuilderEpisodeAddedRating<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost> _ratedEpisodes;

        internal TraktSyncRatingsPostBuilder()
        {
            _movies = new List<ITraktMovie>();
            _shows = new List<ITraktShow>();
            _episodes = new List<ITraktEpisode>();
            _ratedMovies = new TraktPostBuilderMovieAddedRating<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>(this);
            _ratedShows = new TraktPostBuilderShowAddedRating<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>(this);
            _ratedShowsWithSeasons = new TraktPostBuilderShowAddedRatingWithSeasons<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>(this);
            _ratedShowsWithSeasonsCollection = new TraktPostBuilderShowAddedRatingWithSeasonsCollection<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost, PostRatingsSeasons>(this);
            _showsWithSeasons = new TraktPostBuilderShowAddedSeasons<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>(this);
            _showsWithSeasonsCollection = new TraktPostBuilderShowAddedSeasonsCollection<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost, PostRatingsSeasons>(this);
            _ratedEpisodes = new TraktPostBuilderEpisodeAddedRating<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>(this);
        }

        public ITraktSyncRatingsPostBuilder WithMovie(ITraktMovie movie)
        {
            _movies.Add(movie);
            return this;
        }

        public ITraktSyncRatingsPostBuilder WithMovies(IEnumerable<ITraktMovie> movies)
        {
            _movies.AddRange(movies);
            return this;
        }

        public ITraktPostBuilderMovieAddedRating<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost> AddRatedMovie(ITraktMovie movie)
        {
            return _ratedMovies;
        }

        public ITraktSyncRatingsPostBuilder WithShow(ITraktShow show)
        {
            _shows.Add(show);
            return this;
        }

        public ITraktSyncRatingsPostBuilder WithShows(IEnumerable<ITraktShow> shows)
        {
            _shows.AddRange(shows);
            return this;
        }

        public ITraktPostBuilderShowAddedRating<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost> AddRatedShow(ITraktShow show)
        {
            return _ratedShows;
        }

        public ITraktPostBuilderShowAddedRatingWithSeasons<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost> AddRatedShowAndSeasons(ITraktShow show)
        {
            return _ratedShowsWithSeasons;
        }

        public ITraktPostBuilderShowAddedRatingWithSeasonsCollection<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost, PostRatingsSeasons> AddRatedShowAndSeasonsCollection(ITraktShow show)
        {
            return _ratedShowsWithSeasonsCollection;
        }

        public ITraktPostBuilderShowAddedSeasons<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost> AddShowAndSeasons(ITraktShow show)
        {
            return _showsWithSeasons;
        }

        public ITraktPostBuilderShowAddedSeasonsCollection<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost, PostRatingsSeasons> AddShowAndSeasonsCollection(ITraktShow show)
        {
            return _showsWithSeasonsCollection;
        }

        public ITraktSyncRatingsPostBuilder WithEpisode(ITraktEpisode episode)
        {
            _episodes.Add(episode);
            return this;
        }

        public ITraktSyncRatingsPostBuilder WithEpisodes(IEnumerable<ITraktEpisode> episodes)
        {
            _episodes.AddRange(episodes);
            return this;
        }

        public ITraktPostBuilderEpisodeAddedRating<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost> AddRatedEpisode(ITraktEpisode episode)
        {
            return _ratedEpisodes;
        }

        public ITraktSyncRatingsPost Build()
        {
            return new TraktSyncRatingsPost();
        }
    }
}
