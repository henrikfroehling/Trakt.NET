namespace TraktNet.Objects.Post.Builder.Capabilities
{
    using Get.Shows;
    using System;
    using System.Collections.Generic;

    public interface ITraktPostBuilderShowAddedCollectedAtWithSeasons<TPostBuilderAddShow, out TPostObject>
        where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithCollectedAtWithSeasons<TPostBuilderAddShow, TPostObject>
    {
        List<PostBuilderCollectedObjectWithSeasons<ITraktShow, IEnumerable<int>>> CollectedShowsWithSeasons { get; }

        TPostBuilderAddShow CollectedAt(DateTime collectedAt, int[] seasons);

        TPostBuilderAddShow CollectedAt(DateTime collectedAt, int season, params int[] seasons);

        void SetCurrentShow(ITraktShow show);
    }
}
