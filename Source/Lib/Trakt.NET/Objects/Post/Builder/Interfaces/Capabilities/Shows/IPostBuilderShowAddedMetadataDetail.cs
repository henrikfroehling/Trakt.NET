namespace TraktNet.Objects.Post.Capabilities
{
    using Get.Shows;
    using System.Collections.Generic;

    internal interface IPostBuilderShowAddedMetadataDetail
    {
        List<PostBuilderObjectWithMetadata<ITraktShow>> ShowsAndMetadata { get; }

        void SetCurrentShow(ITraktShow show);
    }
}
