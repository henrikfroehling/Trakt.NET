namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Basic;
    using Interfaces;
    using Interfaces.Capabilities;
    using System;

    internal class TraktPostBuilderEpisodeAddedMetadata<TPostBuilderAddEpisode, TPostObject>
        : ITraktPostBuilderEpisodeAddedMetadata<TPostBuilderAddEpisode, TPostObject>
          where TPostBuilderAddEpisode : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddEpisodeWithMetadata<TPostBuilderAddEpisode, TPostObject>
    {
        internal TraktPostBuilderEpisodeAddedMetadata()
        {
        }

        public TPostBuilderAddEpisode WithMetadata(ITraktMetadata metadata)
        {
            throw new NotImplementedException();
        }

        public TPostBuilderAddEpisode WithMetadata(ITraktMetadata metadata, DateTime collectedAt)
        {
            throw new NotImplementedException();
        }
    }
}
