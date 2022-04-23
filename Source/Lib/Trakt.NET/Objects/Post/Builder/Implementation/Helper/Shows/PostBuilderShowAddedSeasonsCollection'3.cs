namespace TraktNet.Objects.Post.Helper
{
    using Capabilities;
    using Get.Shows;
    using System.Collections.Generic;

    internal class PostBuilderShowAddedSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
        : ITraktPostBuilderShowAddedSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>,
          IPostBuilderShowAddedSeasonsCollectionDetail<TSeasonCollection>
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>,
                                      ITraktPostBuilderShowWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
    {
        private readonly TPostBuilderAddShow _postBuilder;
        private ITraktShow _currentShow;

        internal PostBuilderShowAddedSeasonsCollection(TPostBuilderAddShow postBuilder)
        {
            _postBuilder = postBuilder;
            _currentShow = null;
            ShowsWithSeasonsCollection = new List<PostBuilderObjectWithSeasons<ITraktShow, TSeasonCollection>>();
        }

        public List<PostBuilderObjectWithSeasons<ITraktShow, TSeasonCollection>> ShowsWithSeasonsCollection { get; }

        public TPostBuilderAddShow WithSeasons(TSeasonCollection seasons)
        {
            ShowsWithSeasonsCollection.Add(new PostBuilderObjectWithSeasons<ITraktShow, TSeasonCollection>
            {
                Object = _currentShow,
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
