namespace TraktNet.Objects.Post.Capabilities
{
    using System;

    public interface ITraktPostBuilderEpisodeAddedWatchedAt<TPostBuilderAddEpisode, out TPostObject>
        where TPostBuilderAddEpisode : ITraktPostBuilder<TPostObject>, ITraktPostBuilderEpisodeWithWatchedAt<TPostBuilderAddEpisode, TPostObject>
    {
        TPostBuilderAddEpisode WatchedAt(DateTime watchedAt);
    }
}
