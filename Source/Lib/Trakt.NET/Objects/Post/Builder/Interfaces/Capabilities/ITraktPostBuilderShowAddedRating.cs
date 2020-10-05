namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using System;

    public interface ITraktPostBuilderShowAddedRating<TPostBuilderAddShow, out TPostObject> : ITraktPostBuilder<TPostObject>
    {
        TPostBuilderAddShow WithRating(int rating);

        TPostBuilderAddShow WithRating(int rating, DateTime ratedAt);
    }
}
