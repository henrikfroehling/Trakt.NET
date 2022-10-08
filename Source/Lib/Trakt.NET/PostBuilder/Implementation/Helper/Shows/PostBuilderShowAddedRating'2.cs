namespace TraktNet.PostBuilder
{
    using System;
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Shows;

    internal class PostBuilderShowAddedRating<TPostBuilderAddShow, TPostObject>
        : ITraktPostBuilderShowAddedRating<TPostBuilderAddShow, TPostObject>,
          IPostBuilderShowAddedRatingDetail
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderShowWithRating<TPostBuilderAddShow, TPostObject>
    {
        private readonly TPostBuilderAddShow _postBuilder;
        private ITraktShow _currentShow;

        internal PostBuilderShowAddedRating(TPostBuilderAddShow postBuilder)
        {
            _postBuilder = postBuilder;
            _currentShow = null;
            ShowsAndRating = new List<PostBuilderRatedObject<ITraktShow>>();
        }

        public List<PostBuilderRatedObject<ITraktShow>> ShowsAndRating { get; }

        public TPostBuilderAddShow WithRating(int rating)
        {
            ShowsAndRating.Add(new PostBuilderRatedObject<ITraktShow>
            {
                Object = _currentShow,
                Rating = rating
            });

            return _postBuilder;
        }

        public TPostBuilderAddShow WithRating(int rating, DateTime ratedAt)
        {
            ShowsAndRating.Add(new PostBuilderRatedObject<ITraktShow>
            {
                Object = _currentShow,
                Rating = rating,
                RatedAt = ratedAt
            });

            return _postBuilder;
        }

        public void SetCurrentShow(ITraktShow show)
        {
            _currentShow = show;
        }
    }
}
