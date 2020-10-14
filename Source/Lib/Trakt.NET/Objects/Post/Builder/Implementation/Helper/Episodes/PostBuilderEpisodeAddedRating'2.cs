namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Get.Episodes;
    using Interfaces;
    using Interfaces.Capabilities;
    using System;
    using System.Collections.Generic;

    internal class PostBuilderEpisodeAddedRating<TPostBuilderAddEpisode, TPostObject>
        : ITraktPostBuilderEpisodeAddedRating<TPostBuilderAddEpisode, TPostObject>
          where TPostBuilderAddEpisode : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddEpisodeWithRating<TPostBuilderAddEpisode, TPostObject>
    {
        private readonly TPostBuilderAddEpisode _postBuilder;
        private ITraktEpisode _currentEpisode;
        private readonly List<PostBuilderRatedObject<ITraktEpisode>> _episodesAndRating;

        internal PostBuilderEpisodeAddedRating(TPostBuilderAddEpisode postBuilder)
        {
            _postBuilder = postBuilder;
            _currentEpisode = null;
            _episodesAndRating = new List<PostBuilderRatedObject<ITraktEpisode>>();
        }

        public TPostBuilderAddEpisode WithRating(int rating)
        {
            _episodesAndRating.Add(new PostBuilderRatedObject<ITraktEpisode>
            {
                Object = _currentEpisode,
                Rating = rating
            });

            return _postBuilder;
        }

        public TPostBuilderAddEpisode WithRating(int rating, DateTime ratedAt)
        {
            _episodesAndRating.Add(new PostBuilderRatedObject<ITraktEpisode>
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
