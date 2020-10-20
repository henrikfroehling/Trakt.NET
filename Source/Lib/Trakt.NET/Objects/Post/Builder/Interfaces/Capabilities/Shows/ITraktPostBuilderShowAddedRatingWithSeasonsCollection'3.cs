namespace TraktNet.Objects.Post.Builder.Capabilities
{
    using Get.Shows;
    using System;
    using System.Collections.Generic;

    public interface ITraktPostBuilderShowAddedRatingWithSeasonsCollection<TPostBuilderAddShow, out TPostObject, TSeasonCollection>
        where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithRatingWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
    {
        List<PostBuilderRatedObjectWithSeasons<ITraktShow, TSeasonCollection>> ShowsAndRatingWithSeasonsCollection { get; }

        TPostBuilderAddShow WithRating(int rating, TSeasonCollection seasons);

        TPostBuilderAddShow WithRating(int rating, DateTime ratedAt, TSeasonCollection seasons);

        void SetCurrentShow(ITraktShow show);
    }
}
