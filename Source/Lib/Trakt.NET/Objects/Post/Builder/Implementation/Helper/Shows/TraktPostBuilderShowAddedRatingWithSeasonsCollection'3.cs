namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Get.Shows;
    using Interfaces;
    using Interfaces.Capabilities;
    using System;
    using System.Collections.Generic;

    internal class TraktPostBuilderShowAddedRatingWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
        : ITraktPostBuilderShowAddedRatingWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>,
                                      ITraktPostBuilderAddShowWithRatingWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
    {
        private readonly TPostBuilderAddShow _postBuilder;
        private ITraktShow _currentShow;
        private readonly List<Tuple<ITraktShow, int, TSeasonCollection>> _showsAndRatingWithSeasonsCollection;
        private readonly List<Tuple<ITraktShow, int, DateTime, TSeasonCollection>> _ratedShowsAndRatingWithSeasonsCollection;

        internal TraktPostBuilderShowAddedRatingWithSeasonsCollection(TPostBuilderAddShow postBuilder)
        {
            _postBuilder = postBuilder;
            _currentShow = null;
            _showsAndRatingWithSeasonsCollection = new List<Tuple<ITraktShow, int, TSeasonCollection>>();
            _ratedShowsAndRatingWithSeasonsCollection = new List<Tuple<ITraktShow, int, DateTime, TSeasonCollection>>();
        }

        public TPostBuilderAddShow WithRating(int rating, TSeasonCollection seasons)
        {
            _showsAndRatingWithSeasonsCollection.Add(new Tuple<ITraktShow, int, TSeasonCollection>(_currentShow, rating, seasons));
            return _postBuilder;
        }

        public TPostBuilderAddShow WithRating(int rating, DateTime ratedAt, TSeasonCollection seasons)
        {
            _ratedShowsAndRatingWithSeasonsCollection.Add(new Tuple<ITraktShow, int, DateTime, TSeasonCollection>(_currentShow, rating, ratedAt, seasons));
            return _postBuilder;
        }

        public void SetCurrentShow(ITraktShow show)
        {
            _currentShow = show;
        }
    }
}
