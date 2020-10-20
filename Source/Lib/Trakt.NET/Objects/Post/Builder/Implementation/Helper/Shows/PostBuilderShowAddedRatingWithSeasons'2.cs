namespace TraktNet.Objects.Post.Builder.Helper
{
    using Capabilities;
    using Get.Shows;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class PostBuilderShowAddedRatingWithSeasons<TPostBuilderAddShow, TPostObject>
        : ITraktPostBuilderShowAddedRatingWithSeasons<TPostBuilderAddShow, TPostObject>
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithRatingWithSeasons<TPostBuilderAddShow, TPostObject>
    {
        private readonly TPostBuilderAddShow _postBuilder;
        private ITraktShow _currentShow;

        internal PostBuilderShowAddedRatingWithSeasons(TPostBuilderAddShow postBuilder)
        {
            _postBuilder = postBuilder;
            _currentShow = null;
            ShowsAndRatingWithSeasons = new List<PostBuilderRatedObjectWithSeasons<ITraktShow, IEnumerable<int>>>();
        }

        public List<PostBuilderRatedObjectWithSeasons<ITraktShow, IEnumerable<int>>> ShowsAndRatingWithSeasons { get; }

        public TPostBuilderAddShow WithRating(int rating, int[] seasons)
        {
            ShowsAndRatingWithSeasons.Add(new PostBuilderRatedObjectWithSeasons<ITraktShow, IEnumerable<int>>
            {
                Object = _currentShow,
                Rating = rating,
                Seasons = seasons.ToList()
            });

            return _postBuilder;
        }

        public TPostBuilderAddShow WithRating(int rating, DateTime ratedAt, int[] seasons)
        {
            ShowsAndRatingWithSeasons.Add(new PostBuilderRatedObjectWithSeasons<ITraktShow, IEnumerable<int>>
            {
                Object = _currentShow,
                Rating = rating,
                RatedAt = ratedAt,
                Seasons = seasons.ToList()
            });

            return _postBuilder;
        }

        public TPostBuilderAddShow WithRating(int rating, int season, params int[] seasons)
        {
            var newSeasons = new List<int>
            {
               season
            };

            newSeasons.AddRange(seasons);

            ShowsAndRatingWithSeasons.Add(new PostBuilderRatedObjectWithSeasons<ITraktShow, IEnumerable<int>>
            {
                Object = _currentShow,
                Rating = rating,
                Seasons = newSeasons
            });

            return _postBuilder;
        }

        public TPostBuilderAddShow WithRating(int rating, DateTime ratedAt, int season, params int[] seasons)
        {
            var newSeasons = new List<int>
            {
                season
            };

            newSeasons.AddRange(seasons);

            ShowsAndRatingWithSeasons.Add(new PostBuilderRatedObjectWithSeasons<ITraktShow, IEnumerable<int>>
            {
                Object = _currentShow,
                Rating = rating,
                RatedAt = ratedAt,
                Seasons = newSeasons
            });

            return _postBuilder;
        }

        public void SetCurrentShow(ITraktShow show)
        {
            _currentShow = show;
        }
    }
}
