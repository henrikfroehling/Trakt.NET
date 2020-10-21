namespace TraktNet.Objects.Post.Builder
{
    using Capabilities;
    using Get.Episodes;
    using Get.Movies;
    using Get.Shows;
    using Helper;
    using Post.Syncs.History;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class SyncHistoryRemovePostBuilder : ITraktSyncHistoryRemovePostBuilder
    {
        private readonly List<ITraktMovie> _movies;
        private readonly List<ITraktShow> _shows;
        private readonly List<ITraktEpisode> _episodes;
        private readonly List<ulong> _historyIds;
        private readonly PostBuilderMovieAddedWatchedAt<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost> _watchedMovies;
        private readonly PostBuilderShowAddedWatchedAt<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost> _watchedShows;
        private readonly PostBuilderShowAddedWatchedAtWithSeasons<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost> _watchedShowsWithSeasons;
        private readonly PostBuilderShowAddedWatchedAtWithSeasonsCollection<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost, PostHistorySeasons> _watchedShowsWithSeasonsCollection;
        private readonly PostBuilderShowAddedSeasons<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost> _showsWithSeasons;
        private readonly PostBuilderShowAddedSeasonsCollection<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost, PostHistorySeasons> _showsWithSeasonsCollection;
        private readonly PostBuilderEpisodeAddedWatchedAt<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost> _watchedEpisodes;

        internal SyncHistoryRemovePostBuilder()
        {
            _movies = new List<ITraktMovie>();
            _shows = new List<ITraktShow>();
            _episodes = new List<ITraktEpisode>();
            _historyIds = new List<ulong>();
            _watchedMovies = new PostBuilderMovieAddedWatchedAt<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost>(this);
            _watchedShows = new PostBuilderShowAddedWatchedAt<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost>(this);
            _watchedShowsWithSeasons = new PostBuilderShowAddedWatchedAtWithSeasons<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost>(this);
            _watchedShowsWithSeasonsCollection = new PostBuilderShowAddedWatchedAtWithSeasonsCollection<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost, PostHistorySeasons>(this);
            _showsWithSeasons = new PostBuilderShowAddedSeasons<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost>(this);
            _showsWithSeasonsCollection = new PostBuilderShowAddedSeasonsCollection<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost, PostHistorySeasons>(this);
            _watchedEpisodes = new PostBuilderEpisodeAddedWatchedAt<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost>(this);
        }

        public ITraktSyncHistoryRemovePostBuilder WithMovie(ITraktMovie movie)
        {
            _movies.Add(movie);
            return this;
        }

        public ITraktSyncHistoryRemovePostBuilder WithMovies(IEnumerable<ITraktMovie> movies)
        {
            _movies.AddRange(movies);
            return this;
        }

        public ITraktPostBuilderMovieAddedWatchedAt<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost> AddWatchedMovie(ITraktMovie movie)
        {
            _watchedMovies.SetCurrentMovie(movie);
            return _watchedMovies;
        }

        public ITraktSyncHistoryRemovePostBuilder WithShow(ITraktShow show)
        {
            _shows.Add(show);
            return this;
        }

        public ITraktSyncHistoryRemovePostBuilder WithShows(IEnumerable<ITraktShow> shows)
        {
            _shows.AddRange(shows);
            return this;
        }

        public ITraktPostBuilderShowAddedWatchedAt<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost> AddWatchedShow(ITraktShow show)
        {
            _watchedShows.SetCurrentShow(show);
            return _watchedShows;
        }

        public ITraktPostBuilderShowAddedWatchedAtWithSeasons<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost> AddWatchedShowAndSeasons(ITraktShow show)
        {
            _watchedShowsWithSeasons.SetCurrentShow(show);
            return _watchedShowsWithSeasons;
        }

        public ITraktPostBuilderShowAddedWatchedAtWithSeasonsCollection<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost, PostHistorySeasons> AddWatchedShowAndSeasonsCollection(ITraktShow show)
        {
            _watchedShowsWithSeasonsCollection.SetCurrentShow(show);
            return _watchedShowsWithSeasonsCollection;
        }

        public ITraktPostBuilderShowAddedSeasons<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost> AddShowAndSeasons(ITraktShow show)
        {
            _showsWithSeasons.SetCurrentShow(show);
            return _showsWithSeasons;
        }

        public ITraktPostBuilderShowAddedSeasonsCollection<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost, PostHistorySeasons> AddShowAndSeasonsCollection(ITraktShow show)
        {
            _showsWithSeasonsCollection.SetCurrentShow(show);
            return _showsWithSeasonsCollection;
        }

        public ITraktSyncHistoryRemovePostBuilder WithEpisode(ITraktEpisode episode)
        {
            _episodes.Add(episode);
            return this;
        }

        public ITraktSyncHistoryRemovePostBuilder WithEpisodes(IEnumerable<ITraktEpisode> episodes)
        {
            _episodes.AddRange(episodes);
            return this;
        }

        public ITraktPostBuilderEpisodeAddedWatchedAt<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost> AddWatchedEpisode(ITraktEpisode episode)
        {
            _watchedEpisodes.SetCurrentEpisode(episode);
            return _watchedEpisodes;
        }
        
        public ITraktSyncHistoryRemovePostBuilder AddHistoryIds(ulong[] historyIds)
        {
            _historyIds.AddRange(historyIds);
            return this;
        }

        public ITraktSyncHistoryRemovePostBuilder AddHistoryIds(ulong historyId, params ulong[] historyIds)
        {
            _historyIds.Add(historyId);
            _historyIds.AddRange(historyIds);
            return this;
        }

        public ITraktSyncHistoryRemovePost Build()
        {
            ITraktSyncHistoryRemovePost syncHistoryRemovePost = new TraktSyncHistoryRemovePost();
            AddMovies(syncHistoryRemovePost);
            AddShows(syncHistoryRemovePost);
            AddEpisodes(syncHistoryRemovePost);
            syncHistoryRemovePost.HistoryIds = _historyIds;
            return syncHistoryRemovePost;
        }

        private void AddMovies(ITraktSyncHistoryRemovePost syncHistoryRemovePost)
        {
            if (syncHistoryRemovePost.Movies == null)
                syncHistoryRemovePost.Movies = new List<ITraktSyncHistoryPostMovie>();

            foreach (ITraktMovie movie in _movies)
                (syncHistoryRemovePost.Movies as List<ITraktSyncHistoryPostMovie>).Add(CreateSyncHistoryPostMovie(movie));

            foreach (PostBuilderWatchedObject<ITraktMovie> movieEntry in _watchedMovies.WatchedMovies)
                (syncHistoryRemovePost.Movies as List<ITraktSyncHistoryPostMovie>).Add(CreateSyncHistoryPostMovie(movieEntry.Object, movieEntry.WatchedAt));
        }

        private void AddShows(ITraktSyncHistoryRemovePost syncHistoryRemovePost)
        {
            if (syncHistoryRemovePost.Shows == null)
                syncHistoryRemovePost.Shows = new List<ITraktSyncHistoryPostShow>();

            foreach (ITraktShow show in _shows)
                (syncHistoryRemovePost.Shows as List<ITraktSyncHistoryPostShow>).Add(CreateSyncHistoryPostShow(show));

            foreach (PostBuilderWatchedObject<ITraktShow> showEntry in _watchedShows.WatchedShows)
                (syncHistoryRemovePost.Shows as List<ITraktSyncHistoryPostShow>).Add(CreateSyncHistoryPostShow(showEntry.Object, showEntry.WatchedAt));

            foreach (PostBuilderWatchedObjectWithSeasons<ITraktShow, IEnumerable<int>> showEntry in _watchedShowsWithSeasons.WatchedShowsWithSeasons)
                (syncHistoryRemovePost.Shows as List<ITraktSyncHistoryPostShow>).Add(CreateSyncHistoryPostShowWithSeasons(showEntry.Object, showEntry.WatchedAt, showEntry.Seasons));

            foreach (PostBuilderWatchedObjectWithSeasons<ITraktShow, PostHistorySeasons> showEntry in _watchedShowsWithSeasonsCollection.WatchedShowsWithSeasonsCollection)
                (syncHistoryRemovePost.Shows as List<ITraktSyncHistoryPostShow>).Add(CreateSyncHistoryPostShowWithSeasonsCollection(showEntry.Object, showEntry.WatchedAt, showEntry.Seasons));

            foreach (PostBuilderObjectWithSeasons<ITraktShow, IEnumerable<int>> showEntry in _showsWithSeasons.ShowsWithSeasons)
                (syncHistoryRemovePost.Shows as List<ITraktSyncHistoryPostShow>).Add(CreateSyncHistoryPostShowWithSeasons(showEntry.Object, null, showEntry.Seasons));

            foreach (PostBuilderObjectWithSeasons<ITraktShow, PostHistorySeasons> showEntry in _showsWithSeasonsCollection.ShowsWithSeasonsCollection)
                (syncHistoryRemovePost.Shows as List<ITraktSyncHistoryPostShow>).Add(CreateSyncHistoryPostShowWithSeasonsCollection(showEntry.Object, null, showEntry.Seasons));
        }

        private void AddEpisodes(ITraktSyncHistoryRemovePost syncHistoryRemovePost)
        {
            if (syncHistoryRemovePost.Episodes == null)
                syncHistoryRemovePost.Episodes = new List<ITraktSyncHistoryPostEpisode>();

            foreach (ITraktEpisode episode in _episodes)
                (syncHistoryRemovePost.Episodes as List<ITraktSyncHistoryPostEpisode>).Add(CreateSyncHistoryPostEpisode(episode));

            foreach (PostBuilderWatchedObject<ITraktEpisode> episodeEntry in _watchedEpisodes.WatchedEpisodes)
                (syncHistoryRemovePost.Episodes as List<ITraktSyncHistoryPostEpisode>).Add(CreateSyncHistoryPostEpisode(episodeEntry.Object, episodeEntry.WatchedAt));
        }

        private ITraktSyncHistoryPostMovie CreateSyncHistoryPostMovie(ITraktMovie movie, DateTime? watchedAt = null)
        {
            var syncHistoryPostMovie = new TraktSyncHistoryPostMovie
            {
                Ids = movie.Ids,
                Title = movie.Title,
                Year = movie.Year
            };

            if (watchedAt.HasValue)
                syncHistoryPostMovie.WatchedAt = watchedAt.Value.ToUniversalTime();

            return syncHistoryPostMovie;
        }

        private ITraktSyncHistoryPostShow CreateSyncHistoryPostShow(ITraktShow show, DateTime? watchedAt = null)
        {
            var syncHistoryPostShow = new TraktSyncHistoryPostShow
            {
                Ids = show.Ids,
                Title = show.Title,
                Year = show.Year
            };

            if (watchedAt.HasValue)
                syncHistoryPostShow.WatchedAt = watchedAt.Value.ToUniversalTime();

            return syncHistoryPostShow;
        }

        private ITraktSyncHistoryPostShow CreateSyncHistoryPostShowWithSeasons(ITraktShow show, DateTime? watchedAt = null, IEnumerable<int> seasons = null)
        {
            var syncHistoryPostShow = CreateSyncHistoryPostShow(show, watchedAt);

            if (seasons != null)
                syncHistoryPostShow.Seasons = CreateSyncHistoryPostShowSeasons(seasons);

            return syncHistoryPostShow;
        }

        private ITraktSyncHistoryPostShow CreateSyncHistoryPostShowWithSeasonsCollection(ITraktShow show, DateTime? watchedAt = null, PostHistorySeasons seasons = null)
        {
            var syncHistoryPostShow = CreateSyncHistoryPostShow(show, watchedAt);

            if (seasons != null)
                syncHistoryPostShow.Seasons = CreateSyncHistoryPostShowSeasons(seasons);

            return syncHistoryPostShow;
        }

        private IEnumerable<ITraktSyncHistoryPostShowSeason> CreateSyncHistoryPostShowSeasons(IEnumerable<int> seasons)
        {
            var syncHistoryPostShowSeasons = new List<ITraktSyncHistoryPostShowSeason>();

            foreach (int season in seasons)
            {
                syncHistoryPostShowSeasons.Add(new TraktSyncHistoryPostShowSeason
                {
                    Number = season
                });
            }

            return syncHistoryPostShowSeasons;
        }

        private IEnumerable<ITraktSyncHistoryPostShowSeason> CreateSyncHistoryPostShowSeasons(PostHistorySeasons seasons)
        {
            var syncHistoryPostShowSeasons = new List<ITraktSyncHistoryPostShowSeason>();

            foreach (PostHistorySeason season in seasons)
            {
                var syncHistoryPostShowSeason = new TraktSyncHistoryPostShowSeason
                {
                    Number = season.Number
                };

                if (season.WatchedAt.HasValue)
                    syncHistoryPostShowSeason.WatchedAt = season.WatchedAt.Value.ToUniversalTime();

                if (season.Episodes?.Count() > 0)
                {
                    var syncHistoryPostShowEpisodes = new List<ITraktSyncHistoryPostShowEpisode>();

                    foreach (PostHistoryEpisode episode in season.Episodes)
                    {
                        var syncHistoryPostShowEpisode = new TraktSyncHistoryPostShowEpisode
                        {
                            Number = episode.Number
                        };

                        if (episode.WatchedAt.HasValue)
                            syncHistoryPostShowEpisode.WatchedAt = episode.WatchedAt.Value.ToUniversalTime();

                        syncHistoryPostShowEpisodes.Add(syncHistoryPostShowEpisode);
                    }

                    syncHistoryPostShowSeason.Episodes = syncHistoryPostShowEpisodes;
                }

                syncHistoryPostShowSeasons.Add(syncHistoryPostShowSeason);
            }

            return syncHistoryPostShowSeasons;
        }

        private ITraktSyncHistoryPostEpisode CreateSyncHistoryPostEpisode(ITraktEpisode episode, DateTime? watchedAt = null)
        {
            var syncHistoryPostEpisode = new TraktSyncHistoryPostEpisode
            {
                Ids = episode.Ids
            };

            if (watchedAt.HasValue)
                syncHistoryPostEpisode.WatchedAt = watchedAt.Value.ToUniversalTime();

            return syncHistoryPostEpisode;
        }
    }
}
