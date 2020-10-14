namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Get.Shows;
    using Interfaces;
    using Interfaces.Capabilities;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class PostBuilderShowAddedWatchedAtWithSeasons<TPostBuilderAddShow, TPostObject>
        : ITraktPostBuilderShowAddedWatchedAtWithSeasons<TPostBuilderAddShow, TPostObject>
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithWatchedAtWithSeasons<TPostBuilderAddShow, TPostObject>
    {
        private readonly TPostBuilderAddShow _postBuilder;
        private ITraktShow _currentShow;
        private readonly List<Tuple<ITraktShow, DateTime, List<int>>> _watchedShowsWithSeasons;

        internal PostBuilderShowAddedWatchedAtWithSeasons(TPostBuilderAddShow postBuilder)
        {
            _postBuilder = postBuilder;
            _currentShow = null;
            _watchedShowsWithSeasons = new List<Tuple<ITraktShow, DateTime, List<int>>>();
        }

        public TPostBuilderAddShow WatchedAt(DateTime watchedAt, int[] seasons)
        {
            _watchedShowsWithSeasons.Add(new Tuple<ITraktShow, DateTime, List<int>>(_currentShow, watchedAt, seasons.ToList()));
            return _postBuilder;
        }

        public TPostBuilderAddShow WatchedAt(DateTime watchedAt, int season, params int[] seasons)
        {
            var newSeasons = new List<int>
            {
                season
            };

            newSeasons.AddRange(seasons);
            _watchedShowsWithSeasons.Add(new Tuple<ITraktShow, DateTime, List<int>>(_currentShow, watchedAt, newSeasons));
            return _postBuilder;
        }

        public void SetCurrentShow(ITraktShow show)
        {
            _currentShow = show;
        }
    }
}
