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

        public ITraktPostBuilderEpisodeAddedWatchedAt<ITraktPostBuilderAddEpisodeWithWatchedAt<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost>, ITraktSyncHistoryPost> AddEpisode(ITraktEpisode episode)
        {
            throw new System.NotImplementedException();
        }

        public ITraktPostBuilderMovieAddedWatchedAt<ITraktPostBuilderAddMovieWithWatchedAt<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost>, ITraktSyncHistoryPost> AddMovie(ITraktMovie movie)
        {
            throw new System.NotImplementedException();
        }

        public ITraktPostBuilderShowAddedSeasonsCollection<ITraktPostBuilderAddShowWithSeasonsCollection<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost, PostHistorySeasons>, ITraktSyncHistoryPost, PostHistorySeasons> AddShow(ITraktShow show)
        {
            throw new System.NotImplementedException();
        }

        public ITraktSyncHistoryPost Build()
        {
            throw new System.NotImplementedException();
        }

        public ITraktPostBuilderAddEpisodeWithWatchedAt<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost> WithEpisode(ITraktEpisode episode)
        {
            throw new System.NotImplementedException();
        }

        public ITraktPostBuilderAddEpisodeWithWatchedAt<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost> WithEpisodes(IEnumerable<ITraktEpisode> episodes)
        {
            throw new System.NotImplementedException();
        }

        public ITraktPostBuilderAddMovieWithWatchedAt<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost> WithMovie(ITraktMovie movie)
        {
            throw new System.NotImplementedException();
        }

        public ITraktPostBuilderAddMovieWithWatchedAt<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost> WithMovies(IEnumerable<ITraktMovie> movies)
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

        ITraktPostBuilderShowAddedWatchedAtWithSeasonsCollection<ITraktPostBuilderAddShowWithWatchedAtWithSeasonsCollection<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost, PostHistorySeasons>, ITraktSyncHistoryPost, PostHistorySeasons> ITraktPostBuilderAddShowWithWatchedAtWithSeasonsCollection<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost, PostHistorySeasons>.AddShow(ITraktShow show)
        {
            throw new System.NotImplementedException();
        }

        ITraktPostBuilderAddShowWithSeasonsCollection<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost, PostHistorySeasons> ITraktPostBuilderWithShow<ITraktPostBuilderAddShowWithSeasonsCollection<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost, PostHistorySeasons>, ITraktSyncHistoryPost>.WithShow(ITraktShow show)
        {
            throw new System.NotImplementedException();
        }

        ITraktPostBuilderAddShowWithWatchedAtWithSeasonsCollection<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost, PostHistorySeasons> ITraktPostBuilderWithShow<ITraktPostBuilderAddShowWithWatchedAtWithSeasonsCollection<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost, PostHistorySeasons>, ITraktSyncHistoryPost>.WithShow(ITraktShow show)
        {
            throw new System.NotImplementedException();
        }
    }
}
