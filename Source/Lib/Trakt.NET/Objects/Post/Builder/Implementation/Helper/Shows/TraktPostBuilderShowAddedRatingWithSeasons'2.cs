namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Get.Shows;
    using Interfaces;
    using Interfaces.Capabilities;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class TraktPostBuilderShowAddedRatingWithSeasons<TPostBuilderAddShow, TPostObject>
        : ITraktPostBuilderShowAddedRatingWithSeasons<TPostBuilderAddShow, TPostObject>
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithRatingWithSeasons<TPostBuilderAddShow, TPostObject>
    {
        private readonly TPostBuilderAddShow _postBuilder;
        private ITraktShow _currentShow;
        private readonly List<Tuple<ITraktShow, int, List<int>>> _showsAndRatingWithSeasons;
        private readonly List<Tuple<ITraktShow, int, DateTime, List<int>>> _ratedShowsAndRatingWithSeasons;

        internal TraktPostBuilderShowAddedRatingWithSeasons(TPostBuilderAddShow postBuilder)
        {
            _postBuilder = postBuilder;
            _currentShow = null;
            _showsAndRatingWithSeasons = new List<Tuple<ITraktShow, int, List<int>>>();
            _ratedShowsAndRatingWithSeasons = new List<Tuple<ITraktShow, int, DateTime, List<int>>>();
        }

        public TPostBuilderAddShow WithRating(int rating, int[] seasons)
        {
            _showsAndRatingWithSeasons.Add(new Tuple<ITraktShow, int, List<int>>(_currentShow, rating, seasons.ToList()));
            return _postBuilder;
        }

        public TPostBuilderAddShow WithRating(int rating, DateTime ratedAt, int[] seasons)
        {
            _ratedShowsAndRatingWithSeasons.Add(new Tuple<ITraktShow, int, DateTime, List<int>>(_currentShow, rating, ratedAt, seasons.ToList()));
            return _postBuilder;
        }

        public TPostBuilderAddShow WithRating(int rating, int season, params int[] seasons)
        {
            var newSeasons = new List<int>
            {
               season
            };

            newSeasons.AddRange(seasons);
            _showsAndRatingWithSeasons.Add(new Tuple<ITraktShow, int, List<int>>(_currentShow, rating, newSeasons));
            return _postBuilder;
        }

        public TPostBuilderAddShow WithRating(int rating, DateTime ratedAt, int season, params int[] seasons)
        {
            var newSeasons = new List<int>
            {
                season
            };

            newSeasons.AddRange(seasons);
            _ratedShowsAndRatingWithSeasons.Add(new Tuple<ITraktShow, int, DateTime, List<int>>(_currentShow, rating, ratedAt, newSeasons));
            return _postBuilder;
        }

        public void SetCurrentShow(ITraktShow show)
        {
            _currentShow = show;
        }
    }
}
