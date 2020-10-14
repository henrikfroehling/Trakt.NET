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
        private readonly List<PostBuilderRatedObject<ITraktMovie>> _moviesAndRating;

        internal PostBuilderMovieAddedRating(TPostBuilderAddMovie postBuilder)
        {
            _postBuilder = postBuilder;
            _currentMovie = null;
            _moviesAndRating = new List<PostBuilderRatedObject<ITraktMovie>>();
        }

        public TPostBuilderAddMovie WithRating(int rating)
        {
            _moviesAndRating.Add(new PostBuilderRatedObject<ITraktMovie>
            {
                Object = _currentMovie,
                Rating = rating
            });

            return _postBuilder;
        }

        public TPostBuilderAddMovie WithRating(int rating, DateTime ratedAt)
        {
            _moviesAndRating.Add(new PostBuilderRatedObject<ITraktMovie>
            {
                Object = _currentMovie,
                Rating = rating,
                RatedAt = ratedAt
            });

            return _postBuilder;
        }

        public void SetCurrentMovie(ITraktMovie movie)
        {
            _currentMovie = movie;
        }
    }
}
