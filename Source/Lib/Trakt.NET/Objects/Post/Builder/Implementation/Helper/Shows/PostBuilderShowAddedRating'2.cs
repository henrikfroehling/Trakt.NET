namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Get.Shows;
    using Interfaces;
    using Interfaces.Capabilities;
    using System;
    using System.Collections.Generic;

    internal class PostBuilderShowAddedRating<TPostBuilderAddShow, TPostObject>
        : ITraktPostBuilderShowAddedRating<TPostBuilderAddShow, TPostObject>
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithRating<TPostBuilderAddShow, TPostObject>
    {
        private readonly TPostBuilderAddShow _postBuilder;
        private ITraktShow _currentShow;
        private readonly List<Tuple<ITraktShow, int>> _showsAndRating;
        private readonly List<Tuple<ITraktShow, int, DateTime>> _ratedShowsAndRating;

        internal PostBuilderShowAddedRating(TPostBuilderAddShow postBuilder)
        {
            _postBuilder = postBuilder;
            _currentShow = null;
            _showsAndRating = new List<Tuple<ITraktShow, int>>();
            _ratedShowsAndRating = new List<Tuple<ITraktShow, int, DateTime>>();
        }

        public TPostBuilderAddShow WithRating(int rating)
        {
            _showsAndRating.Add(new Tuple<ITraktShow, int>(_currentShow, rating));
            return _postBuilder;
        }

        public TPostBuilderAddShow WithRating(int rating, DateTime ratedAt)
        {
            _ratedShowsAndRating.Add(new Tuple<ITraktShow, int, DateTime>(_currentShow, rating, ratedAt));
            return _postBuilder;
        }

        public void SetCurrentShow(ITraktShow show)
        {
            _currentShow = show;
        }
    }
}
