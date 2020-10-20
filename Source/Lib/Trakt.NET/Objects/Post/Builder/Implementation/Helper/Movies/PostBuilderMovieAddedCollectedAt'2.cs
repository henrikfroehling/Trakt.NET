namespace TraktNet.Objects.Post.Builder.Helper
{
    using Capabilities;
    using Get.Movies;
    using System;
    using System.Collections.Generic;

    internal class PostBuilderMovieAddedCollectedAt<TPostBuilderAddMovie, TPostObject>
        : ITraktPostBuilderMovieAddedCollectedAt<TPostBuilderAddMovie, TPostObject>
          where TPostBuilderAddMovie : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddMovieWithCollectedAt<TPostBuilderAddMovie, TPostObject>
    {
        private readonly TPostBuilderAddMovie _postBuilder;
        private ITraktMovie _currentMovie;

        internal PostBuilderMovieAddedCollectedAt(TPostBuilderAddMovie postBuilder)
        {
            _postBuilder = postBuilder;
            _currentMovie = null;
            CollectedMovies = new List<PostBuilderCollectedObject<ITraktMovie>>();
        }

        public List<PostBuilderCollectedObject<ITraktMovie>> CollectedMovies { get; }

        public TPostBuilderAddMovie CollectedAt(DateTime collectedAt)
        {
            CollectedMovies.Add(new PostBuilderCollectedObject<ITraktMovie>
            {
                Object = _currentMovie,
                CollectedAt = collectedAt
            });

            return _postBuilder;
        }

        public void SetCurrentMovie(ITraktMovie movie)
        {
            _currentMovie = movie;
        }
    }
}
