namespace TraktNet.Objects.Post.Helper
{
    using Basic;
    using Capabilities;
    using Get.Shows;
    using System;
    using System.Collections.Generic;

    internal class PostBuilderShowAddedMetadata<TPostBuilderAddShow, TPostObject>
        : ITraktPostBuilderShowAddedMetadata<TPostBuilderAddShow, TPostObject>,
          IPostBuilderShowAddedMetadataDetail
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
