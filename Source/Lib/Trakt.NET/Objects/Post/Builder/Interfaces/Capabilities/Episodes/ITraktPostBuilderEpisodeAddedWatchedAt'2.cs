namespace TraktNet.Objects.Post.Builder.Capabilities
{
    using System;

    public interface ITraktPostBuilderEpisodeAddedWatchedAt<TPostBuilderAddEpisode, out TPostObject>
        where TPostBuilderAddEpisode : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddEpisodeWithWatchedAt<TPostBuilderAddEpisode, TPostObject>
    {
        TPostBuilderAddEpisode WatchedAt(DateTime watchedAt);
    }
}
