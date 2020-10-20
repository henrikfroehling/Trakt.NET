namespace TraktNet.Objects.Post.Builder.Capabilities
{
    using Get.Shows;
    using System;
    using System.Collections.Generic;

    public interface ITraktPostBuilderShowAddedRatingWithSeasons<TPostBuilderAddShow, out TPostObject>
        where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithRatingWithSeasons<TPostBuilderAddShow, TPostObject>
    {
        List<PostBuilderRatedObjectWithSeasons<ITraktShow, IEnumerable<int>>> ShowsAndRatingWithSeasons { get; }

        TPostBuilderAddShow WithRating(int rating, int[] seasons);

        TPostBuilderAddShow WithRating(int rating, DateTime ratedAt, int[] seasons);

        TPostBuilderAddShow WithRating(int rating, int season, params int[] seasons);

        TPostBuilderAddShow WithRating(int rating, DateTime ratedAt, int season, params int[] seasons);

        void SetCurrentShow(ITraktShow show);
    }
}
