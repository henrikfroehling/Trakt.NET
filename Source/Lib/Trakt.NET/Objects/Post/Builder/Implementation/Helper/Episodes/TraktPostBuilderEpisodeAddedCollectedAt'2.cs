namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Interfaces;
    using Interfaces.Capabilities;
    using System;

    internal class TraktPostBuilderEpisodeAddedCollectedAt<TPostBuilderAddEpisode, TPostObject>
        : ITraktPostBuilderEpisodeAddedCollectedAt<TPostBuilderAddEpisode, TPostObject>
          where TPostBuilderAddEpisode : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddEpisodeWithCollectedAt<TPostBuilderAddEpisode, TPostObject>
    {
        internal TraktPostBuilderEpisodeAddedCollectedAt()
        {
        }

        public TPostBuilderAddEpisode CollectedAt(DateTime collectedAt)
        {
            throw new NotImplementedException();
        }
    }
}
