namespace TraktNet.PostBuilder
{
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Episodes;

    internal interface IPostBuilderEpisodeAddedWatchedAtDetail
    {
        List<PostBuilderWatchedObject<ITraktEpisode>> WatchedEpisodes { get; }

        void SetCurrentEpisode(ITraktEpisode episode);
    }
}
