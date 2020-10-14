namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Get.Episodes;
    using Interfaces;
    using Interfaces.Capabilities;
    using System;
    using System.Collections.Generic;

    internal class PostBuilderEpisodeAddedCollectedAt<TPostBuilderAddEpisode, TPostObject>
        : ITraktPostBuilderEpisodeAddedCollectedAt<TPostBuilderAddEpisode, TPostObject>
          where TPostBuilderAddEpisode : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddEpisodeWithCollectedAt<TPostBuilderAddEpisode, TPostObject>
    {
        private readonly TPostBuilderAddEpisode _postBuilder;
        private ITraktEpisode _currentEpisode;
        private readonly List<PostBuilderCollectedObject<ITraktEpisode>> _collectedEpisodes;

        internal PostBuilderEpisodeAddedCollectedAt(TPostBuilderAddEpisode postBuilder)
        {
            _postBuilder = postBuilder;
            _currentEpisode = null;
            _collectedEpisodes = new List<PostBuilderCollectedObject<ITraktEpisode>>();
        }

        public TPostBuilderAddEpisode CollectedAt(DateTime collectedAt)
        {
            _collectedEpisodes.Add(new PostBuilderCollectedObject<ITraktEpisode>
            {
                Object = _currentEpisode,
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
