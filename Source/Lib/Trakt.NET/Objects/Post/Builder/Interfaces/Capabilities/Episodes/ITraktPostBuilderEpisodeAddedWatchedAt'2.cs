namespace TraktNet.Objects.Post.Builder.Capabilities
{
    using Get.Episodes;
    using System;
    using System.Collections.Generic;

    public interface ITraktPostBuilderEpisodeAddedWatchedAt<TPostBuilderAddEpisode, out TPostObject>
        where TPostBuilderAddEpisode : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddEpisodeWithWatchedAt<TPostBuilderAddEpisode, TPostObject>
    {
        List<PostBuilderWatchedObject<ITraktEpisode>> WatchedEpisodes { get; }

        TPostBuilderAddEpisode WatchedAt(DateTime watchedAt);

        void SetCurrentEpisode(ITraktEpisode episode);
    }
}
