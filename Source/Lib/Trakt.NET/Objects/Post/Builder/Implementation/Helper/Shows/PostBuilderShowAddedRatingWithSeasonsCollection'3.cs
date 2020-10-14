namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Get.Shows;
    using Interfaces;
    using Interfaces.Capabilities;
    using System;
    using System.Collections.Generic;

    internal class PostBuilderShowAddedRatingWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
        : ITraktPostBuilderShowAddedRatingWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>,
                                      ITraktPostBuilderAddShowWithRatingWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
    {
        private readonly TPostBuilderAddShow _postBuilder;
        private ITraktShow _currentShow;
        private readonly List<PostBuilderRatedObjectWithSeasons<ITraktShow, TSeasonCollection>> _showsAndRatingWithSeasonsCollection;

        internal PostBuilderShowAddedRatingWithSeasonsCollection(TPostBuilderAddShow postBuilder)
        {
            _postBuilder = postBuilder;
            _currentShow = null;
            _showsAndRatingWithSeasonsCollection = new List<PostBuilderRatedObjectWithSeasons<ITraktShow, TSeasonCollection>>();
        }

        public TPostBuilderAddShow WithRating(int rating, TSeasonCollection seasons)
        {
            _showsAndRatingWithSeasonsCollection.Add(new PostBuilderRatedObjectWithSeasons<ITraktShow, TSeasonCollection>
            {
                Object = _currentShow,
                Rating = rating,
                Seasons = seasons
            });

            return _postBuilder;
        }

        public TPostBuilderAddShow WithRating(int rating, DateTime ratedAt, TSeasonCollection seasons)
        {
            _showsAndRatingWithSeasonsCollection.Add(new PostBuilderRatedObjectWithSeasons<ITraktShow, TSeasonCollection>
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
