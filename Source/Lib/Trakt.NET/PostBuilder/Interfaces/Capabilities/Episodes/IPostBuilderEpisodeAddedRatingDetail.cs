namespace TraktNet.PostBuilder
{
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Episodes;

    internal interface IPostBuilderEpisodeAddedRatingDetail
    {
        List<PostBuilderRatedObject<ITraktEpisode>> EpisodesAndRating { get; }

        void SetCurrentEpisode(ITraktEpisode episode);
    }
}
