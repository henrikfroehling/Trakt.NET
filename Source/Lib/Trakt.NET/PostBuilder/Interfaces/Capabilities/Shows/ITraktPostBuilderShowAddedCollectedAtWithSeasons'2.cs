namespace TraktNet.PostBuilder
{
    using System;

    public interface ITraktPostBuilderShowAddedCollectedAtWithSeasons<TPostBuilderAddShow, out TPostObject>
        where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderShowWithCollectedAtWithSeasons<TPostBuilderAddShow, TPostObject>
    {
        TPostBuilderAddShow CollectedAt(DateTime collectedAt, int[] seasons);

        TPostBuilderAddShow CollectedAt(DateTime collectedAt, int season, params int[] seasons);
    }
}
