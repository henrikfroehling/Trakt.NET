namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Get.Shows;
    using Interfaces;
    using Interfaces.Capabilities;
    using System;
    using System.Collections.Generic;

    internal class PostBuilderShowAddedWatchedAtWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
        : ITraktPostBuilderShowAddedWatchedAtWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>,
                                      ITraktPostBuilderAddShowWithWatchedAtWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
    {
        private readonly TPostBuilderAddShow _postBuilder;
        private ITraktShow _currentShow;
        private readonly List<Tuple<ITraktShow, DateTime, TSeasonCollection>> _watchedShowsWithSeasonsCollection;

        internal PostBuilderShowAddedWatchedAtWithSeasonsCollection(TPostBuilderAddShow postBuilder)
        {
            _postBuilder = postBuilder;
            _currentShow = null;
            _watchedShowsWithSeasonsCollection = new List<Tuple<ITraktShow, DateTime, TSeasonCollection>>();
        }

        public TPostBuilderAddShow WatchedAt(DateTime watchedAt, TSeasonCollection seasons)
        {
            _watchedShowsWithSeasonsCollection.Add(new Tuple<ITraktShow, DateTime, TSeasonCollection>(_currentShow, watchedAt, seasons));
            return _postBuilder;
        }

        public void SetCurrentShow(ITraktShow show)
        {
            _currentShow = show;
        }
    }
}
