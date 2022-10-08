namespace TraktNet.PostBuilder
{
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Shows;

    internal interface IPostBuilderShowAddedWatchedAtDetail
    {
        List<PostBuilderWatchedObject<ITraktShow>> WatchedShows { get; }

        void SetCurrentShow(ITraktShow show);
    }
}
