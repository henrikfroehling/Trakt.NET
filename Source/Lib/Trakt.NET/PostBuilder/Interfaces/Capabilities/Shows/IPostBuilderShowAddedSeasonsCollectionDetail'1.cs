namespace TraktNet.PostBuilder
{
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Shows;

    internal interface IPostBuilderShowAddedSeasonsCollectionDetail<TSeasonCollection>
    {
        List<PostBuilderObjectWithSeasons<ITraktShow, TSeasonCollection>> ShowsWithSeasonsCollection { get; }

        void SetCurrentShow(ITraktShow show);
    }
}
