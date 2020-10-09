namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using System;

    public interface ITraktPostBuilderShowAddedCollectedAtWithSeasonsCollection<TPostBuilderAddShow, out TPostObject, TSeasonCollection>
        where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithCollectedAtWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
    {
        TPostBuilderAddShow CollectedAt(DateTime collectedAt, TSeasonCollection seasons);
    }
}
