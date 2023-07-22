namespace TraktNet.PostBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.Favorites;

    internal sealed class SyncFavoritesPostBuilder : ITraktSyncFavoritesPostBuilder
    {
        private readonly Lazy<List<ITraktMovie>> _movies;
        private readonly Lazy<List<ITraktMovieIds>> _movieIds;
        private readonly Lazy<List<MovieWithNotes>> _moviesWithNotes;
        private readonly Lazy<List<MovieIdsWithNotes>> _movieIdsWithNotes;
        private readonly Lazy<List<ITraktShow>> _shows;
        private readonly Lazy<List<ITraktShowIds>> _showIds;
        private readonly Lazy<List<ShowWithNotes>> _showsWithNotes;
        private readonly Lazy<List<ShowIdsWithNotes>> _showIdsWithNotes;

        internal SyncFavoritesPostBuilder()
        {
            _movies = new Lazy<List<ITraktMovie>>();
            _movieIds = new Lazy<List<ITraktMovieIds>>();
            _moviesWithNotes = new Lazy<List<MovieWithNotes>>();
            _movieIdsWithNotes = new Lazy<List<MovieIdsWithNotes>>();
            _shows = new Lazy<List<ITraktShow>>();
            _showIds = new Lazy<List<ITraktShowIds>>();
            _showsWithNotes = new Lazy<List<ShowWithNotes>>();
            _showIdsWithNotes = new Lazy<List<ShowIdsWithNotes>>();
        }

        public ITraktSyncFavoritesPostBuilder WithMovie(ITraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            _movies.Value.Add(movie);
            return this;
        }

        public ITraktSyncFavoritesPostBuilder WithMovie(ITraktMovieIds movieIds)
        {
            if (movieIds == null)
                throw new ArgumentNullException(nameof(movieIds));

            _movieIds.Value.Add(movieIds);
            return this;
        }

        public ITraktSyncFavoritesPostBuilder WithMovieWithNotes(ITraktMovie movie, string notes)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            PostBuilderUtility.CheckNotes(notes);
            return WithMovieWithNotes(new MovieWithNotes(movie, notes));
        }

        public ITraktSyncFavoritesPostBuilder WithMovieWithNotes(MovieWithNotes movieWithNotes)
        {
            if (movieWithNotes == null)
                throw new ArgumentNullException(nameof(movieWithNotes));

            PostBuilderUtility.CheckNotes(movieWithNotes.Notes);
            _moviesWithNotes.Value.Add(movieWithNotes);
            return this;
        }

        public ITraktSyncFavoritesPostBuilder WithMovieWithNotes(ITraktMovieIds movieIds, string notes)
        {
            if (movieIds == null)
                throw new ArgumentNullException(nameof(movieIds));

            PostBuilderUtility.CheckNotes(notes);
            return WithMovieWithNotes(new MovieIdsWithNotes(movieIds, notes));
        }

        public ITraktSyncFavoritesPostBuilder WithMovieWithNotes(MovieIdsWithNotes movieIdsWithNotes)
        {
            if (movieIdsWithNotes == null)
                throw new ArgumentNullException(nameof(movieIdsWithNotes));

            PostBuilderUtility.CheckNotes(movieIdsWithNotes.Notes);
            _movieIdsWithNotes.Value.Add(movieIdsWithNotes);
            return this;
        }

        public ITraktSyncFavoritesPostBuilder WithMovies(IEnumerable<ITraktMovie> movies)
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

        public ITraktSyncFavoritesPostBuilder WithMovies(IEnumerable<ITraktMovieIds> movieIds)
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

        public ITraktSyncFavoritesPostBuilder WithMoviesWithNotes(IEnumerable<MovieWithNotes> moviesWithNotes)
        {
            if (moviesWithNotes == null)
                throw new ArgumentNullException(nameof(moviesWithNotes));

            foreach (MovieWithNotes movieWithNotes in moviesWithNotes)
            {
                if (movieWithNotes != null)
                {
                    PostBuilderUtility.CheckNotes(movieWithNotes.Notes);
                    _moviesWithNotes.Value.Add(movieWithNotes);
                }
            }

            return this;
        }

        public ITraktSyncFavoritesPostBuilder WithMoviesWithNotes(IEnumerable<MovieIdsWithNotes> movieIdsWithNotes)
        {
            if (movieIdsWithNotes == null)
                throw new ArgumentNullException(nameof(movieIdsWithNotes));

            foreach (MovieIdsWithNotes movieIdWithNotes in movieIdsWithNotes)
            {
                if (movieIdWithNotes != null)
                {
                    PostBuilderUtility.CheckNotes(movieIdWithNotes.Notes);
                    _movieIdsWithNotes.Value.Add(movieIdWithNotes);
                }
            }

            return this;
        }

        public ITraktSyncFavoritesPostBuilder WithShow(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _shows.Value.Add(show);
            return this;
        }

        public ITraktSyncFavoritesPostBuilder WithShow(ITraktShowIds showIds)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            _showIds.Value.Add(showIds);
            return this;
        }

        public ITraktSyncFavoritesPostBuilder WithShowWithNotes(ITraktShow show, string notes)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            PostBuilderUtility.CheckNotes(notes);
            return WithShowWithNotes(new ShowWithNotes(show, notes));
        }

        public ITraktSyncFavoritesPostBuilder WithShowWithNotes(ShowWithNotes showWithNotes)
        {
            if (showWithNotes == null)
                throw new ArgumentNullException(nameof(showWithNotes));

            PostBuilderUtility.CheckNotes(showWithNotes.Notes);
            _showsWithNotes.Value.Add(showWithNotes);
            return this;
        }

        public ITraktSyncFavoritesPostBuilder WithShowWithNotes(ITraktShowIds showIds, string notes)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            PostBuilderUtility.CheckNotes(notes);
            return WithShowWithNotes(new ShowIdsWithNotes(showIds, notes));
        }

        public ITraktSyncFavoritesPostBuilder WithShowWithNotes(ShowIdsWithNotes showIdsWithNotes)
        {
            if (showIdsWithNotes == null)
                throw new ArgumentNullException(nameof(showIdsWithNotes));

            PostBuilderUtility.CheckNotes(showIdsWithNotes.Notes);
            _showIdsWithNotes.Value.Add(showIdsWithNotes);
            return this;
        }

        public ITraktSyncFavoritesPostBuilder WithShows(IEnumerable<ITraktShow> shows)
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

        public ITraktSyncFavoritesPostBuilder WithShows(IEnumerable<ITraktShowIds> showIds)
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

        public ITraktSyncFavoritesPostBuilder WithShowsWithNotes(IEnumerable<ShowWithNotes> showsWithNotes)
        {
            if (showsWithNotes == null)
                throw new ArgumentNullException(nameof(showsWithNotes));

            foreach (ShowWithNotes showWithNotes in showsWithNotes)
            {
                if (showWithNotes != null)
                {
                    PostBuilderUtility.CheckNotes(showWithNotes.Notes);
                    _showsWithNotes.Value.Add(showWithNotes);
                }
            }

            return this;
        }

        public ITraktSyncFavoritesPostBuilder WithShowsWithNotes(IEnumerable<ShowIdsWithNotes> showIdsWithNotes)
        {
            if (showIdsWithNotes == null)
                throw new ArgumentNullException(nameof(showIdsWithNotes));

            foreach (ShowIdsWithNotes showIdWithNotes in showIdsWithNotes)
            {
                if (showIdWithNotes != null)
                {
                    PostBuilderUtility.CheckNotes(showIdWithNotes.Notes);
                    _showIdsWithNotes.Value.Add(showIdWithNotes);
                }
            }

            return this;
        }

        public ITraktSyncFavoritesPost Build()
        {
            ITraktSyncFavoritesPost syncFavoritesPost = new TraktSyncFavoritesPost();
            AddMovies(syncFavoritesPost);
            AddShows(syncFavoritesPost);
            syncFavoritesPost.Validate();
            return syncFavoritesPost;
        }

        private void AddMovies(ITraktSyncFavoritesPost syncFavoritesPost)
        {
            if (!_movies.IsValueCreated && !_movieIds.IsValueCreated
                && !_moviesWithNotes.IsValueCreated && !_movieIdsWithNotes.IsValueCreated)
            {
                return;
            }

            syncFavoritesPost.Movies ??= new List<ITraktSyncFavoritesPostMovie>();

            if (_movies.IsValueCreated && _movies.Value.Any())
            {
                foreach (ITraktMovie movie in _movies.Value)
                    syncFavoritesPost.Movies.Add(CreateFavoritesPostMovie(movie));
            }

            if (_movieIds.IsValueCreated && _movieIds.Value.Any())
            {
                foreach (ITraktMovieIds movieIds in _movieIds.Value)
                    syncFavoritesPost.Movies.Add(CreateFavoritesPostMovie(movieIds));
            }

            if (_moviesWithNotes.IsValueCreated && _moviesWithNotes.Value.Any())
            {
                foreach (MovieWithNotes movieWithNotes in _moviesWithNotes.Value)
                    syncFavoritesPost.Movies.Add(CreateFavoritesPostMovie(movieWithNotes.Object, movieWithNotes.Notes));
            }

            if (_movieIdsWithNotes.IsValueCreated && _movieIdsWithNotes.Value.Any())
            {
                foreach (MovieIdsWithNotes movieIdsWithNotes in _movieIdsWithNotes.Value)
                    syncFavoritesPost.Movies.Add(CreateFavoritesPostMovie(movieIdsWithNotes.Object, movieIdsWithNotes.Notes));
            }
        }

        private void AddShows(ITraktSyncFavoritesPost syncFavoritesPost)
        {
            if (!_shows.IsValueCreated && !_showIds.IsValueCreated
                && !_showsWithNotes.IsValueCreated && !_showIdsWithNotes.IsValueCreated)
            {
                return;
            }

            syncFavoritesPost.Shows ??= new List<ITraktSyncFavoritesPostShow>();

            if (_shows.IsValueCreated && _shows.Value.Any())
            {
                foreach (ITraktShow show in _shows.Value)
                    syncFavoritesPost.Shows.Add(CreateFavoritesPostShow(show));
            }

            if (_showIds.IsValueCreated && _showIds.Value.Any())
            {
                foreach (ITraktShowIds showIds in _showIds.Value)
                    syncFavoritesPost.Shows.Add(CreateFavoritesPostShow(showIds));
            }

            if (_showsWithNotes.IsValueCreated && _showsWithNotes.Value.Any())
            {
                foreach (ShowWithNotes showWithNotes in _showsWithNotes.Value)
                    syncFavoritesPost.Shows.Add(CreateFavoritesPostShow(showWithNotes.Object, showWithNotes.Notes));
            }

            if (_showIdsWithNotes.IsValueCreated && _showIdsWithNotes.Value.Any())
            {
                foreach (ShowIdsWithNotes showIdsWithNotes in _showIdsWithNotes.Value)
                    syncFavoritesPost.Shows.Add(CreateFavoritesPostShow(showIdsWithNotes.Object, showIdsWithNotes.Notes));
            }
        }

        private static ITraktSyncFavoritesPostMovie CreateFavoritesPostMovie(ITraktMovie movie, string notes = null)
        {
            ITraktSyncFavoritesPostMovie syncFavoritesPostMovie = new TraktSyncFavoritesPostMovie
            {
                Ids = movie.Ids,
                Title = movie.Title,
                Year = movie.Year
            };

            if (!string.IsNullOrEmpty(notes))
                syncFavoritesPostMovie.Notes = notes;

            return syncFavoritesPostMovie;
        }

        private static ITraktSyncFavoritesPostMovie CreateFavoritesPostMovie(ITraktMovieIds movieIds, string notes = null)
        {
            ITraktSyncFavoritesPostMovie syncFavoritesPostMovie = new TraktSyncFavoritesPostMovie
            {
                Ids = movieIds
            };

            if (!string.IsNullOrEmpty(notes))
                syncFavoritesPostMovie.Notes = notes;

            return syncFavoritesPostMovie;
        }

        private static ITraktSyncFavoritesPostShow CreateFavoritesPostShow(ITraktShow show, string notes = null)
        {
            ITraktSyncFavoritesPostShow syncFavoritesPostShow = new TraktSyncFavoritesPostShow
            {
                Ids = show.Ids,
                Title = show.Title,
                Year = show.Year
            };

            if (!string.IsNullOrEmpty(notes))
                syncFavoritesPostShow.Notes = notes;

            return syncFavoritesPostShow;
        }

        private static ITraktSyncFavoritesPostShow CreateFavoritesPostShow(ITraktShowIds showIds, string notes = null)
        {
            ITraktSyncFavoritesPostShow syncFavoritesPostShow = new TraktSyncFavoritesPostShow
            {
                Ids = showIds
            };

            if (!string.IsNullOrEmpty(notes))
                syncFavoritesPostShow.Notes = notes;

            return syncFavoritesPostShow;
        }
    }
}
