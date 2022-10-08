namespace TraktNet.PostBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.Recommendations;

    internal sealed class SyncRecommendationsPostBuilder : ITraktSyncRecommendationsPostBuilder
    {
        private readonly Lazy<List<ITraktMovie>> _movies;
        private readonly Lazy<List<ITraktMovieIds>> _movieIds;
        private readonly Lazy<List<MovieWithNotes>> _moviesWithNotes;
        private readonly Lazy<List<MovieIdsWithNotes>> _movieIdsWithNotes;
        private readonly Lazy<List<ITraktShow>> _shows;
        private readonly Lazy<List<ITraktShowIds>> _showIds;
        private readonly Lazy<List<ShowWithNotes>> _showsWithNotes;
        private readonly Lazy<List<ShowIdsWithNotes>> _showIdsWithNotes;

        internal SyncRecommendationsPostBuilder()
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

        public ITraktSyncRecommendationsPostBuilder WithMovie(ITraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            _movies.Value.Add(movie);
            return this;
        }

        public ITraktSyncRecommendationsPostBuilder WithMovie(ITraktMovieIds movieIds)
        {
            if (movieIds == null)
                throw new ArgumentNullException(nameof(movieIds));

            _movieIds.Value.Add(movieIds);
            return this;
        }

        public ITraktSyncRecommendationsPostBuilder WithMovieWithNotes(ITraktMovie movie, string notes)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            CheckNotes(notes);
            return WithMovieWithNotes(new MovieWithNotes(movie, notes));
        }

        public ITraktSyncRecommendationsPostBuilder WithMovieWithNotes(MovieWithNotes movieWithNotes)
        {
            if (movieWithNotes == null)
                throw new ArgumentNullException(nameof(movieWithNotes));

            CheckNotes(movieWithNotes.Notes);
            _moviesWithNotes.Value.Add(movieWithNotes);
            return this;
        }

        public ITraktSyncRecommendationsPostBuilder WithMovieWithNotes(ITraktMovieIds movieIds, string notes)
        {
            if (movieIds == null)
                throw new ArgumentNullException(nameof(movieIds));

            CheckNotes(notes);
            return WithMovieWithNotes(new MovieIdsWithNotes(movieIds, notes));
        }

        public ITraktSyncRecommendationsPostBuilder WithMovieWithNotes(MovieIdsWithNotes movieIdsWithNotes)
        {
            if (movieIdsWithNotes == null)
                throw new ArgumentNullException(nameof(movieIdsWithNotes));

            CheckNotes(movieIdsWithNotes.Notes);
            _movieIdsWithNotes.Value.Add(movieIdsWithNotes);
            return this;
        }

        public ITraktSyncRecommendationsPostBuilder WithMovies(IEnumerable<ITraktMovie> movies)
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

        public ITraktSyncRecommendationsPostBuilder WithMovies(IEnumerable<ITraktMovieIds> movieIds)
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

        public ITraktSyncRecommendationsPostBuilder WithMoviesWithNotes(IEnumerable<MovieWithNotes> moviesWithNotes)
        {
            if (moviesWithNotes == null)
                throw new ArgumentNullException(nameof(moviesWithNotes));

            foreach (MovieWithNotes movieWithNotes in moviesWithNotes)
            {
                if (movieWithNotes != null)
                {
                    CheckNotes(movieWithNotes.Notes);
                    _moviesWithNotes.Value.Add(movieWithNotes);
                }
            }

            return this;
        }

        public ITraktSyncRecommendationsPostBuilder WithMoviesWithNotes(IEnumerable<MovieIdsWithNotes> movieIdsWithNotes)
        {
            if (movieIdsWithNotes == null)
                throw new ArgumentNullException(nameof(movieIdsWithNotes));

            foreach (MovieIdsWithNotes movieIdWithNotes in movieIdsWithNotes)
            {
                if (movieIdWithNotes != null)
                {
                    CheckNotes(movieIdWithNotes.Notes);
                    _movieIdsWithNotes.Value.Add(movieIdWithNotes);
                }
            }

            return this;
        }

        public ITraktSyncRecommendationsPostBuilder WithShow(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _shows.Value.Add(show);
            return this;
        }

        public ITraktSyncRecommendationsPostBuilder WithShow(ITraktShowIds showIds)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            _showIds.Value.Add(showIds);
            return this;
        }

        public ITraktSyncRecommendationsPostBuilder WithShowWithNotes(ITraktShow show, string notes)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            CheckNotes(notes);
            return WithShowWithNotes(new ShowWithNotes(show, notes));
        }

        public ITraktSyncRecommendationsPostBuilder WithShowWithNotes(ShowWithNotes showWithNotes)
        {
            if (showWithNotes == null)
                throw new ArgumentNullException(nameof(showWithNotes));

            CheckNotes(showWithNotes.Notes);
            _showsWithNotes.Value.Add(showWithNotes);
            return this;
        }

        public ITraktSyncRecommendationsPostBuilder WithShowWithNotes(ITraktShowIds showIds, string notes)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            CheckNotes(notes);
            return WithShowWithNotes(new ShowIdsWithNotes(showIds, notes));
        }

        public ITraktSyncRecommendationsPostBuilder WithShowWithNotes(ShowIdsWithNotes showIdsWithNotes)
        {
            if (showIdsWithNotes == null)
                throw new ArgumentNullException(nameof(showIdsWithNotes));

            CheckNotes(showIdsWithNotes.Notes);
            _showIdsWithNotes.Value.Add(showIdsWithNotes);
            return this;
        }

        public ITraktSyncRecommendationsPostBuilder WithShows(IEnumerable<ITraktShow> shows)
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

        public ITraktSyncRecommendationsPostBuilder WithShows(IEnumerable<ITraktShowIds> showIds)
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

        public ITraktSyncRecommendationsPostBuilder WithShowsWithNotes(IEnumerable<ShowWithNotes> showsWithNotes)
        {
            if (showsWithNotes == null)
                throw new ArgumentNullException(nameof(showsWithNotes));

            foreach (ShowWithNotes showWithNotes in showsWithNotes)
            {
                if (showWithNotes != null)
                {
                    CheckNotes(showWithNotes.Notes);
                    _showsWithNotes.Value.Add(showWithNotes);
                }
            }

            return this;
        }

        public ITraktSyncRecommendationsPostBuilder WithShowsWithNotes(IEnumerable<ShowIdsWithNotes> showIdsWithNotes)
        {
            if (showIdsWithNotes == null)
                throw new ArgumentNullException(nameof(showIdsWithNotes));

            foreach (ShowIdsWithNotes showIdWithNotes in showIdsWithNotes)
            {
                if (showIdWithNotes != null)
                {
                    CheckNotes(showIdWithNotes.Notes);
                    _showIdsWithNotes.Value.Add(showIdWithNotes);
                }
            }

            return this;
        }

        public ITraktSyncRecommendationsPost Build()
        {
            ITraktSyncRecommendationsPost syncRecommendationsPost = new TraktSyncRecommendationsPost();
            AddMovies(syncRecommendationsPost);
            AddShows(syncRecommendationsPost);
            syncRecommendationsPost.Validate();
            return syncRecommendationsPost;
        }

        private void AddMovies(ITraktSyncRecommendationsPost syncRecommendationsPost)
        {
            if (!_movies.IsValueCreated && !_movieIds.IsValueCreated
                && !_moviesWithNotes.IsValueCreated && !_movieIdsWithNotes.IsValueCreated)
            {
                return;
            }

            syncRecommendationsPost.Movies ??= new List<ITraktSyncRecommendationsPostMovie>();

            if (_movies.IsValueCreated && _movies.Value.Any())
            {
                foreach (ITraktMovie movie in _movies.Value)
                {
                    (syncRecommendationsPost.Movies as List<ITraktSyncRecommendationsPostMovie>)
                        .Add(CreateRecommendationsPostMovie(movie));
                }
            }

            if (_movieIds.IsValueCreated && _movieIds.Value.Any())
            {
                foreach (ITraktMovieIds movieIds in _movieIds.Value)
                {
                    (syncRecommendationsPost.Movies as List<ITraktSyncRecommendationsPostMovie>)
                        .Add(CreateRecommendationsPostMovie(movieIds));
                }
            }

            if (_moviesWithNotes.IsValueCreated && _moviesWithNotes.Value.Any())
            {
                foreach (MovieWithNotes movieWithNotes in _moviesWithNotes.Value)
                {
                    (syncRecommendationsPost.Movies as List<ITraktSyncRecommendationsPostMovie>)
                        .Add(CreateRecommendationsPostMovie(movieWithNotes.Object, movieWithNotes.Notes));
                }
            }

            if (_movieIdsWithNotes.IsValueCreated && _movieIdsWithNotes.Value.Any())
            {
                foreach (MovieIdsWithNotes movieIdsWithNotes in _movieIdsWithNotes.Value)
                {
                    (syncRecommendationsPost.Movies as List<ITraktSyncRecommendationsPostMovie>)
                        .Add(CreateRecommendationsPostMovie(movieIdsWithNotes.Object, movieIdsWithNotes.Notes));
                }
            }
        }

        private void AddShows(ITraktSyncRecommendationsPost syncRecommendationsPost)
        {
            if (!_shows.IsValueCreated && !_showIds.IsValueCreated
                && !_showsWithNotes.IsValueCreated && !_showIdsWithNotes.IsValueCreated)
            {
                return;
            }

            syncRecommendationsPost.Shows ??= new List<ITraktSyncRecommendationsPostShow>();

            if (_shows.IsValueCreated && _shows.Value.Any())
            {
                foreach (ITraktShow show in _shows.Value)
                {
                    (syncRecommendationsPost.Shows as List<ITraktSyncRecommendationsPostShow>)
                        .Add(CreateRecommendationsPostShow(show));
                }
            }

            if (_showIds.IsValueCreated && _showIds.Value.Any())
            {
                foreach (ITraktShowIds showIds in _showIds.Value)
                {
                    (syncRecommendationsPost.Shows as List<ITraktSyncRecommendationsPostShow>)
                        .Add(CreateRecommendationsPostShow(showIds));
                }
            }

            if (_showsWithNotes.IsValueCreated && _showsWithNotes.Value.Any())
            {
                foreach (ShowWithNotes showWithNotes in _showsWithNotes.Value)
                {
                    (syncRecommendationsPost.Shows as List<ITraktSyncRecommendationsPostShow>)
                        .Add(CreateRecommendationsPostShow(showWithNotes.Object, showWithNotes.Notes));
                }
            }

            if (_showIdsWithNotes.IsValueCreated && _showIdsWithNotes.Value.Any())
            {
                foreach (ShowIdsWithNotes showIdsWithNotes in _showIdsWithNotes.Value)
                {
                    (syncRecommendationsPost.Shows as List<ITraktSyncRecommendationsPostShow>)
                        .Add(CreateRecommendationsPostShow(showIdsWithNotes.Object, showIdsWithNotes.Notes));
                }
            }
        }

        private static ITraktSyncRecommendationsPostMovie CreateRecommendationsPostMovie(ITraktMovie movie, string notes = null)
        {
            ITraktSyncRecommendationsPostMovie syncRecommendationsPostMovie = new TraktSyncRecommendationsPostMovie
            {
                Ids = movie.Ids,
                Title = movie.Title,
                Year = movie.Year
            };

            if (!string.IsNullOrEmpty(notes))
                syncRecommendationsPostMovie.Notes = notes;

            return syncRecommendationsPostMovie;
        }

        private static ITraktSyncRecommendationsPostMovie CreateRecommendationsPostMovie(ITraktMovieIds movieIds, string notes = null)
        {
            ITraktSyncRecommendationsPostMovie syncRecommendationsPostMovie = new TraktSyncRecommendationsPostMovie
            {
                Ids = movieIds
            };

            if (!string.IsNullOrEmpty(notes))
                syncRecommendationsPostMovie.Notes = notes;

            return syncRecommendationsPostMovie;
        }

        private static ITraktSyncRecommendationsPostShow CreateRecommendationsPostShow(ITraktShow show, string notes = null)
        {
            ITraktSyncRecommendationsPostShow syncRecommendationsPostShow = new TraktSyncRecommendationsPostShow
            {
                Ids = show.Ids,
                Title = show.Title,
                Year = show.Year
            };

            if (!string.IsNullOrEmpty(notes))
                syncRecommendationsPostShow.Notes = notes;

            return syncRecommendationsPostShow;
        }

        private static ITraktSyncRecommendationsPostShow CreateRecommendationsPostShow(ITraktShowIds showIds, string notes = null)
        {
            ITraktSyncRecommendationsPostShow syncRecommendationsPostShow = new TraktSyncRecommendationsPostShow
            {
                Ids = showIds
            };

            if (!string.IsNullOrEmpty(notes))
                syncRecommendationsPostShow.Notes = notes;

            return syncRecommendationsPostShow;
        }

        private static void CheckNotes(string notes)
        {
            if (notes == null)
                throw new ArgumentNullException(nameof(notes));

            if (notes.Length > 255)
                throw new ArgumentOutOfRangeException(nameof(notes));
        }
    }
}
