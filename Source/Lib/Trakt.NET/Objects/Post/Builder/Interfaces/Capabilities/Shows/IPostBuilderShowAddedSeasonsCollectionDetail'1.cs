namespace TraktNet.Objects.Post.Builder.Capabilities
{
    using Get.Shows;
    using System.Collections.Generic;

    internal interface IPostBuilderShowAddedSeasonsCollectionDetail<TSeasonCollection>
    {
        List<PostBuilderObjectWithSeasons<ITraktShow, TSeasonCollection>> ShowsWithSeasonsCollection { get; }

        void SetCurrentShow(ITraktShow show);
    }
}
