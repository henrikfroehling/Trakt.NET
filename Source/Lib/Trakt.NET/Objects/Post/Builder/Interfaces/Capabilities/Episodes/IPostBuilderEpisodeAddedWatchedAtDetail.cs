namespace TraktNet.Objects.Post.Capabilities
{
    using Get.Episodes;
    using System.Collections.Generic;

    internal interface IPostBuilderEpisodeAddedWatchedAtDetail
    {
        List<PostBuilderWatchedObject<ITraktEpisode>> WatchedEpisodes { get; }

        void SetCurrentEpisode(ITraktEpisode episode);
    }
}
