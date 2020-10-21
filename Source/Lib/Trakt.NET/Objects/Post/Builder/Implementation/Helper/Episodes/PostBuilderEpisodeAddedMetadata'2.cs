namespace TraktNet.Objects.Post.Builder.Helper
{
    using Basic;
    using Capabilities;
    using Get.Episodes;
    using System;
    using System.Collections.Generic;

    internal class PostBuilderEpisodeAddedMetadata<TPostBuilderAddEpisode, TPostObject>
        : ITraktPostBuilderEpisodeAddedMetadata<TPostBuilderAddEpisode, TPostObject>,
          IPostBuilderEpisodeAddedMetadataDetail
          where TPostBuilderAddEpisode : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddEpisodeWithMetadata<TPostBuilderAddEpisode, TPostObject>
    {
        private readonly TPostBuilderAddEpisode _postBuilder;
        private ITraktEpisode _currentEpisode;

        internal PostBuilderEpisodeAddedMetadata(TPostBuilderAddEpisode postBuilder)
        {
            _postBuilder = postBuilder;
            _currentEpisode = null;
            EpisodesAndMetadata = new List<PostBuilderObjectWithMetadata<ITraktEpisode>>();
        }

        public List<PostBuilderObjectWithMetadata<ITraktEpisode>> EpisodesAndMetadata { get; }

        public TPostBuilderAddEpisode WithMetadata(ITraktMetadata metadata)
        {
            EpisodesAndMetadata.Add(new PostBuilderObjectWithMetadata<ITraktEpisode>
            {
                Object = _currentEpisode,
                Metadata = metadata
            });

            return _postBuilder;
        }

        public TPostBuilderAddEpisode WithMetadata(ITraktMetadata metadata, DateTime collectedAt)
        {
            EpisodesAndMetadata.Add(new PostBuilderObjectWithMetadata<ITraktEpisode>
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
