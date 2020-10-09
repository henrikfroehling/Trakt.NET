namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Interfaces;
    using Interfaces.Capabilities;
    using System;

    internal class TraktPostBuilderMovieAddedWatchedAt<TPostBuilderAddMovie, TPostObject>
        : ITraktPostBuilderMovieAddedWatchedAt<TPostBuilderAddMovie, TPostObject>
          where TPostBuilderAddMovie : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddMovieWithWatchedAt<TPostBuilderAddMovie, TPostObject>
    {
        internal TraktPostBuilderMovieAddedWatchedAt()
        {
        }

        public TPostBuilderAddMovie WatchedAt(DateTime watchedAt)
        {
            throw new NotImplementedException();
        }
    }
}
