namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Get.Movies;
    using Interfaces;
    using Interfaces.Capabilities;
    using System;
    using System.Collections.Generic;

    internal class PostBuilderMovieAddedWatchedAt<TPostBuilderAddMovie, TPostObject>
        : ITraktPostBuilderMovieAddedWatchedAt<TPostBuilderAddMovie, TPostObject>
          where TPostBuilderAddMovie : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddMovieWithWatchedAt<TPostBuilderAddMovie, TPostObject>
    {
        private readonly TPostBuilderAddMovie _postBuilder;
        private ITraktMovie _currentMovie;
        private readonly List<PostBuilderWatchedObject<ITraktMovie>> _watchedMovies;

        internal PostBuilderMovieAddedWatchedAt(TPostBuilderAddMovie postBuilder)
        {
            _postBuilder = postBuilder;
            _currentMovie = null;
            _watchedMovies = new List<PostBuilderWatchedObject<ITraktMovie>>();
        }

        public TPostBuilderAddMovie WatchedAt(DateTime watchedAt)
        {
            _watchedMovies.Add(new PostBuilderWatchedObject<ITraktMovie>
            {
                Object = _currentMovie,
                WatchedAt = watchedAt
            });

            return _postBuilder;
        }

        public void SetCurrentMovie(ITraktMovie movie)
        {
            _currentMovie = movie;
        }
    }
}
