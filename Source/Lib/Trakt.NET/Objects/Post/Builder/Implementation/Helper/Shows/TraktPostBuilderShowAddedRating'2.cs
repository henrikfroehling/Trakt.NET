namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Interfaces;
    using Interfaces.Capabilities;
    using System;

    internal class TraktPostBuilderShowAddedRating<TPostBuilderAddShow, TPostObject>
        : ITraktPostBuilderShowAddedRating<TPostBuilderAddShow, TPostObject>
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithRating<TPostBuilderAddShow, TPostObject>
    {
        internal TraktPostBuilderShowAddedRating()
        {
        }

        public TPostBuilderAddShow WithRating(int rating)
        {
            throw new NotImplementedException();
        }

        public TPostBuilderAddShow WithRating(int rating, DateTime ratedAt)
        {
            throw new NotImplementedException();
        }
    }
}
