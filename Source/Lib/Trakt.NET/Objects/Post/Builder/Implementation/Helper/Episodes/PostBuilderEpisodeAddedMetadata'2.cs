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
        private readonly List<PostBuilderObjectWithMetadata<ITraktEpisode>> _episodesAndMetadata;

        internal PostBuilderEpisodeAddedMetadata(TPostBuilderAddEpisode postBuilder)
        {
            _postBuilder = postBuilder;
            _currentEpisode = null;
            _episodesAndMetadata = new List<PostBuilderObjectWithMetadata<ITraktEpisode>>();
        }

        public TPostBuilderAddEpisode WithMetadata(ITraktMetadata metadata)
        {
            _episodesAndMetadata.Add(new PostBuilderObjectWithMetadata<ITraktEpisode>
            {
                Object = _currentEpisode,
                Metadata = metadata
            });

            return _postBuilder;
        }

        public TPostBuilderAddEpisode WithMetadata(ITraktMetadata metadata, DateTime collectedAt)
        {
            _episodesAndMetadata.Add(new PostBuilderObjectWithMetadata<ITraktEpisode>
            {
                Object = _currentEpisode,
                Metadata = metadata,
                CollectedAt = collectedAt
            });

            return _postBuilder;
        }

        public void SetCurrentEpisode(ITraktEpisode episode)
        {
            _currentEpisode = episode;
        }
    }
}
