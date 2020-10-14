namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Basic;
    using Get.Episodes;
    using Interfaces;
    using Interfaces.Capabilities;
    using System;
    using System.Collections.Generic;

    internal class PostBuilderEpisodeAddedMetadata<TPostBuilderAddEpisode, TPostObject>
        : ITraktPostBuilderEpisodeAddedMetadata<TPostBuilderAddEpisode, TPostObject>
          where TPostBuilderAddEpisode : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddEpisodeWithMetadata<TPostBuilderAddEpisode, TPostObject>
    {
        private readonly TPostBuilderAddEpisode _postBuilder;
        private ITraktEpisode _currentEpisode;
        private readonly List<Tuple<ITraktEpisode, ITraktMetadata>> _episodesAndMetadata;
        private readonly List<Tuple<ITraktEpisode, ITraktMetadata, DateTime>> _collectedEpisodesAndMetadata;

        internal PostBuilderEpisodeAddedMetadata(TPostBuilderAddEpisode postBuilder)
        {
            _postBuilder = postBuilder;
            _currentEpisode = null;
            _episodesAndMetadata = new List<Tuple<ITraktEpisode, ITraktMetadata>>();
            _collectedEpisodesAndMetadata = new List<Tuple<ITraktEpisode, ITraktMetadata, DateTime>>();
        }

        public TPostBuilderAddEpisode WithMetadata(ITraktMetadata metadata)
        {
            _episodesAndMetadata.Add(new Tuple<ITraktEpisode, ITraktMetadata>(_currentEpisode, metadata));
            return _postBuilder;
        }

        public TPostBuilderAddEpisode WithMetadata(ITraktMetadata metadata, DateTime collectedAt)
        {
            _collectedEpisodesAndMetadata.Add(new Tuple<ITraktEpisode, ITraktMetadata, DateTime>(_currentEpisode, metadata, collectedAt));
            return _postBuilder;
        }

        public void SetCurrentEpisode(ITraktEpisode episode)
        {
            _currentEpisode = episode;
        }
    }
}
