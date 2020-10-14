namespace TraktNet.Objects.Post.Builder.Implementation.Helper
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
        private readonly List<PostBuilderObjectWithMetadata<ITraktShow>> _showsAndMetadata;

        internal PostBuilderShowAddedMetadata(TPostBuilderAddShow postBuilder)
        {
            _postBuilder = postBuilder;
            _currentShow = null;
            _showsAndMetadata = new List<PostBuilderObjectWithMetadata<ITraktShow>>();
        }

        public TPostBuilderAddShow WithMetadata(ITraktMetadata metadata)
        {
            _showsAndMetadata.Add(new PostBuilderObjectWithMetadata<ITraktShow>
            {
                Object = _currentShow,
                Metadata = metadata
            });

            return _postBuilder;
        }

        public TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, DateTime collectedAt)
        {
            _showsAndMetadata.Add(new PostBuilderObjectWithMetadata<ITraktShow>
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
