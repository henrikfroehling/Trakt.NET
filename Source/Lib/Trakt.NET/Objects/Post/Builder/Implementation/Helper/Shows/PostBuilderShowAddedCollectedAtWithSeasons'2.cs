namespace TraktNet.Objects.Post.Builder.Helper
{
    using Capabilities;
    using Get.Shows;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class PostBuilderShowAddedCollectedAtWithSeasons<TPostBuilderAddShow, TPostObject>
        : ITraktPostBuilderShowAddedCollectedAtWithSeasons<TPostBuilderAddShow, TPostObject>
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithCollectedAtWithSeasons<TPostBuilderAddShow, TPostObject>
    {
        private readonly TPostBuilderAddShow _postBuilder;
        private ITraktShow _currentShow;

        internal PostBuilderShowAddedCollectedAtWithSeasons(TPostBuilderAddShow postBuilder)
        {
            _postBuilder = postBuilder;
            _currentShow = null;
            CollectedShowsWithSeasons = new List<PostBuilderCollectedObjectWithSeasons<ITraktShow, IEnumerable<int>>>();
        }

        public List<PostBuilderCollectedObjectWithSeasons<ITraktShow, IEnumerable<int>>> CollectedShowsWithSeasons { get; }

        public TPostBuilderAddShow CollectedAt(DateTime collectedAt, int[] seasons)
        {
            CollectedShowsWithSeasons.Add(new PostBuilderCollectedObjectWithSeasons<ITraktShow, IEnumerable<int>>
            {
                Object = _currentShow,
                CollectedAt = collectedAt,
                Seasons = seasons.ToList()
            });

            return _postBuilder;
        }

        public TPostBuilderAddShow CollectedAt(DateTime collectedAt, int season, params int[] seasons)
        {
            var newSeasons = new List<int>
            {
                season
            };

            newSeasons.AddRange(seasons);

            CollectedShowsWithSeasons.Add(new PostBuilderCollectedObjectWithSeasons<ITraktShow, IEnumerable<int>>
            {
                Object = _currentShow,
                CollectedAt = collectedAt,
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
