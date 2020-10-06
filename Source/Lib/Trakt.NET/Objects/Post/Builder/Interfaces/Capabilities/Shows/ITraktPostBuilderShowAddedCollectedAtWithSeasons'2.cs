namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using System;

    public interface ITraktPostBuilderShowAddedCollectedAtWithSeasons<TPostBuilderAddShow, out TPostObject>
        : ITraktPostBuilderShowAddedCollectedAt<TPostBuilderAddShow, TPostObject>
    {
        TPostBuilderAddShow CollectedAt(DateTime collectedAt, int[] seasons);

        TPostBuilderAddShow CollectedAt(DateTime collectedAt, int season, params int[] seasons);
    }
}
