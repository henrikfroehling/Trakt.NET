namespace TraktNet.Objects.Post.Capabilities
{
    using System;

    public interface ITraktPostBuilderShowAddedCollectedAtWithSeasonsCollection<TPostBuilderAddShow, out TPostObject, in TSeasonCollection>
        where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderShowWithCollectedAtWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
    {
        TPostBuilderAddShow CollectedAt(DateTime collectedAt, TSeasonCollection seasons);
    }
}
