namespace TraktNet.Objects.Post.Capabilities
{
    using Get.Episodes;
    using System.Collections.Generic;

    internal interface IPostBuilderEpisodeAddedRatingDetail
    {
        List<PostBuilderRatedObject<ITraktEpisode>> EpisodesAndRating { get; }

        void SetCurrentEpisode(ITraktEpisode episode);
    }
}
