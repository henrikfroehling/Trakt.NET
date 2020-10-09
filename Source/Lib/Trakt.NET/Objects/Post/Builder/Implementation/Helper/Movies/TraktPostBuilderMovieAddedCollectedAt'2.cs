namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Interfaces;
    using Interfaces.Capabilities;
    using System;

    internal class TraktPostBuilderMovieAddedCollectedAt<TPostBuilderAddMovie, TPostObject>
        : ITraktPostBuilderMovieAddedCollectedAt<TPostBuilderAddMovie, TPostObject>
          where TPostBuilderAddMovie : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddMovieWithCollectedAt<TPostBuilderAddMovie, TPostObject>
    {
        internal TraktPostBuilderMovieAddedCollectedAt()
        {
        }

        public TPostBuilderAddMovie CollectedAt(DateTime collectedAt)
        {
            throw new NotImplementedException();
        }
    }
}
