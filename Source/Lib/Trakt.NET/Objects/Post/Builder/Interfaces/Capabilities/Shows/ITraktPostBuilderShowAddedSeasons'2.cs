namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Shows;
    using System.Collections.Generic;

    public interface ITraktPostBuilderShowAddedSeasons<TPostBuilderAddShow, out TPostObject>
        where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithSeasons<TPostBuilderAddShow, TPostObject>
    {
        List<PostBuilderObjectWithSeasons<ITraktShow, IEnumerable<int>>> ShowsWithSeasons { get; }

        TPostBuilderAddShow WithSeasons(int[] seasons);

        TPostBuilderAddShow WithSeasons(int season, params int[] seasons);

        void SetCurrentShow(ITraktShow show);
    }
}
