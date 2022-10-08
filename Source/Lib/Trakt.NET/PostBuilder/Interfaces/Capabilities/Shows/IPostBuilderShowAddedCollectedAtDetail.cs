namespace TraktNet.PostBuilder
{
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Shows;

    internal interface IPostBuilderShowAddedCollectedAtDetail
    {
        List<PostBuilderCollectedObject<ITraktShow>> CollectedShows { get; }

        void SetCurrentShow(ITraktShow show);
    }
}
