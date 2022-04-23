namespace TraktNet.Objects.Post.Capabilities
{
    using System;

    public interface ITraktPostBuilderShowAddedWatchedAt<TPostBuilderAddShow, out TPostObject>
        where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderShowWithWatchedAt<TPostBuilderAddShow, TPostObject>
    {
        TPostBuilderAddShow WatchedAt(DateTime watchedAt);
    }
}
