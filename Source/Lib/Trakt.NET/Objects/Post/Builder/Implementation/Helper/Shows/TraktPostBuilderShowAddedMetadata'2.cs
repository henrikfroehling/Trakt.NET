namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Basic;
    using Get.Shows;
    using Interfaces;
    using Interfaces.Capabilities;
    using System;
    using System.Collections.Generic;

    internal class TraktPostBuilderShowAddedMetadata<TPostBuilderAddShow, TPostObject>
        : ITraktPostBuilderShowAddedMetadata<TPostBuilderAddShow, TPostObject>
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithMetadata<TPostBuilderAddShow, TPostObject>
    {
        private readonly TPostBuilderAddShow _postBuilder;
        private ITraktShow _currentShow;
        private readonly List<Tuple<ITraktShow, ITraktMetadata>> _showsAndMetadata;
        private readonly List<Tuple<ITraktShow, ITraktMetadata, DateTime>> _collectedShowsAndMetadata;

        internal TraktPostBuilderShowAddedMetadata(TPostBuilderAddShow postBuilder)
        {
            _postBuilder = postBuilder;
            _currentShow = null;
            _showsAndMetadata = new List<Tuple<ITraktShow, ITraktMetadata>>();
            _collectedShowsAndMetadata = new List<Tuple<ITraktShow, ITraktMetadata, DateTime>>();
        }

        public TPostBuilderAddShow WithMetadata(ITraktMetadata metadata)
        {
            _showsAndMetadata.Add(new Tuple<ITraktShow, ITraktMetadata>(_currentShow, metadata));
            return _postBuilder;
        }

        public TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, DateTime collectedAt)
        {
            _collectedShowsAndMetadata.Add(new Tuple<ITraktShow, ITraktMetadata, DateTime>(_currentShow, metadata, collectedAt));
            return _postBuilder;
        }

        public void SetCurrentShow(ITraktShow show)
        {
            _currentShow = show;
        }
    }
}
