namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Interfaces;
    using Interfaces.Capabilities;
    using System;

    internal class TraktPostBuilderEpisodeAddedWatchedAt<TPostBuilderAddEpisode, TPostObject>
        : ITraktPostBuilderEpisodeAddedWatchedAt<TPostBuilderAddEpisode, TPostObject>
          where TPostBuilderAddEpisode : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddEpisodeWithWatchedAt<TPostBuilderAddEpisode, TPostObject>
    {
        internal TraktPostBuilderEpisodeAddedWatchedAt()
        {
        }

        public TPostBuilderAddEpisode WatchedAt(DateTime watchedAt)
        {
            throw new NotImplementedException();
        }
    }
}
