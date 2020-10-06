namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using System;

    public interface ITraktPostBuilderShowAddedCollectedAtWithSeasonsCollection<TPostBuilderAddShow, out TPostObject, TSeasonCollection>
        : ITraktPostBuilderShowAddedCollectedAtWithSeasons<TPostBuilderAddShow, TPostObject>
    {
        TPostBuilderAddShow CollectedAt(DateTime collectedAt, TSeasonCollection seasons);
    }
}
