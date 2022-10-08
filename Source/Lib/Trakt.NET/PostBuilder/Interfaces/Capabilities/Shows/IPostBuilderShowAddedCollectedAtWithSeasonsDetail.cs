namespace TraktNet.PostBuilder
{
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Shows;

    internal interface IPostBuilderShowAddedCollectedAtWithSeasonsDetail
    {
        List<PostBuilderCollectedObjectWithSeasons<ITraktShow, IEnumerable<int>>> CollectedShowsWithSeasons { get; }

        void SetCurrentShow(ITraktShow show);
    }
}
