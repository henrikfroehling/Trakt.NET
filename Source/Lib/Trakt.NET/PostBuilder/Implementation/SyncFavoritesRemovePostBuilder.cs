namespace TraktNet.PostBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.Favorites;

    internal sealed class SyncFavoritesRemovePostBuilder : ITraktSyncFavoritesRemovePostBuilder
    {
        private readonly Lazy<List<ITraktMovie>> _movies;
        private readonly Lazy<List<ITraktMovieIds>> _movieIds;
        private readonly Lazy<List<ITraktShow>> _shows;
        private readonly Lazy<List<ITraktShowIds>> _showIds;

        internal SyncFavoritesRemovePostBuilder()
        {
            _movies = new Lazy<List<ITraktMovie>>();
            _movieIds = new Lazy<List<ITraktMovieIds>>();
            _shows = new Lazy<List<ITraktShow>>();
            _showIds = new Lazy<List<ITraktShowIds>>();
        }

        public ITraktSyncFavoritesRemovePostBuilder WithMovie(ITraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            _movies.Value.Add(movie);
            return this;
        }

        public ITraktSyncFavoritesRemovePostBuilder WithMovie(ITraktMovieIds movieIds)
        {
            if (movieIds == null)
                throw new ArgumentNullException(nameof(movieIds));

            _movieIds.Value.Add(movieIds);
            return this;
        }

        public ITraktSyncFavoritesRemovePostBuilder WithMovies(IEnumerable<ITraktMovie> movies)
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

        public ITraktSyncFavoritesRemovePostBuilder WithMovies(IEnumerable<ITraktMovieIds> movieIds)
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

        public ITraktSyncFavoritesRemovePostBuilder WithShow(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _shows.Value.Add(show);
            return this;
        }

        public ITraktSyncFavoritesRemovePostBuilder WithShow(ITraktShowIds showIds)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            _showIds.Value.Add(showIds);
            return this;
        }

        public ITraktSyncFavoritesRemovePostBuilder WithShows(IEnumerable<ITraktShow> shows)
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

        public ITraktSyncFavoritesRemovePostBuilder WithShows(IEnumerable<ITraktShowIds> showIds)
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

        public ITraktSyncFavoritesRemovePost Build()
        {
            ITraktSyncFavoritesRemovePost syncFavoritesRemovePost = new TraktSyncFavoritesRemovePost();
            AddMovies(syncFavoritesRemovePost);
            AddShows(syncFavoritesRemovePost);
            syncFavoritesRemovePost.Validate();
            return syncFavoritesRemovePost;
        }

        private void AddMovies(ITraktSyncFavoritesRemovePost syncFavoritesRemovePost)
        {
            if (!_movies.IsValueCreated && !_movieIds.IsValueCreated)
                return;

            syncFavoritesRemovePost.Movies ??= new List<ITraktSyncFavoritesPostMovie>();

            if (_movies.IsValueCreated && _movies.Value.Any())
            {
                foreach (ITraktMovie movie in _movies.Value)
                    syncFavoritesRemovePost.Movies.Add(CreateFavoritesPostMovie(movie));
            }

            if (_movieIds.IsValueCreated && _movieIds.Value.Any())
            {
                foreach (ITraktMovieIds movieIds in _movieIds.Value)
                    syncFavoritesRemovePost.Movies.Add(CreateFavoritesPostMovie(movieIds));
            }
        }

        private void AddShows(ITraktSyncFavoritesRemovePost syncFavoritesRemovePost)
        {
            if (!_shows.IsValueCreated && !_showIds.IsValueCreated)
                return;

            syncFavoritesRemovePost.Shows ??= new List<ITraktSyncFavoritesPostShow>();

            if (_shows.IsValueCreated && _shows.Value.Any())
            {
                foreach (ITraktShow show in _shows.Value)
                    syncFavoritesRemovePost.Shows.Add(CreateFavoritesPostShow(show));
            }

            if (_showIds.IsValueCreated && _showIds.Value.Any())
            {
                foreach (ITraktShowIds showIds in _showIds.Value)
                    syncFavoritesRemovePost.Shows.Add(CreateFavoritesPostShow(showIds));
            }
        }

        private static ITraktSyncFavoritesPostMovie CreateFavoritesPostMovie(ITraktMovie movie)
            => new TraktSyncFavoritesPostMovie
            {
                Ids = movie.Ids,
                Title = movie.Title,
                Year = movie.Year
            };

        private static ITraktSyncFavoritesPostMovie CreateFavoritesPostMovie(ITraktMovieIds movieIds)
            => new TraktSyncFavoritesPostMovie { Ids = movieIds };

        private static ITraktSyncFavoritesPostShow CreateFavoritesPostShow(ITraktShow show)
            => new TraktSyncFavoritesPostShow
            {
                Ids = show.Ids,
                Title = show.Title,
                Year = show.Year
            };

        private static ITraktSyncFavoritesPostShow CreateFavoritesPostShow(ITraktShowIds showIds)
            => new TraktSyncFavoritesPostShow { Ids = showIds };
    }
}
