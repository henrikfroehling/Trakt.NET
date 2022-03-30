namespace TraktNet.Objects.Post.Helper
{
    using Basic;
    using Capabilities;
    using Get.Shows;
    using System;
    using System.Collections.Generic;

    internal class PostBuilderShowAddedMetadataWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
        : ITraktPostBuilderShowAddedMetadataWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>,
          IPostBuilderShowAddedMetadataWithSeasonsCollectionDetail<TSeasonCollection>
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>,
                                      ITraktPostBuilderShowWithMetadataWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
    {
        private readonly TPostBuilderAddShow _postBuilder;
        private ITraktShow _currentShow;

        internal PostBuilderShowAddedMetadataWithSeasonsCollection(TPostBuilderAddShow postBuilder)
        {
            _postBuilder = postBuilder;
            _currentShow = null;
            ShowsAndMetadataWithSeasonsCollection = new List<PostBuilderObjectWithMetadataAndSeasons<ITraktShow, TSeasonCollection>>();
        }

        public List<PostBuilderObjectWithMetadataAndSeasons<ITraktShow, TSeasonCollection>> ShowsAndMetadataWithSeasonsCollection { get; }

        public TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, TSeasonCollection seasons)
        {
            ShowsAndMetadataWithSeasonsCollection.Add(new PostBuilderObjectWithMetadataAndSeasons<ITraktShow, TSeasonCollection>
            {
                Object = _currentShow,
                Metadata = metadata,
                Seasons = seasons
            });

            return _postBuilder;
        }

        public TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, DateTime collectedAt, TSeasonCollection seasons)
        {
            ShowsAndMetadataWithSeasonsCollection.Add(new PostBuilderObjectWithMetadataAndSeasons<ITraktShow, TSeasonCollection>
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
