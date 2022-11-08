namespace TraktNet.PostBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.Recommendations;

    internal sealed class SyncRecommendationsRemovePostBuilder : ITraktSyncRecommendationsRemovePostBuilder
    {
        private readonly Lazy<List<ITraktMovie>> _movies;
        private readonly Lazy<List<ITraktMovieIds>> _movieIds;
        private readonly Lazy<List<ITraktShow>> _shows;
        private readonly Lazy<List<ITraktShowIds>> _showIds;

        internal SyncRecommendationsRemovePostBuilder()
        {
            _movies = new Lazy<List<ITraktMovie>>();
            _movieIds = new Lazy<List<ITraktMovieIds>>();
            _shows = new Lazy<List<ITraktShow>>();
            _showIds = new Lazy<List<ITraktShowIds>>();
        }

        public ITraktSyncRecommendationsRemovePostBuilder WithMovie(ITraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            _movies.Value.Add(movie);
            return this;
        }

        public ITraktSyncRecommendationsRemovePostBuilder WithMovie(ITraktMovieIds movieIds)
        {
            if (movieIds == null)
                throw new ArgumentNullException(nameof(movieIds));

            _movieIds.Value.Add(movieIds);
            return this;
        }

        public ITraktSyncRecommendationsRemovePostBuilder WithMovies(IEnumerable<ITraktMovie> movies)
        {
            if (movies == null)
                throw new ArgumentNullException(nameof(movies));

            foreach (ITraktMovie movie in movies)
            {
                if (movie != null)
                    _movies.Value.Add(movie);
            }

            return this;
        }

        public ITraktSyncRecommendationsRemovePostBuilder WithMovies(IEnumerable<ITraktMovieIds> movieIds)
        {
            if (movieIds == null)
                throw new ArgumentNullException(nameof(movieIds));

            foreach (ITraktMovieIds movieId in movieIds)
            {
                if (movieId != null)
                    _movieIds.Value.Add(movieId);
            }

            return this;
        }

        public ITraktSyncRecommendationsRemovePostBuilder WithShow(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _shows.Value.Add(show);
            return this;
        }

        public ITraktSyncRecommendationsRemovePostBuilder WithShow(ITraktShowIds showIds)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            _showIds.Value.Add(showIds);
            return this;
        }

        public ITraktSyncRecommendationsRemovePostBuilder WithShows(IEnumerable<ITraktShow> shows)
        {
            if (shows == null)
                throw new ArgumentNullException(nameof(shows));

            foreach (ITraktShow show in shows)
            {
                if (show != null)
                    _shows.Value.Add(show);
            }

            return this;
        }

        public ITraktSyncRecommendationsRemovePostBuilder WithShows(IEnumerable<ITraktShowIds> showIds)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            foreach (ITraktShowIds showId in showIds)
            {
                if (showId != null)
                    _showIds.Value.Add(showId);
            }

            return this;
        }

        public ITraktSyncRecommendationsRemovePost Build()
        {
            ITraktSyncRecommendationsRemovePost syncRecommendationsRemovePost = new TraktSyncRecommendationsRemovePost();
            AddMovies(syncRecommendationsRemovePost);
            AddShows(syncRecommendationsRemovePost);
            syncRecommendationsRemovePost.Validate();
            return syncRecommendationsRemovePost;
        }

        private void AddMovies(ITraktSyncRecommendationsRemovePost syncRecommendationsRemovePost)
        {
            if (!_movies.IsValueCreated && !_movieIds.IsValueCreated)
                return;

            syncRecommendationsRemovePost.Movies ??= new List<ITraktSyncRecommendationsPostMovie>();

            if (_movies.IsValueCreated && _movies.Value.Any())
            {
                foreach (ITraktMovie movie in _movies.Value)
                {
                    (syncRecommendationsRemovePost.Movies as List<ITraktSyncRecommendationsPostMovie>)
                        .Add(CreateRecommendationsPostMovie(movie));
                }
            }

            if (_movieIds.IsValueCreated && _movieIds.Value.Any())
            {
                foreach (ITraktMovieIds movieIds in _movieIds.Value)
                {
                    (syncRecommendationsRemovePost.Movies as List<ITraktSyncRecommendationsPostMovie>)
                        .Add(CreateRecommendationsPostMovie(movieIds));
                }
            }
        }

        private void AddShows(ITraktSyncRecommendationsRemovePost syncRecommendationsRemovePost)
        {
            if (!_shows.IsValueCreated && !_showIds.IsValueCreated)
                return;

            syncRecommendationsRemovePost.Shows ??= new List<ITraktSyncRecommendationsPostShow>();

            if (_shows.IsValueCreated && _shows.Value.Any())
            {
                foreach (ITraktShow show in _shows.Value)
                {
                    (syncRecommendationsRemovePost.Shows as List<ITraktSyncRecommendationsPostShow>)
                        .Add(CreateRecommendationsPostShow(show));
                }
            }

            if (_showIds.IsValueCreated && _showIds.Value.Any())
            {
                foreach (ITraktShowIds showIds in _showIds.Value)
                {
                    (syncRecommendationsRemovePost.Shows as List<ITraktSyncRecommendationsPostShow>)
                        .Add(CreateRecommendationsPostShow(showIds));
                }
            }
        }

        private static ITraktSyncRecommendationsPostMovie CreateRecommendationsPostMovie(ITraktMovie movie)
            => new TraktSyncRecommendationsPostMovie
            {
                Ids = movie.Ids,
                Title = movie.Title,
                Year = movie.Year
            };

        private static ITraktSyncRecommendationsPostMovie CreateRecommendationsPostMovie(ITraktMovieIds movieIds)
            => new TraktSyncRecommendationsPostMovie { Ids = movieIds };

        private static ITraktSyncRecommendationsPostShow CreateRecommendationsPostShow(ITraktShow show)
            => new TraktSyncRecommendationsPostShow
            {
                Ids = show.Ids,
                Title = show.Title,
                Year = show.Year
            };

        private static ITraktSyncRecommendationsPostShow CreateRecommendationsPostShow(ITraktShowIds showIds)
            => new TraktSyncRecommendationsPostShow { Ids = showIds };
    }
}
