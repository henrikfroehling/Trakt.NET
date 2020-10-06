namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using System;

    public interface ITraktPostBuilderShowAddedWatchedAtWithSeasons<TPostBuilderAddShow, out TPostObject> : ITraktPostBuilderShowAddedWatchedAt<TPostBuilderAddShow, TPostObject>
    {
        TPostBuilderAddShow WatchedAt(DateTime watchedAt, int[] seasons);

        TPostBuilderAddShow WatchedAt(DateTime watchedAt, int season, params int[] seasons);
    }
}
