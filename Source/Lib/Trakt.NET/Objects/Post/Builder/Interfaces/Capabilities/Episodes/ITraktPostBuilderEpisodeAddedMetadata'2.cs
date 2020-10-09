namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Basic;
    using System;

    public interface ITraktPostBuilderEpisodeAddedMetadata<TPostBuilderAddEpisode, out TPostObject>
        where TPostBuilderAddEpisode : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddEpisodeWithMetadata<TPostBuilderAddEpisode, TPostObject>
    {
        TPostBuilderAddEpisode WithMetadata(ITraktMetadata metadata);

        TPostBuilderAddEpisode WithMetadata(ITraktMetadata metadata, DateTime collectedAt);
    }
}
