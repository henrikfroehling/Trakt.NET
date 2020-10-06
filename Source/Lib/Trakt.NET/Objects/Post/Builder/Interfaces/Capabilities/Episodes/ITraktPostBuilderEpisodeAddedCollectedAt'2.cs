namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using System;

    public interface ITraktPostBuilderEpisodeAddedCollectedAt<TPostBuilderAddEpisode, out TPostObject> : ITraktPostBuilder<TPostObject>
    {
        TPostBuilderAddEpisode CollectedAt(DateTime collectedAt);
    }
}
