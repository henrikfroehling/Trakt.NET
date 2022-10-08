namespace TraktNet.PostBuilder
{
    using System;
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Shows;

    internal class PostBuilderShowAddedWatchedAt<TPostBuilderAddShow, TPostObject>
        : ITraktPostBuilderShowAddedWatchedAt<TPostBuilderAddShow, TPostObject>,
          IPostBuilderShowAddedWatchedAtDetail
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderShowWithWatchedAt<TPostBuilderAddShow, TPostObject>
    {
        private readonly TPostBuilderAddShow _postBuilder;
        private ITraktShow _currentShow;

        internal PostBuilderShowAddedWatchedAt(TPostBuilderAddShow postBuilder)
        {
            _postBuilder = postBuilder;
            _currentShow = null;
            WatchedShows = new List<PostBuilderWatchedObject<ITraktShow>>();
        }

        public List<PostBuilderWatchedObject<ITraktShow>> WatchedShows { get; }

        public TPostBuilderAddShow WatchedAt(DateTime watchedAt)
        {
            WatchedShows.Add(new PostBuilderWatchedObject<ITraktShow>
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
