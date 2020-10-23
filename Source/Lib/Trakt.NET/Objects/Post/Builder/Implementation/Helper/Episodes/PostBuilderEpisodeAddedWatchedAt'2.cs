namespace TraktNet.Objects.Post.Builder.Helper
{
    using Capabilities;
    using Get.Episodes;
    using System;
    using System.Collections.Generic;

    internal class PostBuilderEpisodeAddedWatchedAt<TPostBuilderAddEpisode, TPostObject>
        : ITraktPostBuilderEpisodeAddedWatchedAt<TPostBuilderAddEpisode, TPostObject>,
          IPostBuilderEpisodeAddedWatchedAtDetail
          where TPostBuilderAddEpisode : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddEpisodeWithWatchedAt<TPostBuilderAddEpisode, TPostObject>
    {
        private readonly TPostBuilderAddEpisode _postBuilder;
        private ITraktEpisode _currentEpisode;

        internal PostBuilderEpisodeAddedWatchedAt(TPostBuilderAddEpisode postBuilder)
        {
            _postBuilder = postBuilder;
            _currentEpisode = null;
            WatchedEpisodes = new List<PostBuilderWatchedObject<ITraktEpisode>>();
        }

        public List<PostBuilderWatchedObject<ITraktEpisode>> WatchedEpisodes { get; }

        public TPostBuilderAddEpisode WatchedAt(DateTime watchedAt)
        {
            WatchedEpisodes.Add(new PostBuilderWatchedObject<ITraktEpisode>
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
