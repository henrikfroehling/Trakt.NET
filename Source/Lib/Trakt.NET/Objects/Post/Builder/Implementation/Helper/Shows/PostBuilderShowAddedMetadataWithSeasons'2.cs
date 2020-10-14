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
        private readonly List<Tuple<ITraktShow, ITraktMetadata, List<int>>> _showsAndMetadataWithSeasons;
        private readonly List<Tuple<ITraktShow, ITraktMetadata, DateTime, List<int>>> _collectedShowsAndMetadataWithSeasons;

        internal PostBuilderShowAddedMetadataWithSeasons(TPostBuilderAddShow postBuilder)
        {
            _postBuilder = postBuilder;
            _currentShow = null;
            _showsAndMetadataWithSeasons = new List<Tuple<ITraktShow, ITraktMetadata, List<int>>>();
            _collectedShowsAndMetadataWithSeasons = new List<Tuple<ITraktShow, ITraktMetadata, DateTime, List<int>>>();
        }

        public TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, int[] seasons)
        {
            _showsAndMetadataWithSeasons.Add(new Tuple<ITraktShow, ITraktMetadata, List<int>>(_currentShow, metadata, seasons.ToList()));
            return _postBuilder;
        }

        public TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, DateTime collectedAt, int[] seasons)
        {
            _collectedShowsAndMetadataWithSeasons.Add(new Tuple<ITraktShow, ITraktMetadata, DateTime, List<int>>(_currentShow, metadata, collectedAt, seasons.ToList()));
            return _postBuilder;
        }

        public TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, int season, params int[] seasons)
        {
            var newSeasons = new List<int>
            {
                season
            };

            newSeasons.AddRange(seasons);
            _showsAndMetadataWithSeasons.Add(new Tuple<ITraktShow, ITraktMetadata, List<int>>(_currentShow, metadata, newSeasons));
            return _postBuilder;
        }

        public TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, DateTime collectedAt, int season, params int[] seasons)
        {
            var newSeasons = new List<int>
            {
                season
            };

            newSeasons.AddRange(seasons);
            _collectedShowsAndMetadataWithSeasons.Add(new Tuple<ITraktShow, ITraktMetadata, DateTime, List<int>>(_currentShow, metadata, collectedAt, newSeasons));
            return _postBuilder;
        }

        public void SetCurrentShow(ITraktShow show)
        {
            _currentShow = show;
        }
    }
}
