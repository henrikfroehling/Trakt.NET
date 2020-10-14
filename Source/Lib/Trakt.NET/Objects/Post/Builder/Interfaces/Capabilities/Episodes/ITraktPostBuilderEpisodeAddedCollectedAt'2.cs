namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Episodes;
    using System;
    using System.Collections.Generic;

    public interface ITraktPostBuilderEpisodeAddedCollectedAt<TPostBuilderAddEpisode, out TPostObject>
        where TPostBuilderAddEpisode : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddEpisodeWithCollectedAt<TPostBuilderAddEpisode, TPostObject>
    {
        List<PostBuilderCollectedObject<ITraktEpisode>> CollectedEpisodes { get; }

        TPostBuilderAddEpisode CollectedAt(DateTime collectedAt);

        void SetCurrentEpisode(ITraktEpisode episode);
    }
}
