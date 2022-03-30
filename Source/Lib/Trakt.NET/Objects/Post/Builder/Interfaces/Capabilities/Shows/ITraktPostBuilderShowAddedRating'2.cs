namespace TraktNet.Objects.Post.Capabilities
{
    using System;

    public interface ITraktPostBuilderShowAddedRating<TPostBuilderAddShow, out TPostObject>
        where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderShowWithRating<TPostBuilderAddShow, TPostObject>
    {
        TPostBuilderAddShow WithRating(int rating);

        TPostBuilderAddShow WithRating(int rating, DateTime ratedAt);
    }
}
