namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Get.Movies;
    using Interfaces;
    using Interfaces.Capabilities;
    using System;
    using System.Collections.Generic;

    internal class PostBuilderMovieAddedCollectedAt<TPostBuilderAddMovie, TPostObject>
        : ITraktPostBuilderMovieAddedCollectedAt<TPostBuilderAddMovie, TPostObject>
          where TPostBuilderAddMovie : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddMovieWithCollectedAt<TPostBuilderAddMovie, TPostObject>
    {
        private readonly TPostBuilderAddMovie _postBuilder;
        private ITraktMovie _currentMovie;
        private readonly List<Tuple<ITraktMovie, DateTime>> _collectedMovies;

        internal PostBuilderMovieAddedCollectedAt(TPostBuilderAddMovie postBuilder)
        {
            _postBuilder = postBuilder;
            _currentMovie = null;
            _collectedMovies = new List<Tuple<ITraktMovie, DateTime>>();
        }

        public TPostBuilderAddMovie CollectedAt(DateTime collectedAt)
        {
            _collectedMovies.Add(new Tuple<ITraktMovie, DateTime>(_currentMovie, collectedAt));
            return _postBuilder;
        }

        public void SetCurrentMovie(ITraktMovie movie)
        {
            _currentMovie = movie;
        }
    }
}
