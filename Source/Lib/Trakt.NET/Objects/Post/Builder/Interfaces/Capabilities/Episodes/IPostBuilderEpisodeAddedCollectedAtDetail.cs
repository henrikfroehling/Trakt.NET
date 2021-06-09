namespace TraktNet.Objects.Post.Capabilities
{
    using Get.Episodes;
    using System.Collections.Generic;

    internal interface IPostBuilderEpisodeAddedCollectedAtDetail
    {
        List<PostBuilderCollectedObject<ITraktEpisode>> CollectedEpisodes { get; }

        void SetCurrentEpisode(ITraktEpisode episode);
    }
}
