namespace TraktApiSharp.Objects.Post.Syncs.History
{
    using Get.Movies;
    using Get.Shows;
    using Get.Shows.Episodes;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A Trakt history remove post, containing all movies, shows, episodes and / or history ids,
    /// which should be removed from the user's history.
    /// </summary>
    public class TraktSyncHistoryRemovePost : TraktSyncHistoryPost
    {
        /// <summary>An optional list of history ids, which should be removed.</summary>
        [JsonProperty(PropertyName = "ids")]
        public IEnumerable<ulong> HistoryIds { get; set; }

        /// <summary>Returns a new <see cref="TraktSyncHistoryRemovePostBuilder" /> instance.</summary>
        /// <returns>A new <see cref="TraktSyncHistoryRemovePostBuilder" /> instance.</returns>
        public static new TraktSyncHistoryRemovePostBuilder Builder() => new TraktSyncHistoryRemovePostBuilder();
    }

    /// <summary>
    /// This is a helper class to build a <see cref="TraktSyncHistoryRemovePost" />.
    /// <para>
    /// It is recommended to use this class to build a history remove post.<para /> 
    /// An instance of this class can be obtained with <see cref="TraktSyncHistoryRemovePost.Builder()" />.
    /// </para>
    /// </summary>
    public class TraktSyncHistoryRemovePostBuilder
    {
        protected TraktSyncHistoryRemovePost _historyPost;

        /// <summary>Initializes a new instance of the <see cref="TraktSyncHistoryRemovePostBuilder" /> class.</summary>
        public TraktSyncHistoryRemovePostBuilder()
        {
            _historyPost = new TraktSyncHistoryRemovePost();
        }

        /// <summary>Adds a <see cref="TraktMovie" />, which will be added to the history remove post.</summary>
        /// <param name="movie">The Trakt movie, which will be added.</param>
        /// <returns>The current <see cref="TraktSyncHistoryRemovePostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given movie is null.
        /// Thrown, if the given movie ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given movie has no valid ids set.
        /// Thrown, if the given movie has an year set, which has more or less than four digits.
        /// </exception>
        public TraktSyncHistoryRemovePostBuilder AddMovie(TraktMovie movie)
        {
            ValidateMovie(movie);
            EnsureMoviesListExists();

            return AddMovieOrIgnore(movie);
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the history remove post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <returns>The current <see cref="TraktSyncHistoryRemovePostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given show is null.
        /// Thrown, if the given show ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given show has no valid ids set.
        /// Thrown, if the given show has an year set, which has more or less than four digits.
        /// </exception>
        public TraktSyncHistoryRemovePostBuilder AddShow(TraktShow show)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            return AddShowOrIgnore(show);
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the history remove post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="season">
        /// A season number for a season in the given show. The complete season will be removed from the history.
        /// </param>
        /// <param name="seasons">
        /// An optional array of season numbers for seasons in the given show.
        /// The complete seasons will be removed from the history.
        /// </param>
        /// <returns>The current <see cref="TraktSyncHistoryRemovePostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given show is null.
        /// Thrown, if the given show ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given show has no valid ids set.
        /// Thrown, if the given show has an year set, which has more or less than four digits.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if at least one of the given season numbers is below zero.
        /// </exception>
        public TraktSyncHistoryRemovePostBuilder AddShow(TraktShow show, int season, params int[] seasons)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(season, seasons);
            CreateOrSetShow(show, showSeasons);

            return this;
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the history remove post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="seasons">
        /// An <see cref="PostHistorySeasons" /> instance, containing season and episode numbers.<para />
        /// If it contains episode numbers, only the episodes with the given episode numbers will be removed from the history.
        /// </param>
        /// <returns>The current <see cref="TraktSyncHistoryRemovePostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given show is null.
        /// Thrown, if the given show ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given show has no valid ids set.
        /// Thrown, if the given show has an year set, which has more or less than four digits.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if at least one of the given season numbers in <paramref name="seasons" /> is below zero.
        /// Thrown, if at least one of the given episode numbers in <paramref name="seasons" /> is below zero.
        /// </exception>
        public TraktSyncHistoryRemovePostBuilder AddShow(TraktShow show, PostHistorySeasons seasons)
        {
            ValidateShow(show);

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(seasons);
            CreateOrSetShow(show, showSeasons);

            return this;
        }

        /// <summary>Adds a <see cref="TraktEpisode" />, which will be added to the history remove post.</summary>
        /// <param name="episode">The Trakt episode, which will be added.</param>
        /// <returns>The current <see cref="TraktSyncHistoryRemovePostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given episode is null.
        /// Thrown, if the given episode ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">Thrown, if the given episode has no valid ids set.</exception>
        public TraktSyncHistoryRemovePostBuilder AddEpisode(TraktEpisode episode)
        {
            ValidateEpisode(episode);
            EnsureEpisodesListExists();

            return AddEpisodeOrIgnore(episode);
        }

        /// <summary>Adds history ids, which will be added to the history remove post.</summary>
        /// <param name="id">A history item id. See also <seealso cref="Get.History.TraktHistoryItem" />.</param>
        /// <param name="ids">An optional array of history item ids. See also <seealso cref="Get.History.TraktHistoryItem" />.</param>
        /// <returns>The current <see cref="TraktSyncHistoryRemovePostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if at least one of the given history ids equals zero.</exception>
        public TraktSyncHistoryRemovePostBuilder AddHistoryIds(ulong id, params ulong[] ids)
        {
            var idsToAdd = new ulong[ids.Length + 1];
            idsToAdd[0] = id;
            ids.CopyTo(idsToAdd, 1);

            if (_historyPost.HistoryIds == null)
                _historyPost.HistoryIds = new List<ulong>();

            for (int i = 0; i < idsToAdd.Length; i++)
            {
                if (idsToAdd[i] == 0)
                    throw new ArgumentOutOfRangeException("at least one history id is not valid");

                (_historyPost.HistoryIds as List<ulong>).Add(idsToAdd[i]);
            }

            return this;
        }

        /// <summary>Removes all already added movies, shows, seasons, episodes and history ids from the builder.</summary>
        public void Reset()
        {
            if (_historyPost.Movies != null)
            {
                (_historyPost.Movies as List<TraktSyncHistoryPostMovie>).Clear();
                _historyPost.Movies = null;
            }

            if (_historyPost.Shows != null)
            {
                (_historyPost.Shows as List<TraktSyncHistoryPostShow>).Clear();
                _historyPost.Shows = null;
            }

            if (_historyPost.Episodes != null)
            {
                (_historyPost.Episodes as List<TraktSyncHistoryPostEpisode>).Clear();
                _historyPost.Episodes = null;
            }

            if (_historyPost.HistoryIds != null)
            {
                (_historyPost.HistoryIds as List<ulong>).Clear();
                _historyPost.HistoryIds = null;
            }
        }

        /// <summary>
        /// Returns an <see cref="TraktSyncHistoryRemovePost" /> instance, which contains all
        /// added movies, shows, seasons and episodes, including watched at UTC datetimes, and history ids,
        /// which should be removed.
        /// </summary>
        /// <returns>An <see cref="TraktSyncHistoryRemovePost" /> instance.</returns>
        public TraktSyncHistoryRemovePost Build() => _historyPost;

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
            => _historyPost.Movies.Where(m => m.Ids == movie.Ids).FirstOrDefault() != null;

        protected void EnsureMoviesListExists()
        {
            if (_historyPost.Movies == null)
                _historyPost.Movies = new List<TraktSyncHistoryPostMovie>();
        }

        protected bool ContainsShow(TraktShow show)
            => _historyPost.Shows.Where(s => s.Ids == show.Ids).FirstOrDefault() != null;

        protected void EnsureShowsListExists()
        {
            if (_historyPost.Shows == null)
                _historyPost.Shows = new List<TraktSyncHistoryPostShow>();
        }

        protected bool ContainsEpisode(TraktEpisode episode)
            => _historyPost.Episodes.Where(e => e.Ids == episode.Ids).FirstOrDefault() != null;

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
            {
                if (seasonsToAdd[i] < 0)
                    throw new ArgumentOutOfRangeException("at least one season number not valid");

                showSeasons.Add(new TraktSyncHistoryPostShowSeason { Number = seasonsToAdd[i] });
            }

            return showSeasons;
        }

        protected IEnumerable<TraktSyncHistoryPostShowSeason> CreateShowSeasons(PostHistorySeasons seasons)
        {
            var showSeasons = new List<TraktSyncHistoryPostShowSeason>();

            foreach (var season in seasons)
            {
                if (season.Number < 0)
                    throw new ArgumentOutOfRangeException("at least one season number not valid", nameof(season));

                var showSingleSeason = new TraktSyncHistoryPostShowSeason { Number = season.Number };

                if (season.WatchedAt.HasValue)
                    showSingleSeason.WatchedAt = season.WatchedAt.Value.ToUniversalTime();

                if (season.Episodes != null && season.Episodes.Count() > 0)
                {
                    var showEpisodes = new List<TraktSyncHistoryPostShowEpisode>();

                    foreach (var episode in season.Episodes)
                    {
                        if (episode.Number < 0)
                            throw new ArgumentOutOfRangeException("at least one episode number not valid", nameof(seasons));

                        var showEpisode = new TraktSyncHistoryPostShowEpisode { Number = episode.Number };

                        if (episode.WatchedAt.HasValue)
                            showEpisode.WatchedAt = episode.WatchedAt.Value.ToUniversalTime();

                        showEpisodes.Add(showEpisode);
                    }

                    showSingleSeason.Episodes = showEpisodes;
                }

                showSeasons.Add(showSingleSeason);
            }

            return showSeasons;
        }
    }
}
