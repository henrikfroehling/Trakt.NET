namespace TraktNet.Objects.Post.Capabilities
{
    using Get.Shows;
    using System.Collections.Generic;

    internal interface IPostBuilderShowAddedWatchedAtDetail
    {
        List<PostBuilderWatchedObject<ITraktShow>> WatchedShows { get; }

        void SetCurrentShow(ITraktShow show);
    }
}
