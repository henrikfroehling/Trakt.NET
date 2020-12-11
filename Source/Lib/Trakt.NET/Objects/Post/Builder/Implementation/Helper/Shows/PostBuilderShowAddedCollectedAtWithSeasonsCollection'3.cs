namespace TraktNet.Objects.Post.Helper
{
    using Capabilities;
    using Get.Shows;
    using System;
    using System.Collections.Generic;

    internal class PostBuilderShowAddedCollectedAtWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
        : ITraktPostBuilderShowAddedCollectedAtWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>,
          IPostBuilderShowAddedCollectedAtWithSeasonsCollectionDetail<TSeasonCollection>
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>,
                                      ITraktPostBuilderAddShowWithCollectedAtWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
    {
        private readonly TPostBuilderAddShow _postBuilder;
        private ITraktShow _currentShow;

        internal PostBuilderShowAddedCollectedAtWithSeasonsCollection(TPostBuilderAddShow postBuilder)
        {
            _postBuilder = postBuilder;
            _currentShow = null;
            CollectedShowsWithSeasonsCollection = new List<PostBuilderCollectedObjectWithSeasons<ITraktShow, TSeasonCollection>>();
        }

        public List<PostBuilderCollectedObjectWithSeasons<ITraktShow, TSeasonCollection>> CollectedShowsWithSeasonsCollection { get; }

        public TPostBuilderAddShow CollectedAt(DateTime collectedAt, TSeasonCollection seasons)
        {
            CollectedShowsWithSeasonsCollection.Add(new PostBuilderCollectedObjectWithSeasons<ITraktShow, TSeasonCollection>
            {
                Object = _currentShow,
                CollectedAt = collectedAt,
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
