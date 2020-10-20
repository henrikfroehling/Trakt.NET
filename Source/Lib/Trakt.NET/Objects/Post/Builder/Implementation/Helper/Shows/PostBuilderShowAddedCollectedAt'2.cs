namespace TraktNet.Objects.Post.Builder.Helper
{
    using Capabilities;
    using Get.Shows;
    using System;
    using System.Collections.Generic;

    internal class PostBuilderShowAddedCollectedAt<TPostBuilderAddShow, TPostObject>
        : ITraktPostBuilderShowAddedCollectedAt<TPostBuilderAddShow, TPostObject>
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithCollectedAt<TPostBuilderAddShow, TPostObject>
    {
        private readonly TPostBuilderAddShow _postBuilder;
        private ITraktShow _currentShow;

        internal PostBuilderShowAddedCollectedAt(TPostBuilderAddShow postBuilder)
        {
            _postBuilder = postBuilder;
            _currentShow = null;
            CollectedShows = new List<PostBuilderCollectedObject<ITraktShow>>();
        }

        public List<PostBuilderCollectedObject<ITraktShow>> CollectedShows { get; }

        public TPostBuilderAddShow CollectedAt(DateTime collectedAt)
        {
            CollectedShows.Add(new PostBuilderCollectedObject<ITraktShow>
            {
                Object = _currentShow,
                CollectedAt = collectedAt
            });

            return _postBuilder;
        }

        public void SetCurrentShow(ITraktShow show)
        {
            _currentShow = show;
        }
    }
}
