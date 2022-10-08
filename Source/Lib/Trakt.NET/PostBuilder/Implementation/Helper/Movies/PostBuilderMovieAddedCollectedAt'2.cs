namespace TraktNet.PostBuilder
{
    using System;
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Movies;

    internal class PostBuilderMovieAddedCollectedAt<TPostBuilderAddMovie, TPostObject>
        : ITraktPostBuilderMovieAddedCollectedAt<TPostBuilderAddMovie, TPostObject>,
          IPostBuilderMovieAddedCollectedAtDetail
          where TPostBuilderAddMovie : ITraktPostBuilder<TPostObject>, ITraktPostBuilderMovieWithCollectedAt<TPostBuilderAddMovie, TPostObject>
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
