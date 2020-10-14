namespace TraktNet.Objects.Post.Builder.Implementation
{
    using Helper;
    using Interfaces;
    using Interfaces.Capabilities;
    using Objects.Get.Episodes;
    using Objects.Get.Movies;
    using Objects.Get.Shows;
    using Objects.Post.Syncs.History;
    using System.Collections.Generic;

    public class TraktSyncHistoryPostBuilder : ITraktSyncHistoryPostBuilder
    {
        private readonly List<ITraktMovie> _movies;
        private readonly List<ITraktShow> _shows;
        private readonly List<ITraktEpisode> _episodes;
        private readonly ITraktPostBuilderMovieAddedWatchedAt<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost> _watchedMovies;
        private readonly ITraktPostBuilderShowAddedWatchedAt<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost> _watchedShows;
        private readonly ITraktPostBuilderShowAddedWatchedAtWithSeasons<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost> _watchedShowsWithSeasons;
        private readonly ITraktPostBuilderShowAddedWatchedAtWithSeasonsCollection<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost, PostHistorySeasons> _watchedShowsWithSeasonsCollection;
        private readonly ITraktPostBuilderShowAddedSeasons<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost> _showsWithSeasons;
        private readonly ITraktPostBuilderShowAddedSeasonsCollection<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost, PostHistorySeasons> _showsWithSeasonsCollection;
        private readonly ITraktPostBuilderEpisodeAddedWatchedAt<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost> _watchedEpisodes;

        internal TraktSyncHistoryPostBuilder()
        {
            _movies = new List<ITraktMovie>();
            _shows = new List<ITraktShow>();
            _episodes = new List<ITraktEpisode>();
            _watchedMovies = new TraktPostBuilderMovieAddedWatchedAt<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost>(this);
            _watchedShows = new TraktPostBuilderShowAddedWatchedAt<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost>(this);
            _watchedShowsWithSeasons = new TraktPostBuilderShowAddedWatchedAtWithSeasons<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost>(this);
            _watchedShowsWithSeasonsCollection = new TraktPostBuilderShowAddedWatchedAtWithSeasonsCollection<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost, PostHistorySeasons>(this);
            _showsWithSeasons = new TraktPostBuilderShowAddedSeasons<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost>(this);
            _showsWithSeasonsCollection = new TraktPostBuilderShowAddedSeasonsCollection<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost, PostHistorySeasons>(this);
            _watchedEpisodes = new TraktPostBuilderEpisodeAddedWatchedAt<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost>(this);
        }

        public ITraktSyncHistoryPostBuilder WithMovie(ITraktMovie movie)
        {
            _movies.Add(movie);
            return this;
        }

        public ITraktSyncHistoryPostBuilder WithMovies(IEnumerable<ITraktMovie> movies)
        {
            _movies.AddRange(movies);
            return this;
        }

        public ITraktPostBuilderMovieAddedWatchedAt<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost> AddWatchedMovie(ITraktMovie movie)
        {
            _watchedMovies.SetCurrentMovie(movie);
            return _watchedMovies;
        }

        public ITraktSyncHistoryPostBuilder WithShow(ITraktShow show)
        {
            _shows.Add(show);
            return this;
        }

        public ITraktSyncHistoryPostBuilder WithShows(IEnumerable<ITraktShow> shows)
        {
            _shows.AddRange(shows);
            return this;
        }

        public ITraktPostBuilderShowAddedWatchedAt<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost> AddWatchedShow(ITraktShow show)
        {
            _watchedShows.SetCurrentShow(show);
            return _watchedShows;
        }

        public ITraktPostBuilderShowAddedWatchedAtWithSeasons<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost> AddWatchedShowAndSeasons(ITraktShow show)
        {
            _watchedShowsWithSeasons.SetCurrentShow(show);
            return _watchedShowsWithSeasons;
        }

        public ITraktPostBuilderShowAddedWatchedAtWithSeasonsCollection<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost, PostHistorySeasons> AddWatchedShowAndSeasonsCollection(ITraktShow show)
        {
            _watchedShowsWithSeasonsCollection.SetCurrentShow(show);
            return _watchedShowsWithSeasonsCollection;
        }

        public ITraktPostBuilderShowAddedSeasons<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost> AddShowAndSeasons(ITraktShow show)
        {
            _showsWithSeasons.SetCurrentShow(show);
            return _showsWithSeasons;
        }

        public ITraktPostBuilderShowAddedSeasonsCollection<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost, PostHistorySeasons> AddShowAndSeasonsCollection(ITraktShow show)
        {
            _showsWithSeasonsCollection.SetCurrentShow(show);
            return _showsWithSeasonsCollection;
        }

        public ITraktSyncHistoryPostBuilder WithEpisode(ITraktEpisode episode)
        {
            _episodes.Add(episode);
            return this;
        }

        public ITraktSyncHistoryPostBuilder WithEpisodes(IEnumerable<ITraktEpisode> episodes)
        {
            _episodes.AddRange(episodes);
            return this;
        }

        public ITraktPostBuilderEpisodeAddedWatchedAt<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost> AddWatchedEpisode(ITraktEpisode episode)
        {
            _watchedEpisodes.SetCurrentEpisode(episode);
            return _watchedEpisodes;
        }

        public ITraktSyncHistoryPost Build()
        {
            return new TraktSyncHistoryPost();
        }

    }
}
