namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Get.Shows;
    using Interfaces;
    using Interfaces.Capabilities;
    using System.Collections.Generic;

    internal class PostBuilderShowAddedSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
        : ITraktPostBuilderShowAddedSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>,
                                      ITraktPostBuilderAddShowWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
    {
        private readonly TPostBuilderAddShow _postBuilder;
        private ITraktShow _currentShow;
        private readonly List<PostBuilderObjectWithSeasons<ITraktShow, TSeasonCollection>> _showsWithSeasonsCollection;

        internal PostBuilderShowAddedSeasonsCollection(TPostBuilderAddShow postBuilder)
        {
            _postBuilder = postBuilder;
            _currentShow = null;
            _showsWithSeasonsCollection = new List<PostBuilderObjectWithSeasons<ITraktShow, TSeasonCollection>>();
        }

        public TPostBuilderAddShow WithSeasons(TSeasonCollection seasons)
        {
            _showsWithSeasonsCollection.Add(new PostBuilderObjectWithSeasons<ITraktShow, TSeasonCollection>
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
