namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Get.Shows;
    using Interfaces;
    using Interfaces.Capabilities;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class PostBuilderShowAddedCollectedAtWithSeasons<TPostBuilderAddShow, TPostObject>
        : ITraktPostBuilderShowAddedCollectedAtWithSeasons<TPostBuilderAddShow, TPostObject>
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithCollectedAtWithSeasons<TPostBuilderAddShow, TPostObject>
    {
        private readonly TPostBuilderAddShow _postBuilder;
        private ITraktShow _currentShow;
        private readonly List<PostBuilderCollectedObjectWithSeasons<ITraktShow, IEnumerable<int>>> _collectedShowsWithSeasons;

        internal PostBuilderShowAddedCollectedAtWithSeasons(TPostBuilderAddShow postBuilder)
        {
            _postBuilder = postBuilder;
            _currentShow = null;
            _collectedShowsWithSeasons = new List<PostBuilderCollectedObjectWithSeasons<ITraktShow, IEnumerable<int>>>();
        }

        public TPostBuilderAddShow CollectedAt(DateTime collectedAt, int[] seasons)
        {
            _collectedShowsWithSeasons.Add(new PostBuilderCollectedObjectWithSeasons<ITraktShow, IEnumerable<int>>
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

            _collectedShowsWithSeasons.Add(new PostBuilderCollectedObjectWithSeasons<ITraktShow, IEnumerable<int>>
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
