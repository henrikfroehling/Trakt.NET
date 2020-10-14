namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Get.Shows;
    using Interfaces;
    using Interfaces.Capabilities;
    using System;
    using System.Collections.Generic;

    internal class PostBuilderShowAddedWatchedAt<TPostBuilderAddShow, TPostObject>
        : ITraktPostBuilderShowAddedWatchedAt<TPostBuilderAddShow, TPostObject>
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithWatchedAt<TPostBuilderAddShow, TPostObject>
    {
        private readonly TPostBuilderAddShow _postBuilder;
        private ITraktShow _currentShow;
        private readonly List<PostBuilderWatchedObject<ITraktShow>> _watchedShows;

        internal PostBuilderShowAddedWatchedAt(TPostBuilderAddShow postBuilder)
        {
            _postBuilder = postBuilder;
            _currentShow = null;
            _watchedShows = new List<PostBuilderWatchedObject<ITraktShow>>();
        }

        public TPostBuilderAddShow WatchedAt(DateTime watchedAt)
        {
            _watchedShows.Add(new PostBuilderWatchedObject<ITraktShow>
            {
                Object = _currentShow,
                WatchedAt = watchedAt
            });

            return _postBuilder;
        }

        public void SetCurrentShow(ITraktShow show)
        {
            _currentShow = show;
        }
    }
}
