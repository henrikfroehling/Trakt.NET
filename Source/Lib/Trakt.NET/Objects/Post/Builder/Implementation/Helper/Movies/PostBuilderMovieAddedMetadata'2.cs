namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Basic;
    using Get.Movies;
    using Interfaces;
    using Interfaces.Capabilities;
    using System;
    using System.Collections.Generic;

    internal class PostBuilderMovieAddedMetadata<TPostBuilderAddMovie, TPostObject>
        : ITraktPostBuilderMovieAddedMetadata<TPostBuilderAddMovie, TPostObject>
          where TPostBuilderAddMovie : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddMovieWithMetadata<TPostBuilderAddMovie, TPostObject>
    {
        private readonly TPostBuilderAddMovie _postBuilder;
        private ITraktMovie _currentMovie;
        private readonly List<Tuple<ITraktMovie, ITraktMetadata>> _moviesAndMetadata;
        private readonly List<Tuple<ITraktMovie, ITraktMetadata, DateTime>> _collectedMoviesAndMetadata;

        internal PostBuilderMovieAddedMetadata(TPostBuilderAddMovie postBuilder)
        {
            _postBuilder = postBuilder;
            _currentMovie = null;
            _moviesAndMetadata = new List<Tuple<ITraktMovie, ITraktMetadata>>();
            _collectedMoviesAndMetadata = new List<Tuple<ITraktMovie, ITraktMetadata, DateTime>>();
        }

        public TPostBuilderAddMovie WithMetadata(ITraktMetadata metadata)
        {
            _moviesAndMetadata.Add(new Tuple<ITraktMovie, ITraktMetadata>(_currentMovie, metadata));
            return _postBuilder;
        }

        public TPostBuilderAddMovie WithMetadata(ITraktMetadata metadata, DateTime collectedAt)
        {
            _collectedMoviesAndMetadata.Add(new Tuple<ITraktMovie, ITraktMetadata, DateTime>(_currentMovie, metadata, collectedAt));
            return _postBuilder;
        }

        public void SetCurrentMovie(ITraktMovie movie)
        {
            _currentMovie = movie;
        }
    }
}
