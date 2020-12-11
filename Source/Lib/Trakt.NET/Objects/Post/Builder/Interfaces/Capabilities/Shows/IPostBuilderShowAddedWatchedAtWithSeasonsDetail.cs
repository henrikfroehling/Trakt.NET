namespace TraktNet.Objects.Post.Capabilities
{
    using Get.Shows;
    using System.Collections.Generic;

    internal interface IPostBuilderShowAddedWatchedAtWithSeasonsDetail
    {
        List<PostBuilderWatchedObjectWithSeasons<ITraktShow, IEnumerable<int>>> WatchedShowsWithSeasons { get; }

        void SetCurrentShow(ITraktShow show);
    }
}
