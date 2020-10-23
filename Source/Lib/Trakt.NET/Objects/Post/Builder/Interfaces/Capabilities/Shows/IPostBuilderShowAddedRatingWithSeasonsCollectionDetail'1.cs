namespace TraktNet.Objects.Post.Builder.Capabilities
{
    using Get.Shows;
    using System.Collections.Generic;

    internal interface IPostBuilderShowAddedRatingWithSeasonsCollectionDetail<TSeasonCollection>
    {
        List<PostBuilderRatedObjectWithSeasons<ITraktShow, TSeasonCollection>> ShowsAndRatingWithSeasonsCollection { get; }

        void SetCurrentShow(ITraktShow show);
    }
}
