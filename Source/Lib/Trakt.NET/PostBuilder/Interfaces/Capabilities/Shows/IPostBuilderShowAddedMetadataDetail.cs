namespace TraktNet.PostBuilder
{
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Shows;

    internal interface IPostBuilderShowAddedMetadataDetail
    {
        List<PostBuilderObjectWithMetadata<ITraktShow>> ShowsAndMetadata { get; }

        void SetCurrentShow(ITraktShow show);
    }
}
