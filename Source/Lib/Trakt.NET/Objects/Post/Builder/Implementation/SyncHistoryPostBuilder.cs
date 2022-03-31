namespace TraktNet.Objects.Post
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

    internal sealed class SyncHistoryPostBuilder : ITraktSyncHistoryPostBuilder
    {
        private readonly List<ITraktMovie> _movies;
        private readonly List<ITraktShow> _shows;
        private readonly List<ITraktEpisode> _episodes;
        private readonly PostBuilderMovieAddedWatchedAt<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost> _watchedMovies;
        private readonly PostBuilderShowAddedWatchedAt<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost> _watchedShows;
        private readonly PostBuilderShowAddedWatchedAtWithSeasons<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost> _watchedShowsWithSeasons;
        private readonly PostBuilderShowAddedWatchedAtWithSeasonsCollection<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost, PostHistorySeasons> _watchedShowsWithSeasonsCollection;
        private readonly PostBuilderShowAddedSeasons<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost> _showsWithSeasons;
        private readonly PostBuilderShowAddedSeasonsCollection<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost, PostHistorySeasons> _showsWithSeasonsCollection;
        private readonly PostBuilderEpisodeAddedWatchedAt<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost> _watchedEpisodes;

        internal SyncHistoryPostBuilder()
        {
            _movies = new List<ITraktMovie>();
            _shows = new List<ITraktShow>();
            _episodes = new List<ITraktEpisode>();
            _watchedMovies = new PostBuilderMovieAddedWatchedAt<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost>(this);
            _watchedShows = new PostBuilderShowAddedWatchedAt<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost>(this);
            _watchedShowsWithSeasons = new PostBuilderShowAddedWatchedAtWithSeasons<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost>(this);
            _watchedShowsWithSeasonsCollection = new PostBuilderShowAddedWatchedAtWithSeasonsCollection<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost, PostHistorySeasons>(this);
            _showsWithSeasons = new PostBuilderShowAddedSeasons<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost>(this);
            _showsWithSeasonsCollection = new PostBuilderShowAddedSeasonsCollection<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost, PostHistorySeasons>(this);
            _watchedEpisodes = new PostBuilderEpisodeAddedWatchedAt<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost>(this);
        }

        public ITraktSyncHistoryPostBuilder WithMovie(ITraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            _movies.Add(movie);
            return this;
        }

        public ITraktSyncHistoryPostBuilder WithMovies(IEnumerable<ITraktMovie> movies)
        {
            if (movies == null)
                throw new ArgumentNullException(nameof(movies));

            _movies.AddRange(movies);
            return this;
        }

        public ITraktPostBuilderMovieAddedWatchedAt<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost> WithWatchedMovie(ITraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            _watchedMovies.SetCurrentMovie(movie);
            return _watchedMovies;
        }

        public ITraktSyncHistoryPostBuilder WithShow(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _shows.Add(show);
            return this;
        }

        public ITraktSyncHistoryPostBuilder WithShows(IEnumerable<ITraktShow> shows)
        {
            if (shows == null)
                throw new ArgumentNullException(nameof(shows));

            _shows.AddRange(shows);
            return this;
        }

        public ITraktPostBuilderShowAddedWatchedAt<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost> WithWatchedShow(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _watchedShows.SetCurrentShow(show);
            return _watchedShows;
        }

        public ITraktPostBuilderShowAddedWatchedAtWithSeasons<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost> WithWatchedShowAndSeasons(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _watchedShowsWithSeasons.SetCurrentShow(show);
            return _watchedShowsWithSeasons;
        }

        public ITraktPostBuilderShowAddedWatchedAtWithSeasonsCollection<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost, PostHistorySeasons> WithWatchedShowAndSeasonsCollection(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _watchedShowsWithSeasonsCollection.SetCurrentShow(show);
            return _watchedShowsWithSeasonsCollection;
        }

        public ITraktPostBuilderShowAddedSeasons<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost> WithShowAndSeasons(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _showsWithSeasons.SetCurrentShow(show);
            return _showsWithSeasons;
        }

        public ITraktPostBuilderShowAddedSeasonsCollection<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost, PostHistorySeasons> WithShowAndSeasonsCollection(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _showsWithSeasonsCollection.SetCurrentShow(show);
            return _showsWithSeasonsCollection;
        }

        public ITraktSyncHistoryPostBuilder WithEpisode(ITraktEpisode episode)
        {
            if (episode == null)
                throw new ArgumentNullException(nameof(episode));

            _episodes.Add(episode);
            return this;
        }

        public ITraktSyncHistoryPostBuilder WithEpisodes(IEnumerable<ITraktEpisode> episodes)
        {
            if (episodes == null)
                throw new ArgumentNullException(nameof(episodes));

            _episodes.AddRange(episodes);
            return this;
        }

        public ITraktPostBuilderEpisodeAddedWatchedAt<ITraktSyncHistoryPostBuilder, ITraktSyncHistoryPost> WithWatchedEpisode(ITraktEpisode episode)
        {
            if (episode == null)
                throw new ArgumentNullException(nameof(episode));

            _watchedEpisodes.SetCurrentEpisode(episode);
            return _watchedEpisodes;
        }

        public ITraktSyncHistoryPost Build()
        {
            ITraktSyncHistoryPost syncHistoryPost = new TraktSyncHistoryPost();
            AddMovies(syncHistoryPost);
            AddShows(syncHistoryPost);
            AddEpisodes(syncHistoryPost);
            return syncHistoryPost;
        }

        private void AddMovies(ITraktSyncHistoryPost syncHistoryPost)
        {
            if (syncHistoryPost.Movies == null)
                syncHistoryPost.Movies = new List<ITraktSyncHistoryPostMovie>();

            foreach (ITraktMovie movie in _movies)
                (syncHistoryPost.Movies as List<ITraktSyncHistoryPostMovie>).Add(CreateSyncHistoryPostMovie(movie));

            foreach (PostBuilderWatchedObject<ITraktMovie> movieEntry in _watchedMovies.WatchedMovies)
                (syncHistoryPost.Movies as List<ITraktSyncHistoryPostMovie>).Add(CreateSyncHistoryPostMovie(movieEntry.Object, movieEntry.WatchedAt));
        }

        private void AddShows(ITraktSyncHistoryPost syncHistoryPost)
        {
            if (syncHistoryPost.Shows == null)
                syncHistoryPost.Shows = new List<ITraktSyncHistoryPostShow>();

            foreach (ITraktShow show in _shows)
                (syncHistoryPost.Shows as List<ITraktSyncHistoryPostShow>).Add(CreateSyncHistoryPostShow(show));

            foreach (PostBuilderWatchedObject<ITraktShow> showEntry in _watchedShows.WatchedShows)
                (syncHistoryPost.Shows as List<ITraktSyncHistoryPostShow>).Add(CreateSyncHistoryPostShow(showEntry.Object, showEntry.WatchedAt));

            foreach (PostBuilderWatchedObjectWithSeasons<ITraktShow, IEnumerable<int>> showEntry in _watchedShowsWithSeasons.WatchedShowsWithSeasons)
                (syncHistoryPost.Shows as List<ITraktSyncHistoryPostShow>).Add(CreateSyncHistoryPostShowWithSeasons(showEntry.Object, showEntry.WatchedAt, showEntry.Seasons));

            foreach (PostBuilderWatchedObjectWithSeasons<ITraktShow, PostHistorySeasons> showEntry in _watchedShowsWithSeasonsCollection.WatchedShowsWithSeasonsCollection)
                (syncHistoryPost.Shows as List<ITraktSyncHistoryPostShow>).Add(CreateSyncHistoryPostShowWithSeasonsCollection(showEntry.Object, showEntry.WatchedAt, showEntry.Seasons));

            foreach (PostBuilderObjectWithSeasons<ITraktShow, IEnumerable<int>> showEntry in _showsWithSeasons.ShowsWithSeasons)
                (syncHistoryPost.Shows as List<ITraktSyncHistoryPostShow>).Add(CreateSyncHistoryPostShowWithSeasons(showEntry.Object, null, showEntry.Seasons));

            foreach (PostBuilderObjectWithSeasons<ITraktShow, PostHistorySeasons> showEntry in _showsWithSeasonsCollection.ShowsWithSeasonsCollection)
                (syncHistoryPost.Shows as List<ITraktSyncHistoryPostShow>).Add(CreateSyncHistoryPostShowWithSeasonsCollection(showEntry.Object, null, showEntry.Seasons));
        }

        private void AddEpisodes(ITraktSyncHistoryPost syncHistoryPost)
        {
            if (syncHistoryPost.Episodes == null)
                syncHistoryPost.Episodes = new List<ITraktSyncHistoryPostEpisode>();

            foreach (ITraktEpisode episode in _episodes)
                (syncHistoryPost.Episodes as List<ITraktSyncHistoryPostEpisode>).Add(CreateSyncHistoryPostEpisode(episode));

            foreach (PostBuilderWatchedObject<ITraktEpisode> episodeEntry in _watchedEpisodes.WatchedEpisodes)
                (syncHistoryPost.Episodes as List<ITraktSyncHistoryPostEpisode>).Add(CreateSyncHistoryPostEpisode(episodeEntry.Object, episodeEntry.WatchedAt));
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
