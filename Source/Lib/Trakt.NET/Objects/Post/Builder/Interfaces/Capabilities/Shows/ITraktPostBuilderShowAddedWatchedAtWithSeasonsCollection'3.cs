namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using System;

    public interface ITraktPostBuilderShowAddedWatchedAtWithSeasonsCollection<TPostBuilderAddShow, out TPostObject, TSeasonCollection>
        : ITraktPostBuilderShowAddedWatchedAtWithSeasons<TPostBuilderAddShow, TPostObject>
    {
        TPostBuilderAddShow WatchedAt(DateTime watchedAt, TSeasonCollection seasons);
    }
}
