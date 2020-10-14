﻿namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Basic;
    using Get.Shows;
    using Interfaces;
    using Interfaces.Capabilities;
    using System;
    using System.Collections.Generic;

    internal class PostBuilderShowAddedMetadata<TPostBuilderAddShow, TPostObject>
        : ITraktPostBuilderShowAddedMetadata<TPostBuilderAddShow, TPostObject>
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithMetadata<TPostBuilderAddShow, TPostObject>
    {
        private readonly TPostBuilderAddShow _postBuilder;
        private ITraktShow _currentShow;

        internal PostBuilderShowAddedMetadata(TPostBuilderAddShow postBuilder)
        {
            _postBuilder = postBuilder;
            _currentShow = null;
            ShowsAndMetadata = new List<PostBuilderObjectWithMetadata<ITraktShow>>();
        }

        public List<PostBuilderObjectWithMetadata<ITraktShow>> ShowsAndMetadata { get; }

        public TPostBuilderAddShow WithMetadata(ITraktMetadata metadata)
        {
            ShowsAndMetadata.Add(new PostBuilderObjectWithMetadata<ITraktShow>
            {
                Object = _currentShow,
                Metadata = metadata
            });

            return _postBuilder;
        }

        public TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, DateTime collectedAt)
        {
            ShowsAndMetadata.Add(new PostBuilderObjectWithMetadata<ITraktShow>
            {
                Object = _currentShow,
                Metadata = metadata,
                CollectedAt = collectedAt
            });

            return _postBuilder;
        }

        public void SetCurrentShow(ITraktShow show)
        {
            _currentShow = show;
        }
    }
}
