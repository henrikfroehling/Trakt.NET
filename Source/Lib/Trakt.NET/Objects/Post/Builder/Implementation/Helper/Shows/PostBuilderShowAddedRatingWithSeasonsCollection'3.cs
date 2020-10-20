namespace TraktNet.Objects.Post.Builder.Helper
{
    using Capabilities;
    using Get.Shows;
    using System;
    using System.Collections.Generic;

    internal class PostBuilderShowAddedRatingWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
        : ITraktPostBuilderShowAddedRatingWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>,
                                      ITraktPostBuilderAddShowWithRatingWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
    {
        private readonly TPostBuilderAddShow _postBuilder;
        private ITraktShow _currentShow;

        internal PostBuilderShowAddedRatingWithSeasonsCollection(TPostBuilderAddShow postBuilder)
        {
            _postBuilder = postBuilder;
            _currentShow = null;
            ShowsAndRatingWithSeasonsCollection = new List<PostBuilderRatedObjectWithSeasons<ITraktShow, TSeasonCollection>>();
        }

        public List<PostBuilderRatedObjectWithSeasons<ITraktShow, TSeasonCollection>> ShowsAndRatingWithSeasonsCollection { get; }

        public TPostBuilderAddShow WithRating(int rating, TSeasonCollection seasons)
        {
            ShowsAndRatingWithSeasonsCollection.Add(new PostBuilderRatedObjectWithSeasons<ITraktShow, TSeasonCollection>
            {
                Object = _currentShow,
                Rating = rating,
                Seasons = seasons
            });

            return _postBuilder;
        }

        public TPostBuilderAddShow WithRating(int rating, DateTime ratedAt, TSeasonCollection seasons)
        {
            ShowsAndRatingWithSeasonsCollection.Add(new PostBuilderRatedObjectWithSeasons<ITraktShow, TSeasonCollection>
            {
                Object = _currentShow,
                Rating = rating,
                RatedAt = ratedAt,
                Seasons = seasons
            });

            return _postBuilder;
        }

        public void SetCurrentShow(ITraktShow show)
        {
            _currentShow = show;
        }
    }
}
