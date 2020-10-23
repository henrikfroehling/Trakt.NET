namespace TraktNet.Objects.Post.Builder.Capabilities
{
    using Get.Shows;
    using System.Collections.Generic;

    internal interface IPostBuilderShowAddedMetadataWithSeasonsCollectionDetail<TSeasonCollection>
    {
        List<PostBuilderObjectWithMetadataAndSeasons<ITraktShow, TSeasonCollection>> ShowsAndMetadataWithSeasonsCollection { get; }

        void SetCurrentShow(ITraktShow show);
    }
}
