namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using System;

    public interface ITraktPostBuilderEpisodeAddedWatchedAt<TPostBuilderAddEpisode, out TPostObject> : ITraktPostBuilder<TPostObject>
    {
        TPostBuilderAddEpisode WatchedAt(DateTime watchedAt);
    }
}
