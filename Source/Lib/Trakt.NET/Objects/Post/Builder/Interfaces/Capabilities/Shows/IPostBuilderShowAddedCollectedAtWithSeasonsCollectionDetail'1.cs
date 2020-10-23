namespace TraktNet.Objects.Post.Builder.Capabilities
{
    using Get.Shows;
    using System.Collections.Generic;

    internal interface IPostBuilderShowAddedCollectedAtWithSeasonsCollectionDetail<TSeasonCollection>
    {
        List<PostBuilderCollectedObjectWithSeasons<ITraktShow, TSeasonCollection>> CollectedShowsWithSeasonsCollection { get; }

        void SetCurrentShow(ITraktShow show);
    }
}
