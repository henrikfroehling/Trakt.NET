﻿namespace TraktNet.Objects.Post.Builder.Implementation.Helper
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
