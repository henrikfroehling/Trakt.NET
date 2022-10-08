namespace TraktNet.PostBuilder
{
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Shows;

    internal interface IPostBuilderShowAddedCollectedAtWithSeasonsCollectionDetail<TSeasonCollection>
    {
        List<PostBuilderCollectedObjectWithSeasons<ITraktShow, TSeasonCollection>> CollectedShowsWithSeasonsCollection { get; }

        void SetCurrentShow(ITraktShow show);
    }
}
