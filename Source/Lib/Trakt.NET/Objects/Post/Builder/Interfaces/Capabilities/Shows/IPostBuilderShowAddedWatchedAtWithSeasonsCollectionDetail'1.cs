namespace TraktNet.Objects.Post.Builder.Capabilities
{
    using Get.Shows;
    using System.Collections.Generic;

    internal interface IPostBuilderShowAddedWatchedAtWithSeasonsCollectionDetail<TSeasonCollection>
    {
        List<PostBuilderWatchedObjectWithSeasons<ITraktShow, TSeasonCollection>> WatchedShowsWithSeasonsCollection { get; }

        void SetCurrentShow(ITraktShow show);
    }
}
