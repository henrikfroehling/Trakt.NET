namespace TraktNet.Objects.Post.Builder.Capabilities
{
    using Get.Episodes;
    using System.Collections.Generic;

    internal interface IPostBuilderEpisodeAddedCollectedAtDetail
    {
        List<PostBuilderCollectedObject<ITraktEpisode>> CollectedEpisodes { get; }

        void SetCurrentEpisode(ITraktEpisode episode);
    }
}
