namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using System;

    public interface ITraktPostBuilderEpisodeAddedCollectedAt<TPostBuilderAddEpisode, out TPostObject>
        where TPostBuilderAddEpisode : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddEpisodeWithCollectedAt<TPostBuilderAddEpisode, TPostObject>
    {
        TPostBuilderAddEpisode CollectedAt(DateTime collectedAt);
    }
}
