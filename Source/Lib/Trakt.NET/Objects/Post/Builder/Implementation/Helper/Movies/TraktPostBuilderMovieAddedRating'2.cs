namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Interfaces;
    using Interfaces.Capabilities;
    using System;

    internal class TraktPostBuilderMovieAddedRating<TPostBuilderAddMovie, TPostObject>
        : ITraktPostBuilderMovieAddedRating<TPostBuilderAddMovie, TPostObject>
          where TPostBuilderAddMovie : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddMovieWithRating<TPostBuilderAddMovie, TPostObject>
    {
        internal TraktPostBuilderMovieAddedRating()
        {
        }

        public TPostBuilderAddMovie WithRating(int rating)
        {
            throw new NotImplementedException();
        }

        public TPostBuilderAddMovie WithRating(int rating, DateTime ratedAt)
        {
            throw new NotImplementedException();
        }
    }
}
