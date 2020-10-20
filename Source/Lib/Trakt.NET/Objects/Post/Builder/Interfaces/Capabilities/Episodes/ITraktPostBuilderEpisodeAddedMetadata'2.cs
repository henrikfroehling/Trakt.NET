namespace TraktNet.Objects.Post.Builder.Capabilities
{
    using Basic;
    using Get.Episodes;
    using System;
    using System.Collections.Generic;

    public interface ITraktPostBuilderEpisodeAddedMetadata<TPostBuilderAddEpisode, out TPostObject>
        where TPostBuilderAddEpisode : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddEpisodeWithMetadata<TPostBuilderAddEpisode, TPostObject>
    {
        List<PostBuilderObjectWithMetadata<ITraktEpisode>> EpisodesAndMetadata { get; }

        TPostBuilderAddEpisode WithMetadata(ITraktMetadata metadata);

        TPostBuilderAddEpisode WithMetadata(ITraktMetadata metadata, DateTime collectedAt);

        void SetCurrentEpisode(ITraktEpisode episode);
    }
}
