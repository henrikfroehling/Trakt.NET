namespace TraktNet.PostBuilder
{
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Shows;

    internal interface IPostBuilderShowAddedMetadataWithSeasonsDetail
    {
        List<PostBuilderObjectWithMetadataAndSeasons<ITraktShow, IEnumerable<int>>> ShowsAndMetadataWithSeasons { get; }

        void SetCurrentShow(ITraktShow show);
    }
}
