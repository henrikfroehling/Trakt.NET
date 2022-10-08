namespace TraktNet.PostBuilder
{
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Shows;

    internal interface IPostBuilderShowAddedRatingWithSeasonsDetail
    {
        List<PostBuilderRatedObjectWithSeasons<ITraktShow, IEnumerable<int>>> ShowsAndRatingWithSeasons { get; }

        void SetCurrentShow(ITraktShow show);
    }
}
