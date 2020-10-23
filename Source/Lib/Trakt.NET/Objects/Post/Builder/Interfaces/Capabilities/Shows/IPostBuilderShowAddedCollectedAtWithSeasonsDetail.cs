namespace TraktNet.Objects.Post.Builder.Capabilities
{
    using Get.Shows;
    using System.Collections.Generic;

    internal interface IPostBuilderShowAddedCollectedAtWithSeasonsDetail
    {
        List<PostBuilderCollectedObjectWithSeasons<ITraktShow, IEnumerable<int>>> CollectedShowsWithSeasons { get; }

        void SetCurrentShow(ITraktShow show);
    }
}
