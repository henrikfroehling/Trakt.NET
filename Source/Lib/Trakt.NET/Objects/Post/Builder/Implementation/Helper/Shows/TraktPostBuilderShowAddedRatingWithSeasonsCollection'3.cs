namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Interfaces;
    using Interfaces.Capabilities;
    using System;

    internal class TraktPostBuilderShowAddedRatingWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
        : ITraktPostBuilderShowAddedRatingWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>,
                                      ITraktPostBuilderAddShowWithRatingWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
    {
        internal TraktPostBuilderShowAddedRatingWithSeasonsCollection()
        {
        }

        public TPostBuilderAddShow WithRating(int rating, TSeasonCollection seasons)
        {
            throw new NotImplementedException();
        }

        public TPostBuilderAddShow WithRating(int rating, DateTime ratedAt, TSeasonCollection seasons)
        {
            throw new NotImplementedException();
        }
    }
}
