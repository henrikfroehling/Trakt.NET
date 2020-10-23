namespace TraktNet.Objects.Post.Builder.Capabilities
{
    using System;

    public interface ITraktPostBuilderShowAddedWatchedAt<TPostBuilderAddShow, out TPostObject>
        where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithWatchedAt<TPostBuilderAddShow, TPostObject>
    {
        TPostBuilderAddShow WatchedAt(DateTime watchedAt);
    }
}
