namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Get.Shows;
    using Interfaces;
    using Interfaces.Capabilities;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class TraktPostBuilderShowAddedCollectedAtWithSeasons<TPostBuilderAddShow, TPostObject>
        : ITraktPostBuilderShowAddedCollectedAtWithSeasons<TPostBuilderAddShow, TPostObject>
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithCollectedAtWithSeasons<TPostBuilderAddShow, TPostObject>
    {
        private readonly TPostBuilderAddShow _postBuilder;
        private ITraktShow _currentShow;
        private readonly List<Tuple<ITraktShow, DateTime, List<int>>> _collectedShowsWithSeasons;

        internal TraktPostBuilderShowAddedCollectedAtWithSeasons(TPostBuilderAddShow postBuilder)
        {
            _postBuilder = postBuilder;
            _currentShow = null;
            _collectedShowsWithSeasons = new List<Tuple<ITraktShow, DateTime, List<int>>>();
        }

        public TPostBuilderAddShow CollectedAt(DateTime collectedAt, int[] seasons)
        {
            _collectedShowsWithSeasons.Add(new Tuple<ITraktShow, DateTime, List<int>>(_currentShow, collectedAt, seasons.ToList()));
            return _postBuilder;
        }

        public TPostBuilderAddShow CollectedAt(DateTime collectedAt, int season, params int[] seasons)
        {
            var newSeasons = new List<int>
            {
                season
            };

            newSeasons.AddRange(seasons);
            _collectedShowsWithSeasons.Add(new Tuple<ITraktShow, DateTime, List<int>>(_currentShow, collectedAt, newSeasons));
            return _postBuilder;
        }

        public void SetCurrentShow(ITraktShow show)
        {
            _currentShow = show;
        }
    }
}
