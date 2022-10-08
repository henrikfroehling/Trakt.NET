namespace TraktNet.PostBuilder
{
    using Objects.Basic;
    using System;

    public interface ITraktPostBuilderEpisodeAddedMetadata<TPostBuilderAddEpisode, out TPostObject>
        where TPostBuilderAddEpisode : ITraktPostBuilder<TPostObject>, ITraktPostBuilderEpisodeWithMetadata<TPostBuilderAddEpisode, TPostObject>
    {
        TPostBuilderAddEpisode WithMetadata(ITraktMetadata metadata);

        TPostBuilderAddEpisode WithMetadata(ITraktMetadata metadata, DateTime collectedAt);
    }
}
