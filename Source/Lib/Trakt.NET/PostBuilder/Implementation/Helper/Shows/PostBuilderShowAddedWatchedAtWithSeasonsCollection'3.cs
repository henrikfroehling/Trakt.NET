namespace TraktNet.PostBuilder
{
    using System;
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Shows;

    internal class PostBuilderShowAddedWatchedAtWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
        : ITraktPostBuilderShowAddedWatchedAtWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>,
          IPostBuilderShowAddedWatchedAtWithSeasonsCollectionDetail<TSeasonCollection>
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>,
                                      ITraktPostBuilderShowWithWatchedAtWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
    {
        private readonly TPostBuilderAddShow _postBuilder;
        private ITraktShow _currentShow;

        internal PostBuilderShowAddedWatchedAtWithSeasonsCollection(TPostBuilderAddShow postBuilder)
        {
            _postBuilder = postBuilder;
            _currentShow = null;
            WatchedShowsWithSeasonsCollection = new List<PostBuilderWatchedObjectWithSeasons<ITraktShow, TSeasonCollection>>();
        }

        public List<PostBuilderWatchedObjectWithSeasons<ITraktShow, TSeasonCollection>> WatchedShowsWithSeasonsCollection { get; }

        public TPostBuilderAddShow WatchedAt(DateTime watchedAt, TSeasonCollection seasons)
        {
            WatchedShowsWithSeasonsCollection.Add(new PostBuilderWatchedObjectWithSeasons<ITraktShow, TSeasonCollection>
            {
                Object = _currentShow,
                WatchedAt = watchedAt,
                Seasons = seasons
            });

            return _postBuilder;
        }

        public void SetCurrentShow(ITraktShow show)
        {
            _currentShow = show;
        }
    }
}
