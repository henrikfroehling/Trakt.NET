namespace TraktNet.PostBuilder
{
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Shows;

    internal interface IPostBuilderShowAddedWatchedAtWithSeasonsCollectionDetail<TSeasonCollection>
    {
        List<PostBuilderWatchedObjectWithSeasons<ITraktShow, TSeasonCollection>> WatchedShowsWithSeasonsCollection { get; }

        void SetCurrentShow(ITraktShow show);
    }
}
