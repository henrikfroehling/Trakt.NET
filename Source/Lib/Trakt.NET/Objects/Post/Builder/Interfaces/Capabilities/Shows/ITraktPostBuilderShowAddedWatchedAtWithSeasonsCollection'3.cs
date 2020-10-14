namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Shows;
    using System;
    using System.Collections.Generic;

    public interface ITraktPostBuilderShowAddedWatchedAtWithSeasonsCollection<TPostBuilderAddShow, out TPostObject, TSeasonCollection>
        where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithWatchedAtWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
    {
        List<PostBuilderWatchedObjectWithSeasons<ITraktShow, TSeasonCollection>> WatchedShowsWithSeasonsCollection { get; }

        TPostBuilderAddShow WatchedAt(DateTime watchedAt, TSeasonCollection seasons);

        void SetCurrentShow(ITraktShow show);
    }
}
