namespace TraktNet.Objects.Post.Builder.Capabilities
{
    using Get.Episodes;
    using System.Collections.Generic;

    internal interface IPostBuilderEpisodeAddedRatingDetail
    {
        List<PostBuilderRatedObject<ITraktEpisode>> EpisodesAndRating { get; }

        void SetCurrentEpisode(ITraktEpisode episode);
    }
}
