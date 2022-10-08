namespace TraktNet.PostBuilder
{
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Episodes;

    internal interface IPostBuilderEpisodeAddedCollectedAtDetail
    {
        List<PostBuilderCollectedObject<ITraktEpisode>> CollectedEpisodes { get; }

        void SetCurrentEpisode(ITraktEpisode episode);
    }
}
