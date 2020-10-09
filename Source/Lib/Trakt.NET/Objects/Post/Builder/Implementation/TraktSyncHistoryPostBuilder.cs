namespace TraktNet.Objects.Post.Builder.Implementation
{
    using Interfaces;
    using Objects.Get.Episodes;
    using Objects.Get.Movies;
    using Objects.Get.Shows;
    using Objects.Post.Builder.Interfaces.Capabilities;
    using Objects.Post.Syncs.History;
    using System.Collections.Generic;

    public class TraktSyncHistoryPostBuilder : ITraktSyncHistoryPostBuilder
    {
        internal TraktSyncHistoryPostBuilder()
        {
        }

        public ITraktPostBuilderShowAddedSeasons<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost> AddShowAndSeasons(ITraktShow show)
        {
            throw new System.NotImplementedException();
        }

        public ITraktPostBuilderShowAddedSeasonsCollection<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost, PostHistorySeasons> AddShowAndSeasonsCollection(ITraktShow show)
        {
            throw new System.NotImplementedException();
        }

        public ITraktPostBuilderEpisodeAddedWatchedAt<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost> AddWatchedEpisode(ITraktEpisode episode)
        {
            throw new System.NotImplementedException();
        }

        public ITraktPostBuilderMovieAddedWatchedAt<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost> AddWatchedMovie(ITraktMovie movie)
        {
            throw new System.NotImplementedException();
        }

        public ITraktPostBuilderShowAddedWatchedAt<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost> AddWatchedShow(ITraktShow show)
        {
            throw new System.NotImplementedException();
        }

        public ITraktPostBuilderShowAddedWatchedAtWithSeasons<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost> AddWatchedShowAndSeasons(ITraktShow show)
        {
            throw new System.NotImplementedException();
        }

        public ITraktPostBuilderShowAddedWatchedAtWithSeasonsCollection<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost, PostHistorySeasons> AddWatchedShowAndSeasonsCollection(ITraktShow show)
        {
            throw new System.NotImplementedException();
        }

        public ITraktSyncHistoryPost Build()
        {
            throw new System.NotImplementedException();
        }

        public ITraktSyncHistoryPostBuilder WithEpisode(ITraktEpisode episode)
        {
            throw new System.NotImplementedException();
        }

        public ITraktSyncHistoryPostBuilder WithEpisodes(IEnumerable<ITraktEpisode> episodes)
        {
            throw new System.NotImplementedException();
        }

        public ITraktSyncHistoryPostBuilder WithMovie(ITraktMovie movie)
        {
            throw new System.NotImplementedException();
        }

        public ITraktSyncHistoryPostBuilder WithMovies(IEnumerable<ITraktMovie> movies)
        {
            throw new System.NotImplementedException();
        }

        public ITraktSyncHistoryPostBuilder WithShow(ITraktShow show)
        {
            throw new System.NotImplementedException();
        }

        public ITraktSyncHistoryPostBuilder WithShows(IEnumerable<ITraktShow> shows)
        {
            throw new System.NotImplementedException();
        }
    }
}
