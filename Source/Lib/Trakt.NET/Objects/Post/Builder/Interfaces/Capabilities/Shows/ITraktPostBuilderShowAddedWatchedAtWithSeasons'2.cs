namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Shows;
    using System;
    using System.Collections.Generic;

    public interface ITraktPostBuilderShowAddedWatchedAtWithSeasons<TPostBuilderAddShow, out TPostObject>
        where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithWatchedAtWithSeasons<TPostBuilderAddShow, TPostObject>
    {
        List<PostBuilderWatchedObjectWithSeasons<ITraktShow, IEnumerable<int>>> WatchedShowsWithSeasons { get; }

        TPostBuilderAddShow WatchedAt(DateTime watchedAt, int[] seasons);

        TPostBuilderAddShow WatchedAt(DateTime watchedAt, int season, params int[] seasons);

        void SetCurrentShow(ITraktShow show);
    }
}
