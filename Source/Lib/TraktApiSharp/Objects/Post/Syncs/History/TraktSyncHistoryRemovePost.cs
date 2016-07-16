namespace TraktApiSharp.Objects.Post.Syncs.History
{
    using Get.Movies;
    using Get.Shows;
    using Get.Shows.Episodes;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TraktSyncHistoryRemovePost : TraktSyncHistoryPost
    {
        [JsonProperty(PropertyName = "ids")]
        public IEnumerable<int> HistoryIds { get; set; }

        public static new TraktSyncHistoryRemovePostBuilder Builder() => new TraktSyncHistoryRemovePostBuilder();
    }

    public class TraktSyncHistoryRemovePostBuilder
    {
        protected TraktSyncHistoryRemovePost _historyPost;

        public TraktSyncHistoryRemovePostBuilder()
        {
            _historyPost = new TraktSyncHistoryRemovePost();
        }

        public TraktSyncHistoryRemovePostBuilder AddMovie(TraktMovie movie)
        {
            ValidateMovie(movie);
            EnsureMoviesListExists();

            return AddMovieOrIgnore(movie);
        }

        public TraktSyncHistoryRemovePostBuilder AddShow(TraktShow show)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            return AddShowOrIgnore(show);
        }

        public TraktSyncHistoryRemovePostBuilder AddShow(TraktShow show, int season, params int[] seasons)
        {
            ValidateShow(show);
            ValidateSeasons(season, seasons);
            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(season, seasons);
            CreateOrSetShow(show, showSeasons);

            return this;
        }

        public TraktSyncHistoryRemovePostBuilder AddShow(TraktShow show, HistorySeasonOrEpisode season,
                                                         params HistorySeasonOrEpisode[] seasons)
        {
            ValidateShow(show);

            if (season == null)
                throw new ArgumentNullException(nameof(season));

            ValidateSeasons(season, seasons);
            EnsureShowsListExists();

            if ((seasons == null || seasons.Length <= 0) && season != null)
                return AddShow(show, season.Number);

            var showSeasons = CreateShowSeasons(season, seasons);
            CreateOrSetShow(show, showSeasons);

            return this;
        }

        public TraktSyncHistoryRemovePostBuilder AddShow(TraktShow show, HistorySAE season, params HistorySAE[] seasons)
        {
            ValidateShow(show);
            ValidateSeasons(season, seasons);
            EnsureShowsListExists();

            if ((seasons == null || seasons.Length <= 0) && (season.Episodes == null || season.Episodes.Length <= 0))
                return AddShow(show, season.Number);

            var showSeasons = CreateShowSeasons(season, seasons);
            CreateOrSetShow(show, showSeasons);

            return this;
        }

        public TraktSyncHistoryRemovePostBuilder AddEpisode(TraktEpisode episode)
        {
            ValidateEpisode(episode);
            EnsureEpisodesListExists();

            return AddEpisodeOrIgnore(episode);
        }

        public TraktSyncHistoryRemovePost Build()
        {
            var movies = _historyPost.Movies;
            var shows = _historyPost.Shows;
            var episodes = _historyPost.Episodes;
            var historyIds = _historyPost.HistoryIds;

            var bHasNoMovies = movies == null || !movies.Any();
            var bHasNoShows = shows == null || !shows.Any();
            var bHasNoEpisodes = episodes == null || !episodes.Any();
            var bHasNoHistoryIds = historyIds == null || !historyIds.Any();

            if (bHasNoMovies && bHasNoShows && bHasNoEpisodes && bHasNoHistoryIds)
                throw new ArgumentException("no collection items set");

            return _historyPost;
        }

        protected void ValidateMovie(TraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            if (movie.Ids == null)
                throw new ArgumentNullException(nameof(movie.Ids));

            if (!movie.Ids.HasAnyId)
                throw new ArgumentException("no movie ids set or valid", nameof(movie.Ids));

            if (movie.Year.HasValue && movie.Year.Value.ToString().Length != 4)
                throw new ArgumentException("movie year not valid", nameof(movie.Year));
        }

        protected void ValidateShow(TraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            if (show.Ids == null)
                throw new ArgumentNullException(nameof(show.Ids));

            if (!show.Ids.HasAnyId)
                throw new ArgumentException("no show ids set or valid", nameof(show.Ids));

            if (show.Year.HasValue && show.Year.Value.ToString().Length != 4)
                throw new ArgumentException("show year not valid", nameof(show.Year));
        }

        protected void ValidateSeasons(int season, params int[] seasons)
        {
            if (season < 0)
                throw new ArgumentException("season number not valid", nameof(season));

            if (seasons != null)
            {
                for (int i = 0; i < seasons.Length; i++)
                {
                    if (seasons[i] < 0)
                        throw new ArgumentException("at least one season number not valid", nameof(seasons));
                }
            }
        }

        protected void ValidateSeasons(HistorySeasonOrEpisode season, params HistorySeasonOrEpisode[] seasons)
        {
            if (season.Number < 0)
                throw new ArgumentException("season number not valid", nameof(season));

            if (seasons != null)
            {
                for (int i = 0; i < seasons.Length; i++)
                {
                    if (seasons[i].Number < 0)
                        throw new ArgumentException("at least one season number not valid", nameof(seasons));
                }
            }
        }

        protected void ValidateSeasons(HistorySAE season, params HistorySAE[] seasons)
        {
            if (season.Number < 0)
                throw new ArgumentException("season number not valid", nameof(season.Number));

            if (season.Episodes != null)
            {
                for (int i = 0; i < season.Episodes.Length; i++)
                {
                    if (season.Episodes[i].Number < 0)
                        throw new ArgumentException("at least one episode number not valid", nameof(season));
                }
            }

            if (seasons != null)
            {
                for (int i = 0; i < seasons.Length; i++)
                {
                    if (seasons[i].Number < 0)
                        throw new ArgumentException("at least one season number not valid", nameof(seasons));

                    if (seasons[i].Episodes != null)
                    {
                        for (int j = 0; j < seasons[i].Episodes.Length; j++)
                        {
                            if (seasons[i].Episodes[j].Number < 0)
                                throw new ArgumentException("at least one episode number not valid", nameof(seasons));
                        }
                    }
                }
            }
        }

        protected void ValidateEpisode(TraktEpisode episode)
        {
            if (episode == null)
                throw new ArgumentNullException(nameof(episode));

            if (episode.Ids == null)
                throw new ArgumentNullException(nameof(episode.Ids));

            if (!episode.Ids.HasAnyId)
                throw new ArgumentException("no episode ids set or valid", nameof(episode.Ids));
        }

        protected bool ContainsMovie(TraktMovie movie)
        {
            return _historyPost.Movies.Where(m => m.Ids == movie.Ids).FirstOrDefault() != null;
        }

        protected void EnsureMoviesListExists()
        {
            if (_historyPost.Movies == null)
                _historyPost.Movies = new List<TraktSyncHistoryPostMovie>();
        }

        protected bool ContainsShow(TraktShow show)
        {
            return _historyPost.Shows.Where(s => s.Ids == show.Ids).FirstOrDefault() != null;
        }

        protected void EnsureShowsListExists()
        {
            if (_historyPost.Shows == null)
                _historyPost.Shows = new List<TraktSyncHistoryPostShow>();
        }

        protected bool ContainsEpisode(TraktEpisode episode)
        {
            return _historyPost.Episodes.Where(e => e.Ids == episode.Ids).FirstOrDefault() != null;
        }

        protected void EnsureEpisodesListExists()
        {
            if (_historyPost.Episodes == null)
                _historyPost.Episodes = new List<TraktSyncHistoryPostEpisode>();
        }

        protected TraktSyncHistoryRemovePostBuilder AddMovieOrIgnore(TraktMovie movie, DateTime? watchedAt = null)
        {
            if (ContainsMovie(movie))
                return this;

            var historyMovie = new TraktSyncHistoryPostMovie();
            historyMovie.Ids = movie.Ids;
            historyMovie.Title = movie.Title;
            historyMovie.Year = movie.Year;

            if (watchedAt.HasValue)
                historyMovie.WatchedAt = watchedAt.Value.ToUniversalTime();

            (_historyPost.Movies as List<TraktSyncHistoryPostMovie>).Add(historyMovie);

            return this;
        }

        protected TraktSyncHistoryRemovePostBuilder AddShowOrIgnore(TraktShow show, DateTime? watchedAt = null)
        {
            if (ContainsShow(show))
                return this;

            var historyShow = new TraktSyncHistoryPostShow();
            historyShow.Ids = show.Ids;
            historyShow.Title = show.Title;
            historyShow.Year = show.Year;

            if (watchedAt.HasValue)
                historyShow.WatchedAt = watchedAt.Value.ToUniversalTime();

            (_historyPost.Shows as List<TraktSyncHistoryPostShow>).Add(historyShow);

            return this;
        }

        protected TraktSyncHistoryRemovePostBuilder AddEpisodeOrIgnore(TraktEpisode episode, DateTime? watchedAt = null)
        {
            if (ContainsEpisode(episode))
                return this;

            var historyEpisode = new TraktSyncHistoryPostEpisode();
            historyEpisode.Ids = episode.Ids;

            if (watchedAt.HasValue)
                historyEpisode.WatchedAt = watchedAt.Value.ToUniversalTime();

            (_historyPost.Episodes as List<TraktSyncHistoryPostEpisode>).Add(historyEpisode);

            return this;
        }

        protected void CreateOrSetShow(TraktShow show, IEnumerable<TraktSyncHistoryPostShowSeason> showSeasons,
                                       DateTime? watchedAt = null)
        {
            var existingShow = _historyPost.Shows.Where(s => s.Ids == show.Ids).FirstOrDefault();

            if (existingShow != null)
                existingShow.Seasons = showSeasons;
            else
            {
                var historyShow = new TraktSyncHistoryPostShow();
                historyShow.Ids = show.Ids;
                historyShow.Title = show.Title;
                historyShow.Year = show.Year;

                if (watchedAt.HasValue)
                    historyShow.WatchedAt = watchedAt.Value.ToUniversalTime();

                historyShow.Seasons = showSeasons;
                (_historyPost.Shows as List<TraktSyncHistoryPostShow>).Add(historyShow);
            }
        }

        protected IEnumerable<TraktSyncHistoryPostShowSeason> CreateShowSeasons(int season, params int[] seasons)
        {
            var seasonsToAdd = new int[seasons.Length + 1];
            seasonsToAdd[0] = season;
            seasons.CopyTo(seasonsToAdd, 1);

            var showSeasons = new List<TraktSyncHistoryPostShowSeason>();

            for (int i = 0; i < seasonsToAdd.Length; i++)
                showSeasons.Add(new TraktSyncHistoryPostShowSeason { Number = seasonsToAdd[i] });

            return showSeasons;
        }

        protected IEnumerable<TraktSyncHistoryPostShowSeason> CreateShowSeasons(HistorySeasonOrEpisode season,
                                                                                params HistorySeasonOrEpisode[] seasons)
        {
            var seasonsAndEpisodesToAdd = new HistorySeasonOrEpisode[seasons.Length + 1];
            seasonsAndEpisodesToAdd[0] = season;
            seasons.CopyTo(seasonsAndEpisodesToAdd, 1);

            var showSeasons = new List<TraktSyncHistoryPostShowSeason>();

            for (int i = 0; i < seasonsAndEpisodesToAdd.Length; i++)
            {
                var seasonToAdd = seasonsAndEpisodesToAdd[i];
                var showSingleSeason = new TraktSyncHistoryPostShowSeason { Number = seasonToAdd.Number };

                if (seasonToAdd.WatchedAt.HasValue)
                    showSingleSeason.WatchedAt = seasonToAdd.WatchedAt.Value.ToUniversalTime();

                showSeasons.Add(showSingleSeason);
            }

            return showSeasons;
        }

        protected IEnumerable<TraktSyncHistoryPostShowSeason> CreateShowSeasons(HistorySAE season, params HistorySAE[] seasons)
        {
            var seasonsAndEpisodesToAdd = new HistorySAE[seasons.Length + 1];
            seasonsAndEpisodesToAdd[0] = season;
            seasons.CopyTo(seasonsAndEpisodesToAdd, 1);

            var showSeasons = new List<TraktSyncHistoryPostShowSeason>();

            for (int i = 0; i < seasonsAndEpisodesToAdd.Length; i++)
            {
                var seasonToAdd = seasonsAndEpisodesToAdd[i];
                var showSingleSeason = new TraktSyncHistoryPostShowSeason { Number = seasonToAdd.Number };

                if (seasonToAdd.WatchedAt.HasValue)
                    showSingleSeason.WatchedAt = seasonToAdd.WatchedAt.Value.ToUniversalTime();

                var episodesToAdd = seasonToAdd.Episodes;

                if (episodesToAdd != null && episodesToAdd.Length > 0)
                {
                    var showEpisodes = new List<TraktSyncHistoryPostShowEpisode>();

                    for (int j = 0; j < episodesToAdd.Length; j++)
                    {
                        var episodeToAdd = episodesToAdd[j];
                        var showEpisode = new TraktSyncHistoryPostShowEpisode { Number = episodeToAdd.Number };

                        if (episodeToAdd.WatchedAt.HasValue)
                            showEpisode.WatchedAt = episodeToAdd.WatchedAt.Value.ToUniversalTime();

                        showEpisodes.Add(showEpisode);
                    }

                    showSingleSeason.Episodes = showEpisodes;
                }

                showSeasons.Add(showSingleSeason);
            }

            return showSeasons;
        }

        public TraktSyncHistoryRemovePostBuilder AddHistoryIds(int id, params int[] ids)
        {
            var idsToAdd = new int[ids.Length + 1];
            idsToAdd[0] = id;
            ids.CopyTo(idsToAdd, 1);

            if (_historyPost.HistoryIds == null)
                _historyPost.HistoryIds = new List<int>();

            for (int i = 0; i < idsToAdd.Length; i++)
            {
                if (idsToAdd[i] <= 0)
                    throw new ArgumentException("at least one id is not valid", "id and / or ids");

                (_historyPost.HistoryIds as List<int>).Add(idsToAdd[i]);
            }

            return this;
        }
    }
}
