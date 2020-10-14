namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Basic;
    using Get.Shows;
    using Interfaces;
    using Interfaces.Capabilities;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class PostBuilderShowAddedMetadataWithSeasons<TPostBuilderAddShow, TPostObject>
        : ITraktPostBuilderShowAddedMetadataWithSeasons<TPostBuilderAddShow, TPostObject>
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithMetadataWithSeasons<TPostBuilderAddShow, TPostObject>
    {
        private readonly TPostBuilderAddShow _postBuilder;
        private ITraktShow _currentShow;
        private readonly List<PostBuilderObjectWithMetadataAndSeasons<ITraktShow, IEnumerable<int>>> _showsAndMetadataWithSeasons;

        internal PostBuilderShowAddedMetadataWithSeasons(TPostBuilderAddShow postBuilder)
        {
            _postBuilder = postBuilder;
            _currentShow = null;
            _showsAndMetadataWithSeasons = new List<PostBuilderObjectWithMetadataAndSeasons<ITraktShow, IEnumerable<int>>>();
        }

        public TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, int[] seasons)
        {
            _showsAndMetadataWithSeasons.Add(new PostBuilderObjectWithMetadataAndSeasons<ITraktShow, IEnumerable<int>>
            {
                Object = _currentShow,
                Metadata = metadata,
                Seasons = seasons.ToList()
            });

            return _postBuilder;
        }

        public TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, DateTime collectedAt, int[] seasons)
        {
            _showsAndMetadataWithSeasons.Add(new PostBuilderObjectWithMetadataAndSeasons<ITraktShow, IEnumerable<int>>
            {
                Object = _currentShow,
                Metadata = metadata,
                CollectedAt = collectedAt,
                Seasons = seasons.ToList()
            });

            return _postBuilder;
        }

        public TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, int season, params int[] seasons)
        {
            var newSeasons = new List<int>
            {
                season
            };

            newSeasons.AddRange(seasons);

            _showsAndMetadataWithSeasons.Add(new PostBuilderObjectWithMetadataAndSeasons<ITraktShow, IEnumerable<int>>
            {
                Object = _currentShow,
                Metadata = metadata,
                Seasons = newSeasons
            });

            return _postBuilder;
        }

        public TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, DateTime collectedAt, int season, params int[] seasons)
        {
            var newSeasons = new List<int>
            {
                season
            };

            newSeasons.AddRange(seasons);

            _showsAndMetadataWithSeasons.Add(new PostBuilderObjectWithMetadataAndSeasons<ITraktShow, IEnumerable<int>>
            {
                Object = _currentShow,
                Metadata = metadata,
                CollectedAt = collectedAt,
                Seasons = newSeasons
            });

            return _postBuilder;
        }

        public void SetCurrentShow(ITraktShow show)
        {
            _currentShow = show;
        }
    }
}
