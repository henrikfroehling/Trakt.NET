namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Get.Episodes;
    using Interfaces;
    using Interfaces.Capabilities;
    using System;
    using System.Collections.Generic;

    internal class PostBuilderEpisodeAddedWatchedAt<TPostBuilderAddEpisode, TPostObject>
        : ITraktPostBuilderEpisodeAddedWatchedAt<TPostBuilderAddEpisode, TPostObject>
          where TPostBuilderAddEpisode : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddEpisodeWithWatchedAt<TPostBuilderAddEpisode, TPostObject>
    {
        private readonly TPostBuilderAddEpisode _postBuilder;
        private ITraktEpisode _currentEpisode;
        private readonly List<PostBuilderWatchedObject<ITraktEpisode>> _watchedEpisodes;

        internal PostBuilderEpisodeAddedWatchedAt(TPostBuilderAddEpisode postBuilder)
        {
            _postBuilder = postBuilder;
            _currentEpisode = null;
            _watchedEpisodes = new List<PostBuilderWatchedObject<ITraktEpisode>>();
        }

        public TPostBuilderAddEpisode WatchedAt(DateTime watchedAt)
        {
            _watchedEpisodes.Add(new PostBuilderWatchedObject<ITraktEpisode>
            {
                Object = _currentEpisode,
                WatchedAt = watchedAt
            });

            return _postBuilder;
        }

        public void SetCurrentEpisode(ITraktEpisode episode)
        {
            _currentEpisode = episode;
        }
    }
}
