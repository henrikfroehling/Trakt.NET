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
        private readonly List<Tuple<ITraktEpisode, int>> _episodesAndRating;
        private readonly List<Tuple<ITraktEpisode, int, DateTime>> _ratedEpisodesAndRating;

        internal PostBuilderEpisodeAddedRating(TPostBuilderAddEpisode postBuilder)
        {
            _postBuilder = postBuilder;
            _currentEpisode = null;
            _episodesAndRating = new List<Tuple<ITraktEpisode, int>>();
            _ratedEpisodesAndRating = new List<Tuple<ITraktEpisode, int, DateTime>>();
        }

        public TPostBuilderAddEpisode WithRating(int rating)
        {
            _episodesAndRating.Add(new Tuple<ITraktEpisode, int>(_currentEpisode, rating));
            return _postBuilder;
        }

        public TPostBuilderAddEpisode WithRating(int rating, DateTime ratedAt)
        {
            _ratedEpisodesAndRating.Add(new Tuple<ITraktEpisode, int, DateTime>(_currentEpisode, rating, ratedAt));
            return _postBuilder;
        }

        public void SetCurrentEpisode(ITraktEpisode episode)
        {
            _currentEpisode = episode;
        }
    }
}
