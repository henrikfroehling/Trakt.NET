namespace TraktNet.Objects.Post.Builder.Capabilities
{
    using Get.Shows;
    using System.Collections.Generic;

    internal interface IPostBuilderShowAddedMetadataWithSeasonsDetail
    {
        List<PostBuilderObjectWithMetadataAndSeasons<ITraktShow, IEnumerable<int>>> ShowsAndMetadataWithSeasons { get; }

        void SetCurrentShow(ITraktShow show);
    }
}
