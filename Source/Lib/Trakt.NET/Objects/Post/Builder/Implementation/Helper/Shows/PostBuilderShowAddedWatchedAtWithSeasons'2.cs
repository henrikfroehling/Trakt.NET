namespace TraktNet.Objects.Post.Helper
{
    using Capabilities;
    using Get.Shows;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class PostBuilderShowAddedWatchedAtWithSeasons<TPostBuilderAddShow, TPostObject>
        : ITraktPostBuilderShowAddedWatchedAtWithSeasons<TPostBuilderAddShow, TPostObject>,
          IPostBuilderShowAddedWatchedAtWithSeasonsDetail
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithWatchedAtWithSeasons<TPostBuilderAddShow, TPostObject>
    {
        private readonly TPostBuilderAddShow _postBuilder;
        private ITraktShow _currentShow;

        internal PostBuilderShowAddedWatchedAtWithSeasons(TPostBuilderAddShow postBuilder)
        {
            _postBuilder = postBuilder;
            _currentShow = null;
            WatchedShowsWithSeasons = new List<PostBuilderWatchedObjectWithSeasons<ITraktShow, IEnumerable<int>>>();
        }

        public List<PostBuilderWatchedObjectWithSeasons<ITraktShow, IEnumerable<int>>> WatchedShowsWithSeasons { get; }

        public TPostBuilderAddShow WatchedAt(DateTime watchedAt, int[] seasons)
        {
            WatchedShowsWithSeasons.Add(new PostBuilderWatchedObjectWithSeasons<ITraktShow, IEnumerable<int>>
            {
                Object = _currentShow,
                WatchedAt = watchedAt,
                Seasons = seasons.ToList()
            });

            return _postBuilder;
        }

        public TPostBuilderAddShow WatchedAt(DateTime watchedAt, int season, params int[] seasons)
        {
            var newSeasons = new List<int>
            {
                season
            };

            newSeasons.AddRange(seasons);

            WatchedShowsWithSeasons.Add(new PostBuilderWatchedObjectWithSeasons<ITraktShow, IEnumerable<int>>
            {
                Object = _currentShow,
                WatchedAt = watchedAt,
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
