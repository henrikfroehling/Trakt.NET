namespace TraktNet.Objects.Post.Helper
{
    using Capabilities;
    using Get.Movies;
    using System;
    using System.Collections.Generic;

    internal class PostBuilderMovieAddedWatchedAt<TPostBuilderAddMovie, TPostObject>
        : ITraktPostBuilderMovieAddedWatchedAt<TPostBuilderAddMovie, TPostObject>,
          IPostBuilderMovieAddedWatchedAtDetail
          where TPostBuilderAddMovie : ITraktPostBuilder<TPostObject>, ITraktPostBuilderMovieWithWatchedAt<TPostBuilderAddMovie, TPostObject>
    {
        private readonly TPostBuilderAddMovie _postBuilder;
        private ITraktMovie _currentMovie;

        internal PostBuilderMovieAddedWatchedAt(TPostBuilderAddMovie postBuilder)
        {
            _postBuilder = postBuilder;
            _currentMovie = null;
            WatchedMovies = new List<PostBuilderWatchedObject<ITraktMovie>>();
        }

        public List<PostBuilderWatchedObject<ITraktMovie>> WatchedMovies { get; }

        public TPostBuilderAddMovie WatchedAt(DateTime watchedAt)
        {
            WatchedMovies.Add(new PostBuilderWatchedObject<ITraktMovie>
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
