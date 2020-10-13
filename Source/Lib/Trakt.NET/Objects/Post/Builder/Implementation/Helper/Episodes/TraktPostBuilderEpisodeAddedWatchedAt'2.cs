namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Get.Episodes;
    using Interfaces;
    using Interfaces.Capabilities;
    using System;
    using System.Collections.Generic;

    internal class TraktPostBuilderEpisodeAddedWatchedAt<TPostBuilderAddEpisode, TPostObject>
        : ITraktPostBuilderEpisodeAddedWatchedAt<TPostBuilderAddEpisode, TPostObject>
          where TPostBuilderAddEpisode : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddEpisodeWithWatchedAt<TPostBuilderAddEpisode, TPostObject>
    {
        private readonly TPostBuilderAddEpisode _postBuilder;
        private ITraktEpisode _currentEpisode;
        private readonly List<Tuple<ITraktEpisode, DateTime>> _watchedEpisodes;

        internal TraktPostBuilderEpisodeAddedWatchedAt(TPostBuilderAddEpisode postBuilder)
        {
            _postBuilder = postBuilder;
            _currentEpisode = null;
            _watchedEpisodes = new List<Tuple<ITraktEpisode, DateTime>>();
        }

        public TPostBuilderAddEpisode WatchedAt(DateTime watchedAt)
        {
            _watchedEpisodes.Add(new Tuple<ITraktEpisode, DateTime>(_currentEpisode, watchedAt));
            return _postBuilder;
        }

        public void SetCurrentEpisode(ITraktEpisode episode)
        {
            _currentEpisode = episode;
        }
    }
}
