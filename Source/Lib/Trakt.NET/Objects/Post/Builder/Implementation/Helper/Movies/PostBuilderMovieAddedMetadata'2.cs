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
        private readonly List<PostBuilderObjectWithMetadata<ITraktMovie>> _moviesAndMetadata;

        internal PostBuilderMovieAddedMetadata(TPostBuilderAddMovie postBuilder)
        {
            _postBuilder = postBuilder;
            _currentMovie = null;
            _moviesAndMetadata = new List<PostBuilderObjectWithMetadata<ITraktMovie>>();
        }

        public TPostBuilderAddMovie WithMetadata(ITraktMetadata metadata)
        {
            _moviesAndMetadata.Add(new PostBuilderObjectWithMetadata<ITraktMovie>
            {
                Object = _currentMovie,
                Metadata = metadata
            });

            return _postBuilder;
        }

        public TPostBuilderAddMovie WithMetadata(ITraktMetadata metadata, DateTime collectedAt)
        {
            _moviesAndMetadata.Add(new PostBuilderObjectWithMetadata<ITraktMovie>
            {
                Object = _currentMovie,
                Metadata = metadata,
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
