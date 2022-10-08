namespace TraktNet.PostBuilder
{
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Shows;

    internal interface IPostBuilderShowAddedSeasonsDetail
    {
        List<PostBuilderObjectWithSeasons<ITraktShow, IEnumerable<int>>> ShowsWithSeasons { get; }

        void SetCurrentShow(ITraktShow show);
    }
}
