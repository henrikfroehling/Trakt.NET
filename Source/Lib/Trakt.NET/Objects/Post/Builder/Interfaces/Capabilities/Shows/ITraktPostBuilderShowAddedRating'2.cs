namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Shows;
    using System;
    using System.Collections.Generic;

    public interface ITraktPostBuilderShowAddedRating<TPostBuilderAddShow, out TPostObject>
        where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithRating<TPostBuilderAddShow, TPostObject>
    {
        List<PostBuilderRatedObject<ITraktShow>> ShowsAndRating { get; }

        TPostBuilderAddShow WithRating(int rating);

        TPostBuilderAddShow WithRating(int rating, DateTime ratedAt);

        void SetCurrentShow(ITraktShow show);
    }
}
