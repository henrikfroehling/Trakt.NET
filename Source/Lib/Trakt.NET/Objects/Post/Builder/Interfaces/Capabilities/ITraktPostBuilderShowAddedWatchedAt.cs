namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using System;

    public interface ITraktPostBuilderShowAddedWatchedAt<TPostBuilderAddShow, out TPostObject> : ITraktPostBuilder<TPostObject>
    {
        TPostBuilderAddShow WatchedAt(DateTime watchedAt);
    }
}
