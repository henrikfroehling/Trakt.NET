namespace TraktNet.Objects.Post.Capabilities
{
    using System;

    public interface ITraktPostBuilderEpisodeAddedCollectedAt<TPostBuilderAddEpisode, out TPostObject>
        where TPostBuilderAddEpisode : ITraktPostBuilder<TPostObject>, ITraktPostBuilderEpisodeWithCollectedAt<TPostBuilderAddEpisode, TPostObject>
    {
        TPostBuilderAddEpisode CollectedAt(DateTime collectedAt);
    }
}
