namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Interfaces;
    using Interfaces.Capabilities;
    using System;

    internal class TraktPostBuilderShowAddedRatingWithSeasons<TPostBuilderAddShow, TPostObject>
        : ITraktPostBuilderShowAddedRatingWithSeasons<TPostBuilderAddShow, TPostObject>
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithRatingWithSeasons<TPostBuilderAddShow, TPostObject>
    {
        internal TraktPostBuilderShowAddedRatingWithSeasons()
        {
        }

        public TPostBuilderAddShow WithRating(int rating, int[] seasons)
        {
            throw new NotImplementedException();
        }

        public TPostBuilderAddShow WithRating(int rating, DateTime ratedAt, int[] seasons)
        {
            throw new NotImplementedException();
        }

        public TPostBuilderAddShow WithRating(int rating, int season, params int[] seasons)
        {
            throw new NotImplementedException();
        }

        public TPostBuilderAddShow WithRating(int rating, DateTime ratedAt, int season, params int[] seasons)
        {
            throw new NotImplementedException();
        }
    }
}
