namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Get.Shows;
    using Interfaces;
    using Interfaces.Capabilities;
    using System.Collections.Generic;
    using System.Linq;

    internal class PostBuilderShowAddedSeasons<TPostBuilderAddShow, TPostObject>
        : ITraktPostBuilderShowAddedSeasons<TPostBuilderAddShow, TPostObject>
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithSeasons<TPostBuilderAddShow, TPostObject>
    {
        private readonly TPostBuilderAddShow _postBuilder;
        private ITraktShow _currentShow;
        private readonly List<PostBuilderObjectWithSeasons<ITraktShow, IEnumerable<int>>> _showsWithSeasons;

        internal PostBuilderShowAddedSeasons(TPostBuilderAddShow postBuilder)
        {
            _postBuilder = postBuilder;
            _currentShow = null;
            _showsWithSeasons = new List<PostBuilderObjectWithSeasons<ITraktShow, IEnumerable<int>>>();
        }
        
        public TPostBuilderAddShow WithSeasons(int[] seasons)
        {
            _showsWithSeasons.Add(new PostBuilderObjectWithSeasons<ITraktShow, IEnumerable<int>>
            {
                Object = _currentShow,
                Seasons = seasons.ToList()
            });

            return _postBuilder;
        }

        public TPostBuilderAddShow WithSeasons(int season, params int[] seasons)
        {
            var newSeasons = new List<int>
            {
                season
            };

            newSeasons.AddRange(seasons);

            _showsWithSeasons.Add(new PostBuilderObjectWithSeasons<ITraktShow, IEnumerable<int>>
            {
                Object = _currentShow,
                Seasons = newSeasons
            });

            return _postBuilder;
        }

        public void SetCurrentShow(ITraktShow show)
        {
            _currentShow = show;
        }
    }
}
