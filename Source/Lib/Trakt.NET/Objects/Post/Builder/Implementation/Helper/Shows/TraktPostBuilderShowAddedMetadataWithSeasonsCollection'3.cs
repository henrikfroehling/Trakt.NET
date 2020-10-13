namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Basic;
    using Get.Shows;
    using Interfaces;
    using Interfaces.Capabilities;
    using System;
    using System.Collections.Generic;

    internal class TraktPostBuilderShowAddedMetadataWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
        : ITraktPostBuilderShowAddedMetadataWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>,
                                      ITraktPostBuilderAddShowWithMetadataWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
    {
        private readonly TPostBuilderAddShow _postBuilder;
        private ITraktShow _currentShow;
        private readonly List<Tuple<ITraktShow, ITraktMetadata, TSeasonCollection>> _showsAndMetadataWithSeasonsCollection;
        private readonly List<Tuple<ITraktShow, ITraktMetadata, DateTime, TSeasonCollection>> _collectedShowsAndMetadataWithSeasonsCollection;

        internal TraktPostBuilderShowAddedMetadataWithSeasonsCollection(TPostBuilderAddShow postBuilder)
        {
            _postBuilder = postBuilder;
            _currentShow = null;
            _showsAndMetadataWithSeasonsCollection = new List<Tuple<ITraktShow, ITraktMetadata, TSeasonCollection>>();
            _collectedShowsAndMetadataWithSeasonsCollection = new List<Tuple<ITraktShow, ITraktMetadata, DateTime, TSeasonCollection>>();
        }

        public TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, TSeasonCollection seasons)
        {
            _showsAndMetadataWithSeasonsCollection.Add(new Tuple<ITraktShow, ITraktMetadata, TSeasonCollection>(_currentShow, metadata, seasons));
            return _postBuilder;
        }

        public TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, DateTime collectedAt, TSeasonCollection seasons)
        {
            _collectedShowsAndMetadataWithSeasonsCollection.Add(new Tuple<ITraktShow, ITraktMetadata, DateTime, TSeasonCollection>(_currentShow, metadata, collectedAt, seasons));
            return _postBuilder;
        }

        public void SetCurrentShow(ITraktShow show)
        {
            _currentShow = show;
        }
    }
}
