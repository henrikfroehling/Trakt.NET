namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Basic;
    using System;

    public interface ITraktPostBuilderEpisodeAddedMetadata<TPostBuilderAddEpisode, out TPostObject> : ITraktPostBuilder<TPostObject>
    {
        TPostBuilderAddEpisode WithMetadata(ITraktMetadata metadata);

        TPostBuilderAddEpisode WithMetadata(ITraktMetadata metadata, DateTime collectedAt);
    }
}
