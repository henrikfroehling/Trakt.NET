namespace TraktNet.PostBuilder
{
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Episodes;

    internal interface IPostBuilderEpisodeAddedMetadataDetail
    {
        List<PostBuilderObjectWithMetadata<ITraktEpisode>> EpisodesAndMetadata { get; }

        void SetCurrentEpisode(ITraktEpisode episode);
    }
}
