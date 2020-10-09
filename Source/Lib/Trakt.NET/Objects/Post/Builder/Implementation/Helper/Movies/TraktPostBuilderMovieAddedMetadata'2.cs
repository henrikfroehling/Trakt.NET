namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Basic;
    using Interfaces;
    using Interfaces.Capabilities;
    using System;

    internal class TraktPostBuilderMovieAddedMetadata<TPostBuilderAddMovie, TPostObject>
        : ITraktPostBuilderMovieAddedMetadata<TPostBuilderAddMovie, TPostObject>
          where TPostBuilderAddMovie : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddMovieWithMetadata<TPostBuilderAddMovie, TPostObject>
    {
        internal TraktPostBuilderMovieAddedMetadata()
        {
        }

        public TPostBuilderAddMovie WithMetadata(ITraktMetadata metadata)
        {
            throw new NotImplementedException();
        }

        public TPostBuilderAddMovie WithMetadata(ITraktMetadata metadata, DateTime collectedAt)
        {
            throw new NotImplementedException();
        }
    }
}
