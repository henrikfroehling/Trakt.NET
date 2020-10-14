namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Get.Shows;
    using Interfaces;
    using Interfaces.Capabilities;
    using System;
    using System.Collections.Generic;

    internal class PostBuilderShowAddedCollectedAtWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
        : ITraktPostBuilderShowAddedCollectedAtWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>,
                                      ITraktPostBuilderAddShowWithCollectedAtWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
    {
        private readonly TPostBuilderAddShow _postBuilder;
        private ITraktShow _currentShow;
        private readonly List<Tuple<ITraktShow, DateTime, TSeasonCollection>> _collectedShowsWithSeasonsCollection;

        internal PostBuilderShowAddedCollectedAtWithSeasonsCollection(TPostBuilderAddShow postBuilder)
        {
            _postBuilder = postBuilder;
            _currentShow = null;
            _collectedShowsWithSeasonsCollection = new List<Tuple<ITraktShow, DateTime, TSeasonCollection>>();
        }

        public TPostBuilderAddShow CollectedAt(DateTime collectedAt, TSeasonCollection seasons)
        {
            _collectedShowsWithSeasonsCollection.Add(new Tuple<ITraktShow, DateTime, TSeasonCollection>(_currentShow, collectedAt, seasons));
            return _postBuilder;
        }

        public void SetCurrentShow(ITraktShow show)
        {
            _currentShow = show;
        }
    }
}
