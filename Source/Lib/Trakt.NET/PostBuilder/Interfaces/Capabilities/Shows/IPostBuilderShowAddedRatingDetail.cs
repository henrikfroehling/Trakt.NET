namespace TraktNet.PostBuilder
{
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Shows;

    internal interface IPostBuilderShowAddedRatingDetail
    {
        List<PostBuilderRatedObject<ITraktShow>> ShowsAndRating { get; }

        void SetCurrentShow(ITraktShow show);
    }
}
