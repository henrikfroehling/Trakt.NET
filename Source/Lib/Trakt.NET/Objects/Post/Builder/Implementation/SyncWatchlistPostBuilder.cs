namespace TraktNet.Objects.Post
{
    using Capabilities;
    using Get.Episodes;
    using Get.Movies;
    using Get.Shows;
    using Helper;
    using Post.Syncs.Watchlist;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal sealed class SyncWatchlistPostBuilder : ITraktSyncWatchlistPostBuilder
    {
        private readonly List<ITraktMovie> _movies;
        private readonly List<ITraktShow> _shows;
        private readonly List<ITraktEpisode> _episodes;
        private readonly PostBuilderShowAddedSeasons<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost> _showsWithSeasons;
        private readonly PostBuilderShowAddedSeasonsCollection<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost, PostSeasons> _showsWithSeasonsCollection;

        internal SyncWatchlistPostBuilder()
        {
            _movies = new List<ITraktMovie>();
            _shows = new List<ITraktShow>();
            _episodes = new List<ITraktEpisode>();
            _showsWithSeasons = new PostBuilderShowAddedSeasons<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost>(this);
            _showsWithSeasonsCollection = new PostBuilderShowAddedSeasonsCollection<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost, PostSeasons>(this);
        }

        public ITraktSyncWatchlistPostBuilder WithMovie(ITraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            _movies.Add(movie);
            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithMovies(IEnumerable<ITraktMovie> movies)
        {
            if (movies == null)
                throw new ArgumentNullException(nameof(movies));

            _movies.AddRange(movies);
            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithShow(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _shows.Add(show);
            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithShows(IEnumerable<ITraktShow> shows)
        {
            if (shows == null)
                throw new ArgumentNullException(nameof(shows));

            _shows.AddRange(shows);
            return this;
        }

        public ITraktPostBuilderShowAddedSeasons<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost> AddShowAndSeasons(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _showsWithSeasons.SetCurrentShow(show);
            return _showsWithSeasons;
        }

        public ITraktPostBuilderShowAddedSeasonsCollection<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost, PostSeasons> AddShowAndSeasonsCollection(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _showsWithSeasonsCollection.SetCurrentShow(show);
            return _showsWithSeasonsCollection;
        }

        public ITraktSyncWatchlistPostBuilder WithEpisode(ITraktEpisode episode)
        {
            if (episode == null)
                throw new ArgumentNullException(nameof(episode));

            _episodes.Add(episode);
            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithEpisodes(IEnumerable<ITraktEpisode> episodes)
        {
            if (episodes == null)
                throw new ArgumentNullException(nameof(episodes));

            _episodes.AddRange(episodes);
            return this;
        }

        public ITraktSyncWatchlistPost Build()
        {
            ITraktSyncWatchlistPost syncWatchlistPost = new TraktSyncWatchlistPost();
            AddMovies(syncWatchlistPost);
            AddShows(syncWatchlistPost);
            AddEpisodes(syncWatchlistPost);
            return syncWatchlistPost;
        }

        private void AddMovies(ITraktSyncWatchlistPost syncWatchlistPost)
        {
            if (syncWatchlistPost.Movies == null)
                syncWatchlistPost.Movies = new List<ITraktSyncWatchlistPostMovie>();

            foreach (ITraktMovie movie in _movies)
                (syncWatchlistPost.Movies as List<ITraktSyncWatchlistPostMovie>).Add(CreateSyncWatchlistPostMovie(movie));
        }

        private void AddShows(ITraktSyncWatchlistPost syncWatchlistPost)
        {
            if (syncWatchlistPost.Shows == null)
                syncWatchlistPost.Shows = new List<ITraktSyncWatchlistPostShow>();

            foreach (ITraktShow show in _shows)
                (syncWatchlistPost.Shows as List<ITraktSyncWatchlistPostShow>).Add(CreateSyncWatchlistPostShow(show));

            foreach (PostBuilderObjectWithSeasons<ITraktShow, IEnumerable<int>> showEntry in _showsWithSeasons.ShowsWithSeasons)
                (syncWatchlistPost.Shows as List<ITraktSyncWatchlistPostShow>).Add(CreateSyncWatchlistPostShowWithSeasons(showEntry.Object, showEntry.Seasons));

            foreach (PostBuilderObjectWithSeasons<ITraktShow, PostSeasons> showEntry in _showsWithSeasonsCollection.ShowsWithSeasonsCollection)
                (syncWatchlistPost.Shows as List<ITraktSyncWatchlistPostShow>).Add(CreateSyncWatchlistPostShowWithSeasonsCollection(showEntry.Object, showEntry.Seasons));
        }

        private void AddEpisodes(ITraktSyncWatchlistPost syncWatchlistPost)
        {
            if (syncWatchlistPost.Episodes == null)
                syncWatchlistPost.Episodes = new List<ITraktSyncWatchlistPostEpisode>();

            foreach (ITraktEpisode episode in _episodes)
                (syncWatchlistPost.Episodes as List<ITraktSyncWatchlistPostEpisode>).Add(CreateSyncWatchlistPostEpisode(episode));
        }

        private ITraktSyncWatchlistPostMovie CreateSyncWatchlistPostMovie(ITraktMovie movie)
        {
            return new TraktSyncWatchlistPostMovie
            {
                Ids = movie.Ids,
                Title = movie.Title,
                Year = movie.Year
            };
        }

        private ITraktSyncWatchlistPostShow CreateSyncWatchlistPostShow(ITraktShow show)
        {
            return new TraktSyncWatchlistPostShow
            {
                Ids = show.Ids,
                Title = show.Title,
                Year = show.Year
            };
        }

        private ITraktSyncWatchlistPostShow CreateSyncWatchlistPostShowWithSeasons(ITraktShow show, IEnumerable<int> seasons)
        {
            var syncWatchlistPostShow = CreateSyncWatchlistPostShow(show);

            if (seasons != null)
                syncWatchlistPostShow.Seasons = CreateSyncWatchlistPostShowSeasons(seasons);

            return syncWatchlistPostShow;
        }

        private ITraktSyncWatchlistPostShow CreateSyncWatchlistPostShowWithSeasonsCollection(ITraktShow show, PostSeasons seasons)
        {
            var syncWatchlistPostShow = CreateSyncWatchlistPostShow(show);

            if (seasons != null)
                syncWatchlistPostShow.Seasons = CreateSyncWatchlistPostShowSeasons(seasons);

            return syncWatchlistPostShow;
        }

        private IEnumerable<ITraktSyncWatchlistPostShowSeason> CreateSyncWatchlistPostShowSeasons(IEnumerable<int> seasons)
        {
            var syncWatchlistPostShowSeasons = new List<ITraktSyncWatchlistPostShowSeason>();

            foreach (int season in seasons)
            {
                syncWatchlistPostShowSeasons.Add(new TraktSyncWatchlistPostShowSeason
                {
                    Number = season
                });
            }

            return syncWatchlistPostShowSeasons;
        }

        private IEnumerable<ITraktSyncWatchlistPostShowSeason> CreateSyncWatchlistPostShowSeasons(PostSeasons seasons)
        {
            var syncWatchlistPostShowSeasons = new List<ITraktSyncWatchlistPostShowSeason>();

            foreach (PostSeason season in seasons)
            {
                var syncWatchlistPostShowSeason = new TraktSyncWatchlistPostShowSeason
                {
                    Number = season.Number
                };

                if (season.Episodes?.Count() > 0)
                {
                    var syncWatchlistPostShowEpisodes = new List<ITraktSyncWatchlistPostShowEpisode>();

                    foreach (PostEpisode episode in season.Episodes)
                    {
                        syncWatchlistPostShowEpisodes.Add(new TraktSyncWatchlistPostShowEpisode
                        {
                            Number = episode.Number
                        });
                    }

                    syncWatchlistPostShowSeason.Episodes = syncWatchlistPostShowEpisodes;
                }

                syncWatchlistPostShowSeasons.Add(syncWatchlistPostShowSeason);
            }

            return syncWatchlistPostShowSeasons;
        }

        private ITraktSyncWatchlistPostEpisode CreateSyncWatchlistPostEpisode(ITraktEpisode episode)
        {
            return new TraktSyncWatchlistPostEpisode
            {
                Ids = episode.Ids
            };
        }
    }
}
