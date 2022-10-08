namespace TraktNet.PostBuilder
{
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Shows;

    internal interface IPostBuilderShowAddedMetadataWithSeasonsCollectionDetail<TSeasonCollection>
    {
        List<PostBuilderObjectWithMetadataAndSeasons<ITraktShow, TSeasonCollection>> ShowsAndMetadataWithSeasonsCollection { get; }

        void SetCurrentShow(ITraktShow show);
    }
}
