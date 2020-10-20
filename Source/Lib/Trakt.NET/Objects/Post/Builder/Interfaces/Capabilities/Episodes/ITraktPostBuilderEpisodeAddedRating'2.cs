namespace TraktNet.Objects.Post.Builder.Capabilities
{
    using Get.Episodes;
    using System;
    using System.Collections.Generic;

    public interface ITraktPostBuilderEpisodeAddedRating<TPostBuilderAddEpisode, out TPostObject>
        where TPostBuilderAddEpisode : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddEpisodeWithRating<TPostBuilderAddEpisode, TPostObject>
    {
        List<PostBuilderRatedObject<ITraktEpisode>> EpisodesAndRating { get; }

        TPostBuilderAddEpisode WithRating(int rating);

        TPostBuilderAddEpisode WithRating(int rating, DateTime ratedAt);

        void SetCurrentEpisode(ITraktEpisode episode);
    }
}
