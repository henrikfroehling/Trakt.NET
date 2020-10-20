namespace TraktNet.Objects.Post.Builder.Helper
{
    using Basic;
    using Capabilities;
    using Get.Shows;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class PostBuilderShowAddedMetadataWithSeasons<TPostBuilderAddShow, TPostObject>
        : ITraktPostBuilderShowAddedMetadataWithSeasons<TPostBuilderAddShow, TPostObject>
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithMetadataWithSeasons<TPostBuilderAddShow, TPostObject>
    {
        private readonly TPostBuilderAddShow _postBuilder;
        private ITraktShow _currentShow;

        internal PostBuilderShowAddedMetadataWithSeasons(TPostBuilderAddShow postBuilder)
        {
            _postBuilder = postBuilder;
            _currentShow = null;
            ShowsAndMetadataWithSeasons = new List<PostBuilderObjectWithMetadataAndSeasons<ITraktShow, IEnumerable<int>>>();
        }

        public List<PostBuilderObjectWithMetadataAndSeasons<ITraktShow, IEnumerable<int>>> ShowsAndMetadataWithSeasons { get; }

        public TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, int[] seasons)
        {
            ShowsAndMetadataWithSeasons.Add(new PostBuilderObjectWithMetadataAndSeasons<ITraktShow, IEnumerable<int>>
            {
                Object = _currentShow,
                Metadata = metadata,
                Seasons = seasons.ToList()
            });

            return _postBuilder;
        }

        public TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, DateTime collectedAt, int[] seasons)
        {
            ShowsAndMetadataWithSeasons.Add(new PostBuilderObjectWithMetadataAndSeasons<ITraktShow, IEnumerable<int>>
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

            ShowsAndMetadataWithSeasons.Add(new PostBuilderObjectWithMetadataAndSeasons<ITraktShow, IEnumerable<int>>
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

            ShowsAndMetadataWithSeasons.Add(new PostBuilderObjectWithMetadataAndSeasons<ITraktShow, IEnumerable<int>>
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
