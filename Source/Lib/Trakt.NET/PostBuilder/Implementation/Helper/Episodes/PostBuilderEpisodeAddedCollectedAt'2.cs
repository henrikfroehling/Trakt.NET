namespace TraktNet.PostBuilder
{
    using System;
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Episodes;

    internal class PostBuilderEpisodeAddedCollectedAt<TPostBuilderAddEpisode, TPostObject>
        : ITraktPostBuilderEpisodeAddedCollectedAt<TPostBuilderAddEpisode, TPostObject>,
          IPostBuilderEpisodeAddedCollectedAtDetail
          where TPostBuilderAddEpisode : ITraktPostBuilder<TPostObject>, ITraktPostBuilderEpisodeWithCollectedAt<TPostBuilderAddEpisode, TPostObject>
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
