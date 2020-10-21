namespace TraktNet.Objects.Post.Builder.Capabilities
{
    using System;

    public interface ITraktPostBuilderShowAddedRatingWithSeasons<TPostBuilderAddShow, out TPostObject>
        where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithRatingWithSeasons<TPostBuilderAddShow, TPostObject>
    {
        TPostBuilderAddShow WithRating(int rating, int[] seasons);

        TPostBuilderAddShow WithRating(int rating, DateTime ratedAt, int[] seasons);

        TPostBuilderAddShow WithRating(int rating, int season, params int[] seasons);

        TPostBuilderAddShow WithRating(int rating, DateTime ratedAt, int season, params int[] seasons);
    }
}
