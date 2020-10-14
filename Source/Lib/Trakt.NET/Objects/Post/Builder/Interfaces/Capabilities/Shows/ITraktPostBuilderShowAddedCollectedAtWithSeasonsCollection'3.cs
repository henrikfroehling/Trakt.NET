namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Shows;
    using System;
    using System.Collections.Generic;

    public interface ITraktPostBuilderShowAddedCollectedAtWithSeasonsCollection<TPostBuilderAddShow, out TPostObject, TSeasonCollection>
        where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithCollectedAtWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
    {
        List<PostBuilderCollectedObjectWithSeasons<ITraktShow, TSeasonCollection>> CollectedShowsWithSeasonsCollection { get; }

        TPostBuilderAddShow CollectedAt(DateTime collectedAt, TSeasonCollection seasons);

        void SetCurrentShow(ITraktShow show);
    }
}
