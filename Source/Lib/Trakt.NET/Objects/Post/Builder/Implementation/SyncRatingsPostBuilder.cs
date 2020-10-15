namespace TraktNet.Objects.Post.Builder.Implementation
{
    using Get.Episodes;
    using Get.Movies;
    using Get.Shows;
    using Helper;
    using Interfaces;
    using Interfaces.Capabilities;
    using Post.Syncs.Ratings;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SyncRatingsPostBuilder : ITraktSyncRatingsPostBuilder
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

        internal SyncRatingsPostBuilder()
        {
            _movies = new List<ITraktMovie>();
            _shows = new List<ITraktShow>();
            _episodes = new List<ITraktEpisode>();
            _ratedMovies = new PostBuilderMovieAddedRating<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>(this);
            _ratedShows = new PostBuilderShowAddedRating<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>(this);
            _ratedShowsWithSeasons = new PostBuilderShowAddedRatingWithSeasons<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>(this);
            _ratedShowsWithSeasonsCollection = new PostBuilderShowAddedRatingWithSeasonsCollection<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost, PostRatingsSeasons>(this);
            _showsWithSeasons = new PostBuilderShowAddedSeasons<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>(this);
            _showsWithSeasonsCollection = new PostBuilderShowAddedSeasonsCollection<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost, PostRatingsSeasons>(this);
            _ratedEpisodes = new PostBuilderEpisodeAddedRating<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost>(this);
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
            _ratedMovies.SetCurrentMovie(movie);
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
            _ratedShows.SetCurrentShow(show);
            return _ratedShows;
        }

        public ITraktPostBuilderShowAddedRatingWithSeasons<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost> AddRatedShowAndSeasons(ITraktShow show)
        {
            _ratedShowsWithSeasons.SetCurrentShow(show);
            return _ratedShowsWithSeasons;
        }

        public ITraktPostBuilderShowAddedRatingWithSeasonsCollection<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost, PostRatingsSeasons> AddRatedShowAndSeasonsCollection(ITraktShow show)
        {
            _ratedShowsWithSeasonsCollection.SetCurrentShow(show);
            return _ratedShowsWithSeasonsCollection;
        }

        public ITraktPostBuilderShowAddedSeasons<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost> AddShowAndSeasons(ITraktShow show)
        {
            _showsWithSeasons.SetCurrentShow(show);
            return _showsWithSeasons;
        }

        public ITraktPostBuilderShowAddedSeasonsCollection<ITraktSyncRatingsPostBuilder, ITraktSyncRatingsPost, PostRatingsSeasons> AddShowAndSeasonsCollection(ITraktShow show)
        {
            _showsWithSeasonsCollection.SetCurrentShow(show);
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
            _ratedEpisodes.SetCurrentEpisode(episode);
            return _ratedEpisodes;
        }

        public ITraktSyncRatingsPost Build()
        {
            ITraktSyncRatingsPost syncRatingsPost = new TraktSyncRatingsPost();
            AddMovies(syncRatingsPost);
            AddShows(syncRatingsPost);
            AddEpisodes(syncRatingsPost);
            return syncRatingsPost;
        }

        private void AddMovies(ITraktSyncRatingsPost syncRatingsPost)
        {
            if (syncRatingsPost.Movies == null)
                syncRatingsPost.Movies = new List<ITraktSyncRatingsPostMovie>();

            foreach (ITraktMovie movie in _movies)
                (syncRatingsPost.Movies as List<ITraktSyncRatingsPostMovie>).Add(CreateSyncRatingsPostMovie(movie));

            foreach (PostBuilderRatedObject<ITraktMovie> movieEntry in _ratedMovies.MoviesAndRating)
                (syncRatingsPost.Movies as List<ITraktSyncRatingsPostMovie>).Add(CreateSyncRatingsPostMovie(movieEntry.Object, movieEntry.Rating, movieEntry.RatedAt));
        }

        private void AddShows(ITraktSyncRatingsPost syncRatingsPost)
        {
            if (syncRatingsPost.Shows == null)
                syncRatingsPost.Shows = new List<ITraktSyncRatingsPostShow>();

            foreach (ITraktShow show in _shows)
                (syncRatingsPost.Shows as List<ITraktSyncRatingsPostShow>).Add(CreateSyncRatingsPostShow(show));

            foreach (PostBuilderRatedObject<ITraktShow> showEntry in _ratedShows.ShowsAndRating)
                (syncRatingsPost.Shows as List<ITraktSyncRatingsPostShow>).Add(CreateSyncRatingsPostShow(showEntry.Object, showEntry.Rating, showEntry.RatedAt));

            foreach (PostBuilderRatedObjectWithSeasons<ITraktShow, IEnumerable<int>> showEntry in _ratedShowsWithSeasons.ShowsAndRatingWithSeasons)
                (syncRatingsPost.Shows as List<ITraktSyncRatingsPostShow>).Add(CreateSyncRatingsPostShowWithSeasons(showEntry.Object, showEntry.Rating, showEntry.RatedAt, showEntry.Seasons));

            foreach (PostBuilderRatedObjectWithSeasons<ITraktShow, PostRatingsSeasons> showEntry in _ratedShowsWithSeasonsCollection.ShowsAndRatingWithSeasonsCollection)
                (syncRatingsPost.Shows as List<ITraktSyncRatingsPostShow>).Add(CreateSyncRatingsPostShowWithSeasonsCollection(showEntry.Object, showEntry.Rating, showEntry.RatedAt, showEntry.Seasons));

            foreach (PostBuilderObjectWithSeasons<ITraktShow, IEnumerable<int>> showEntry in _showsWithSeasons.ShowsWithSeasons)
                (syncRatingsPost.Shows as List<ITraktSyncRatingsPostShow>).Add(CreateSyncRatingsPostShowWithSeasons(showEntry.Object, null, null, showEntry.Seasons));

            foreach (PostBuilderObjectWithSeasons<ITraktShow, PostRatingsSeasons> showEntry in _showsWithSeasonsCollection.ShowsWithSeasonsCollection)
                (syncRatingsPost.Shows as List<ITraktSyncRatingsPostShow>).Add(CreateSyncRatingsPostShowWithSeasonsCollection(showEntry.Object, null, null, showEntry.Seasons));
        }

        private void AddEpisodes(ITraktSyncRatingsPost syncRatingsPost)
        {
            if (syncRatingsPost.Episodes == null)
                syncRatingsPost.Episodes = new List<ITraktSyncRatingsPostEpisode>();

            foreach (ITraktEpisode episode in _episodes)
                (syncRatingsPost.Episodes as List<ITraktSyncRatingsPostEpisode>).Add(CreateSyncRatingsPostEpisode(episode));

            foreach (PostBuilderRatedObject<ITraktEpisode> episodeEntry in _ratedEpisodes.EpisodesAndRating)
                (syncRatingsPost.Episodes as List<ITraktSyncRatingsPostEpisode>).Add(CreateSyncRatingsPostEpisode(episodeEntry.Object, episodeEntry.Rating, episodeEntry.RatedAt));
        }

        private ITraktSyncRatingsPostMovie CreateSyncRatingsPostMovie(ITraktMovie movie, int? rating = null, DateTime? ratedAt = null)
        {
            var syncRatingsPostMovie = new TraktSyncRatingsPostMovie
            {
                Ids = movie.Ids,
                Title = movie.Title,
                Year = movie.Year
            };

            if (rating.HasValue)
                syncRatingsPostMovie.Rating = rating.Value;

            if (ratedAt.HasValue)
                syncRatingsPostMovie.RatedAt = ratedAt.Value.ToUniversalTime();

            return syncRatingsPostMovie;
        }

        private ITraktSyncRatingsPostShow CreateSyncRatingsPostShow(ITraktShow show, int? rating = null, DateTime? ratedAt = null)
        {
            var syncRatingsPostShow = new TraktSyncRatingsPostShow
            {
                Ids = show.Ids,
                Title = show.Title,
                Year = show.Year
            };

            if (rating.HasValue)
                syncRatingsPostShow.Rating = rating.Value;

            if (ratedAt.HasValue)
                syncRatingsPostShow.RatedAt = ratedAt.Value.ToUniversalTime();

            return syncRatingsPostShow;
        }

        private ITraktSyncRatingsPostShow CreateSyncRatingsPostShowWithSeasons(ITraktShow show, int? rating = null, DateTime? ratedAt = null, IEnumerable<int> seasons = null)
        {
            var syncRatingsPostShow = CreateSyncRatingsPostShow(show, rating, ratedAt);

            if (seasons != null)
                syncRatingsPostShow.Seasons = CreateSyncRatingsPostShowSeasons(seasons);

            return syncRatingsPostShow;
        }

        private ITraktSyncRatingsPostShow CreateSyncRatingsPostShowWithSeasonsCollection(ITraktShow show, int? rating = null, DateTime? ratedAt = null, PostRatingsSeasons seasons = null)
        {
            var syncRatingsPostShow = CreateSyncRatingsPostShow(show, rating, ratedAt);

            if (seasons != null)
                syncRatingsPostShow.Seasons = CreateSyncRatingsPostShowSeasons(seasons);

            return syncRatingsPostShow;
        }

        private IEnumerable<ITraktSyncRatingsPostShowSeason> CreateSyncRatingsPostShowSeasons(IEnumerable<int> seasons)
        {
            var syncRatingsPostShowSeasons = new List<ITraktSyncRatingsPostShowSeason>();

            foreach (int season in seasons)
            {
                syncRatingsPostShowSeasons.Add(new TraktSyncRatingsPostShowSeason
                {
                    Number = season
                });
            }

            return syncRatingsPostShowSeasons;
        }

        private IEnumerable<ITraktSyncRatingsPostShowSeason> CreateSyncRatingsPostShowSeasons(PostRatingsSeasons seasons)
        {
            var syncRatingsPostShowSeasons = new List<ITraktSyncRatingsPostShowSeason>();

            foreach (PostRatingsSeason season in seasons)
            {
                var syncRatingsPostShowSeason = new TraktSyncRatingsPostShowSeason
                {
                    Number = season.Number
                };

                if (season.Rating.HasValue)
                    syncRatingsPostShowSeason.Rating = season.Rating.Value;

                if (season.RatedAt.HasValue)
                    syncRatingsPostShowSeason.RatedAt = season.RatedAt.Value.ToUniversalTime();

                if (season.Episodes?.Count() > 0)
                {
                    var syncRatingsPostShowEpisodes = new List<ITraktSyncRatingsPostShowEpisode>();

                    foreach (PostRatingsEpisode episode in season.Episodes)
                    {
                        var syncRatingsPostShowEpisode = new TraktSyncRatingsPostShowEpisode
                        {
                            Number = episode.Number
                        };

                        if (episode.Rating.HasValue)
                            syncRatingsPostShowEpisode.Rating = episode.Rating.Value;

                        if (episode.RatedAt.HasValue)
                            syncRatingsPostShowEpisode.RatedAt = episode.RatedAt.Value.ToUniversalTime();

                        syncRatingsPostShowEpisodes.Add(syncRatingsPostShowEpisode);
                    }

                    syncRatingsPostShowSeason.Episodes = syncRatingsPostShowEpisodes;
                }

                syncRatingsPostShowSeasons.Add(syncRatingsPostShowSeason);
            }

            return syncRatingsPostShowSeasons;
        }

        private ITraktSyncRatingsPostEpisode CreateSyncRatingsPostEpisode(ITraktEpisode episode, int? rating = null, DateTime? ratedAt = null)
        {
            var syncRatingsPostEpisode = new TraktSyncRatingsPostEpisode
            {
                Ids = episode.Ids
            };

            if (rating.HasValue)
                syncRatingsPostEpisode.Rating = rating.Value;

            if (ratedAt.HasValue)
                syncRatingsPostEpisode.RatedAt = ratedAt.Value.ToUniversalTime();

            return syncRatingsPostEpisode;
        }
    }
}
