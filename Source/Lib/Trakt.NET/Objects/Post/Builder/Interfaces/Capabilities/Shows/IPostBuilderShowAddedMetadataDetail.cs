namespace TraktNet.Objects.Post.Builder.Capabilities
{
    using Get.Shows;
    using System.Collections.Generic;

    internal interface IPostBuilderShowAddedMetadataDetail
    {
        List<PostBuilderObjectWithMetadata<ITraktShow>> ShowsAndMetadata { get; }

        void SetCurrentShow(ITraktShow show);
    }
}
