namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Get.Movies;
    using Interfaces;
    using Interfaces.Capabilities;
    using System;
    using System.Collections.Generic;

    internal class TraktPostBuilderMovieAddedWatchedAt<TPostBuilderAddMovie, TPostObject>
        : ITraktPostBuilderMovieAddedWatchedAt<TPostBuilderAddMovie, TPostObject>
          where TPostBuilderAddMovie : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddMovieWithWatchedAt<TPostBuilderAddMovie, TPostObject>
    {
        private readonly TPostBuilderAddMovie _postBuilder;
        private ITraktMovie _currentMovie;
        private readonly List<Tuple<ITraktMovie, DateTime>> _watchedMovies;

        internal TraktPostBuilderMovieAddedWatchedAt(TPostBuilderAddMovie postBuilder)
        {
            _postBuilder = postBuilder;
            _currentMovie = null;
            _watchedMovies = new List<Tuple<ITraktMovie, DateTime>>();
        }

        public TPostBuilderAddMovie WatchedAt(DateTime watchedAt)
        {
            _watchedMovies.Add(new Tuple<ITraktMovie, DateTime>(_currentMovie, watchedAt));
            return _postBuilder;
        }

        public void SetCurrentMovie(ITraktMovie movie)
        {
            _currentMovie = movie;
        }
    }
}
