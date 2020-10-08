namespace TraktNet.Objects.Post.Builder.Implementation
{
    using Interfaces;
    using Objects.Get.Episodes;
    using Objects.Get.Movies;
    using Objects.Get.Shows;
    using Objects.Post.Builder.Interfaces.Capabilities;
    using Objects.Post.Syncs.Watchlist;
    using System.Collections.Generic;

    public class TraktSyncWatchlistPostBuilder : ITraktSyncWatchlistPostBuilder
    {
        internal TraktSyncWatchlistPostBuilder()
        {
        }

        public ITraktPostBuilderShowAddedSeasonsCollection<ITraktPostBuilderAddShowWithSeasonsCollection<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost, PostSeasons>, ITraktSyncWatchlistPost, PostSeasons> AddShow(ITraktShow show)
        {
            throw new System.NotImplementedException();
        }

        public ITraktSyncWatchlistPost Build()
        {
            throw new System.NotImplementedException();
        }

        public ITraktSyncWatchlistPostBuilder WithEpisode(ITraktEpisode episode)
        {
            throw new System.NotImplementedException();
        }

        public ITraktSyncWatchlistPostBuilder WithEpisodes(IEnumerable<ITraktEpisode> episodes)
        {
            throw new System.NotImplementedException();
        }

        public ITraktSyncWatchlistPostBuilder WithMovie(ITraktMovie movie)
        {
            throw new System.NotImplementedException();
        }

        public ITraktSyncWatchlistPostBuilder WithMovies(IEnumerable<ITraktMovie> movies)
        {
            throw new System.NotImplementedException();
        }

        public ITraktPostBuilderAddShowWithSeasonsCollection<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost, PostSeasons> WithShow(ITraktShow show)
        {
            throw new System.NotImplementedException();
        }

        public ITraktSyncWatchlistPostBuilder WithShows(IEnumerable<ITraktShow> shows)
        {
            throw new System.NotImplementedException();
        }

        ITraktSyncWatchlistPostBuilder ITraktPostBuilderWithShow<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost>.WithShow(ITraktShow show)
        {
            throw new System.NotImplementedException();
        }
    }
}
