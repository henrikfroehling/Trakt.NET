namespace TraktNet.Objects.Post.Builder.Capabilities
{
    using Get.Shows;
    using System.Collections.Generic;

    internal interface IPostBuilderShowAddedSeasonsDetail
    {
        List<PostBuilderObjectWithSeasons<ITraktShow, IEnumerable<int>>> ShowsWithSeasons { get; }

        void SetCurrentShow(ITraktShow show);
    }
}
