namespace TraktNet.Objects.Post.Builder.Helper
{
    using Capabilities;
    using Get.Episodes;
    using System;
    using System.Collections.Generic;

    internal class PostBuilderEpisodeAddedCollectedAt<TPostBuilderAddEpisode, TPostObject>
        : ITraktPostBuilderEpisodeAddedCollectedAt<TPostBuilderAddEpisode, TPostObject>
          where TPostBuilderAddEpisode : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddEpisodeWithCollectedAt<TPostBuilderAddEpisode, TPostObject>
    {
        private readonly TPostBuilderAddEpisode _postBuilder;
        private ITraktEpisode _currentEpisode;

        internal PostBuilderEpisodeAddedCollectedAt(TPostBuilderAddEpisode postBuilder)
        {
            _postBuilder = postBuilder;
            _currentEpisode = null;
            CollectedEpisodes = new List<PostBuilderCollectedObject<ITraktEpisode>>();
        }

        public List<PostBuilderCollectedObject<ITraktEpisode>> CollectedEpisodes { get; }

        public TPostBuilderAddEpisode CollectedAt(DateTime collectedAt)
        {
            CollectedEpisodes.Add(new PostBuilderCollectedObject<ITraktEpisode>
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
