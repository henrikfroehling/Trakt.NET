namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Get.Movies;
    using Interfaces;
    using Interfaces.Capabilities;
    using System;
    using System.Collections.Generic;

    internal class PostBuilderMovieAddedRating<TPostBuilderAddMovie, TPostObject>
        : ITraktPostBuilderMovieAddedRating<TPostBuilderAddMovie, TPostObject>
          where TPostBuilderAddMovie : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddMovieWithRating<TPostBuilderAddMovie, TPostObject>
    {
        private readonly TPostBuilderAddMovie _postBuilder;
        private ITraktMovie _currentMovie;
        private readonly List<Tuple<ITraktMovie, int>> _moviesAndRating;
        private readonly List<Tuple<ITraktMovie, int, DateTime>> _ratedMoviesAndRating;

        internal PostBuilderMovieAddedRating(TPostBuilderAddMovie postBuilder)
        {
            _postBuilder = postBuilder;
            _currentMovie = null;
            _moviesAndRating = new List<Tuple<ITraktMovie, int>>();
            _ratedMoviesAndRating = new List<Tuple<ITraktMovie, int, DateTime>>();
        }

        public TPostBuilderAddMovie WithRating(int rating)
        {
            _moviesAndRating.Add(new Tuple<ITraktMovie, int>(_currentMovie, rating));
            return _postBuilder;
        }

        public TPostBuilderAddMovie WithRating(int rating, DateTime ratedAt)
        {
            _ratedMoviesAndRating.Add(new Tuple<ITraktMovie, int, DateTime>(_currentMovie, rating, ratedAt));
            return _postBuilder;
        }

        public void SetCurrentMovie(ITraktMovie movie)
        {
            _currentMovie = movie;
        }
    }
}
