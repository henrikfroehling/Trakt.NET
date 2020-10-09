namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using System;

    public interface ITraktPostBuilderShowAddedWatchedAtWithSeasonsCollection<TPostBuilderAddShow, out TPostObject, TSeasonCollection>
        where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithWatchedAtWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
    {
        TPostBuilderAddShow WatchedAt(DateTime watchedAt, TSeasonCollection seasons);
    }
}
