namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Basic;
    using Get.Shows;
    using Interfaces;
    using Interfaces.Capabilities;
    using System;
    using System.Collections.Generic;

    internal class PostBuilderShowAddedMetadataWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
        : ITraktPostBuilderShowAddedMetadataWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>,
                                      ITraktPostBuilderAddShowWithMetadataWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
    {
        private readonly TPostBuilderAddShow _postBuilder;
        private ITraktShow _currentShow;
        private readonly List<PostBuilderObjectWithMetadataAndSeasons<ITraktShow, TSeasonCollection>> _showsAndMetadataWithSeasonsCollection;

        internal PostBuilderShowAddedMetadataWithSeasonsCollection(TPostBuilderAddShow postBuilder)
        {
            _postBuilder = postBuilder;
            _currentShow = null;
            _showsAndMetadataWithSeasonsCollection = new List<PostBuilderObjectWithMetadataAndSeasons<ITraktShow, TSeasonCollection>>();
        }

        public TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, TSeasonCollection seasons)
        {
            _showsAndMetadataWithSeasonsCollection.Add(new PostBuilderObjectWithMetadataAndSeasons<ITraktShow, TSeasonCollection>
            {
                Object = _currentShow,
                Metadata = metadata,
                Seasons = seasons
            });

            return _postBuilder;
        }

        public TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, DateTime collectedAt, TSeasonCollection seasons)
        {
            _showsAndMetadataWithSeasonsCollection.Add(new PostBuilderObjectWithMetadataAndSeasons<ITraktShow, TSeasonCollection>
            {
                Object = _currentShow,
                Metadata = metadata,
                CollectedAt = collectedAt,
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
