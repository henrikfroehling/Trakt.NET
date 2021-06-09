namespace TraktNet.Objects.Post.Capabilities
{
    using Get.Shows;
    using System.Collections.Generic;

    internal interface IPostBuilderShowAddedCollectedAtDetail
    {
        List<PostBuilderCollectedObject<ITraktShow>> CollectedShows { get; }

        void SetCurrentShow(ITraktShow show);
    }
}
