namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Shows;
    using System;
    using System.Collections.Generic;

    public interface ITraktPostBuilderShowAddedWatchedAt<TPostBuilderAddShow, out TPostObject>
        where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithWatchedAt<TPostBuilderAddShow, TPostObject>
    {
        List<PostBuilderWatchedObject<ITraktShow>> WatchedShows { get; }

        TPostBuilderAddShow WatchedAt(DateTime watchedAt);

        void SetCurrentShow(ITraktShow show);
    }
}
