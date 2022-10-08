namespace TraktNet.PostBuilder
{
    using System;

    public interface ITraktPostBuilderShowAddedWatchedAtWithSeasons<TPostBuilderAddShow, out TPostObject>
        where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderShowWithWatchedAtWithSeasons<TPostBuilderAddShow, TPostObject>
    {
        TPostBuilderAddShow WatchedAt(DateTime watchedAt, int[] seasons);

        TPostBuilderAddShow WatchedAt(DateTime watchedAt, int season, params int[] seasons);
    }
}
