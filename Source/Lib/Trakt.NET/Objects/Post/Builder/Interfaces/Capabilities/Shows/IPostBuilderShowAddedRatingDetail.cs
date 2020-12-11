namespace TraktNet.Objects.Post.Capabilities
{
    using Get.Shows;
    using System.Collections.Generic;

    internal interface IPostBuilderShowAddedRatingDetail
    {
        List<PostBuilderRatedObject<ITraktShow>> ShowsAndRating { get; }

        void SetCurrentShow(ITraktShow show);
    }
}
