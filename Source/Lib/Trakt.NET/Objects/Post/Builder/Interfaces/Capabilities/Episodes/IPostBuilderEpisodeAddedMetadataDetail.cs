namespace TraktNet.Objects.Post.Builder.Capabilities
{
    using Get.Episodes;
    using System.Collections.Generic;

    internal interface IPostBuilderEpisodeAddedMetadataDetail
    {
        List<PostBuilderObjectWithMetadata<ITraktEpisode>> EpisodesAndMetadata { get; }

        void SetCurrentEpisode(ITraktEpisode episode);
    }
}
