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
        private readonly List<ITraktMovie> _movies;
        private readonly List<PostBuilderObjectWithNotes<ITraktMovie>> _moviesWithNotes;
        private readonly List<ITraktShow> _shows;
        private readonly List<PostBuilderObjectWithNotes<ITraktShow>> _showsWithNotes;

        internal SyncRecommendationsPostBuilder()
        {
            _movies = new List<ITraktMovie>();
            _moviesWithNotes = new List<PostBuilderObjectWithNotes<ITraktMovie>>();
            _shows = new List<ITraktShow>();
            _showsWithNotes = new List<PostBuilderObjectWithNotes<ITraktShow>>();
        }

        public ITraktSyncRecommendationsPostBuilder WithMovie(ITraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            _movies.Add(movie);
            return this;
        }

        public ITraktSyncRecommendationsPostBuilder WithMovieWithNotes(ITraktMovie movie, string notes)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            if (notes == null)
                throw new ArgumentNullException(nameof(notes));

            if (notes.Length > 255)
                throw new ArgumentOutOfRangeException(nameof(notes), "notes cannot be longer than 255 characters");

            _moviesWithNotes.Add(new PostBuilderObjectWithNotes<ITraktMovie>
            {
                Object = movie,
                Notes = notes
            });

            return this;
        }

        public ITraktSyncRecommendationsPostBuilder WithMovies(IEnumerable<ITraktMovie> movies)
        {
            if (movies == null)
                throw new ArgumentNullException(nameof(movies));

            _movies.AddRange(movies);
            return this;
        }

        public ITraktSyncRecommendationsPostBuilder WithMoviesWithNotes(IEnumerable<Tuple<ITraktMovie, string>> movies)
        {
            if (movies == null)
                throw new ArgumentNullException(nameof(movies));

            foreach (Tuple<ITraktMovie, string> tuple in movies)
            {
                if (tuple.Item2?.Length > 255)
                    throw new ArgumentOutOfRangeException($"movies[{movies.ToList().IndexOf(tuple)}].Notes", "notes cannot be longer than 255 characters");

                _moviesWithNotes.Add(new PostBuilderObjectWithNotes<ITraktMovie>
                {
                    Object = tuple.Item1,
                    Notes = tuple.Item2
                });
            }

            return this;
        }

        public ITraktSyncRecommendationsPostBuilder WithShow(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _shows.Add(show);
            return this;
        }

        public ITraktSyncRecommendationsPostBuilder WithShowWithNotes(ITraktShow show, string notes)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            if (notes == null)
                throw new ArgumentNullException(nameof(notes));

            if (notes.Length > 255)
                throw new ArgumentOutOfRangeException(nameof(notes), "notes cannot be longer than 255 characters");

            _showsWithNotes.Add(new PostBuilderObjectWithNotes<ITraktShow>
            {
                Object = show,
                Notes = notes
            });

            return this;
        }

        public ITraktSyncRecommendationsPostBuilder WithShows(IEnumerable<ITraktShow> shows)
        {
            if (shows == null)
                throw new ArgumentNullException(nameof(shows));

            _shows.AddRange(shows);
            return this;
        }

        public ITraktSyncRecommendationsPostBuilder WithShowsWithNotes(IEnumerable<Tuple<ITraktShow, string>> shows)
        {
            if (shows == null)
                throw new ArgumentNullException(nameof(shows));

            foreach (Tuple<ITraktShow, string> tuple in shows)
            {
                if (tuple.Item2?.Length > 255)
                    throw new ArgumentOutOfRangeException($"shows[{shows.ToList().IndexOf(tuple)}].Notes", "notes cannot be longer than 255 characters");

                _showsWithNotes.Add(new PostBuilderObjectWithNotes<ITraktShow>
                {
                    Object = tuple.Item1,
                    Notes = tuple.Item2
                });
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
            if (syncRecommendationsPost.Movies == null)
                syncRecommendationsPost.Movies = new List<ITraktSyncRecommendationsPostMovie>();

            foreach (ITraktMovie movie in _movies)
                (syncRecommendationsPost.Movies as List<ITraktSyncRecommendationsPostMovie>).Add(CreateSyncRecommendationsPostMovie(movie));

            foreach (PostBuilderObjectWithNotes<ITraktMovie> movieWithNotes in _moviesWithNotes)
                (syncRecommendationsPost.Movies as List<ITraktSyncRecommendationsPostMovie>).Add(CreateSyncRecommendationsPostMovie(movieWithNotes.Object, movieWithNotes.Notes));
        }

        private void AddShows(ITraktSyncRecommendationsPost syncRecommendationsPost)
        {
            if (syncRecommendationsPost.Shows == null)
                syncRecommendationsPost.Shows = new List<ITraktSyncRecommendationsPostShow>();

            foreach (ITraktShow show in _shows)
                (syncRecommendationsPost.Shows as List<ITraktSyncRecommendationsPostShow>).Add(CreateSyncRecommendationsPostShow(show));

            foreach (PostBuilderObjectWithNotes<ITraktShow> showWithNotes in _showsWithNotes)
                (syncRecommendationsPost.Shows as List<ITraktSyncRecommendationsPostShow>).Add(CreateSyncRecommendationsPostShow(showWithNotes.Object, showWithNotes.Notes));
        }

        private ITraktSyncRecommendationsPostMovie CreateSyncRecommendationsPostMovie(ITraktMovie movie, string notes = null)
        {
            var syncRecommendationsPostMovie = new TraktSyncRecommendationsPostMovie
            {
                Ids = movie.Ids,
                Title = movie.Title,
                Year = movie.Year
            };

            if (!string.IsNullOrWhiteSpace(notes))
                syncRecommendationsPostMovie.Notes = notes;

            return syncRecommendationsPostMovie;
        }

        private ITraktSyncRecommendationsPostShow CreateSyncRecommendationsPostShow(ITraktShow show, string notes = null)
        {
            var syncRecommendationsPostShow = new TraktSyncRecommendationsPostShow
            {
                Ids = show.Ids,
                Title = show.Title,
                Year = show.Year
            };

            if (!string.IsNullOrWhiteSpace(notes))
                syncRecommendationsPostShow.Notes = notes;

            return syncRecommendationsPostShow;
        }
    }
}
