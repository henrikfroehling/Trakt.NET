namespace TraktNet.Objects.Post.Builder.Helper
{
    using Capabilities;
    using Get.Episodes;
    using System;
    using System.Collections.Generic;

    internal class PostBuilderEpisodeAddedRating<TPostBuilderAddEpisode, TPostObject>
        : ITraktPostBuilderEpisodeAddedRating<TPostBuilderAddEpisode, TPostObject>,
          IPostBuilderEpisodeAddedRatingDetail
          where TPostBuilderAddEpisode : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddEpisodeWithRating<TPostBuilderAddEpisode, TPostObject>
    {
        private readonly TPostBuilderAddEpisode _postBuilder;
        private ITraktEpisode _currentEpisode;

        internal PostBuilderEpisodeAddedRating(TPostBuilderAddEpisode postBuilder)
        {
            _postBuilder = postBuilder;
            _currentEpisode = null;
            EpisodesAndRating = new List<PostBuilderRatedObject<ITraktEpisode>>();
        }

        public List<PostBuilderRatedObject<ITraktEpisode>> EpisodesAndRating { get; }

        public TPostBuilderAddEpisode WithRating(int rating)
        {
            EpisodesAndRating.Add(new PostBuilderRatedObject<ITraktEpisode>
            {
                Object = _currentEpisode,
                Rating = rating
            });

            return _postBuilder;
        }

        public TPostBuilderAddEpisode WithRating(int rating, DateTime ratedAt)
        {
            EpisodesAndRating.Add(new PostBuilderRatedObject<ITraktEpisode>
            {
                Object = _currentEpisode,
                Rating = rating,
                RatedAt = ratedAt
            });

            return _postBuilder;
        }

        public void SetCurrentEpisode(ITraktEpisode episode)
        {
            _currentEpisode = episode;
        }
    }
}
