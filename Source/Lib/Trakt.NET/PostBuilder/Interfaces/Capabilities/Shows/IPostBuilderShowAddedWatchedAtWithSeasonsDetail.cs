namespace TraktNet.PostBuilder
{
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Shows;

    internal interface IPostBuilderShowAddedWatchedAtWithSeasonsDetail
    {
        List<PostBuilderWatchedObjectWithSeasons<ITraktShow, IEnumerable<int>>> WatchedShowsWithSeasons { get; }

        void SetCurrentShow(ITraktShow show);
    }
}
