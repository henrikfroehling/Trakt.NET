namespace TraktNet.Objects.Post.Builder.Capabilities
{
    using Get.Shows;
    using System.Collections.Generic;

    public interface ITraktPostBuilderShowAddedSeasonsCollection<TPostBuilderAddShow, out TPostObject, TSeasonCollection>
        where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
    {
        List<PostBuilderObjectWithSeasons<ITraktShow, TSeasonCollection>> ShowsWithSeasonsCollection { get; }

        TPostBuilderAddShow WithSeasons(TSeasonCollection seasons);

        void SetCurrentShow(ITraktShow show);
    }
}
