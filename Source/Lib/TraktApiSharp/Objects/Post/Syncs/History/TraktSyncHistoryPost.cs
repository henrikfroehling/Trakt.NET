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
    /// A Trakt history post, containing all movies, shows and / or episodes,
    /// which should be added to the user's history.
    /// </summary>
    public class TraktSyncHistoryPost
    {
        /// <summary>
        /// An optional list of <see cref="TraktSyncHistoryPostMovie" />s.
        /// <para>Each <see cref="TraktSyncHistoryPostMovie" /> must have at least a valid Trakt id.</para>
        /// </summary>
        [JsonProperty(PropertyName = "movies")]
        public IEnumerable<TraktSyncHistoryPostMovie> Movies { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncHistoryPostShow" />s.
        /// <para>Each <see cref="TraktSyncHistoryPostShow" /> must have at least a valid Trakt id.</para>
        /// </summary>
        [JsonProperty(PropertyName = "shows")]
        public IEnumerable<TraktSyncHistoryPostShow> Shows { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncHistoryPostEpisode" />s.
        /// <para>Each <see cref="TraktSyncHistoryPostEpisode" /> must have at least a valid Trakt id.</para>
        /// </summary>
        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktSyncHistoryPostEpisode> Episodes { get; set; }

        /// <summary>Returns a new <see cref="TraktSyncHistoryPostBuilder" /> instance.</summary>
        /// <returns>A new <see cref="TraktSyncHistoryPostBuilder" /> instance.</returns>
        public static TraktSyncHistoryPostBuilder Builder() => new TraktSyncHistoryPostBuilder();
    }

    /// <summary>
    /// This is a helper class to build a <see cref="TraktSyncHistoryPost" />.
    /// <para>
    /// It is recommended to use this class to build a history post.<para /> 
    /// An instance of this class can be obtained with <see cref="TraktSyncHistoryPost.Builder()" />.
    /// </para>
    /// </summary>
    public class TraktSyncHistoryPostBuilder
    {
        private TraktSyncHistoryPost _historyPost;

        /// <summary>Initializes a new instance of the <see cref="TraktSyncHistoryPostBuilder" /> class.</summary>
        public TraktSyncHistoryPostBuilder()
        {
            _historyPost = new TraktSyncHistoryPost();
        }

        /// <summary>Adds a <see cref="TraktMovie" />, which will be added to the history post.</summary>
        /// <param name="movie">The Trakt movie, which will be added.</param>
        /// <returns>The current <see cref="TraktSyncHistoryPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given movie is null.
        /// Thrown, if the given movie ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given movie has no valid ids set.
        /// Thrown, if the given movie has an year set, which has more or less than four digits.
        /// </exception>
        public TraktSyncHistoryPostBuilder AddMovie(TraktMovie movie)
        {
            ValidateMovie(movie);
            EnsureMoviesListExists();

            return AddMovieOrIgnore(movie);
        }

        /// <summary>Adds a <see cref="TraktMovie" />, which will be added to the history post.</summary>
        /// <param name="movie">The Trakt movie, which will be added.</param>
        /// <param name="watchedAt">The datetime, when the given movie was watched. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <returns>The current <see cref="TraktSyncHistoryPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given movie is null.
        /// Thrown, if the given movie ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given movie has no valid ids set.
        /// Thrown, if the given movie has an year set, which has more or less than four digits.
        /// </exception>
        public TraktSyncHistoryPostBuilder AddMovie(TraktMovie movie, DateTime watchedAt)
        {
            ValidateMovie(movie);
            EnsureMoviesListExists();

            return AddMovieOrIgnore(movie, watchedAt);
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the history post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <returns>The current <see cref="TraktSyncHistoryPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given show is null.
        /// Thrown, if the given show ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given show has no valid ids set.
        /// Thrown, if the given show has an year set, which has more or less than four digits.
        /// </exception>
        public TraktSyncHistoryPostBuilder AddShow(TraktShow show)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            return AddShowOrIgnore(show);
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the history post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="watchedAt">The datetime, when the given show was watched. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <returns>The current <see cref="TraktSyncHistoryPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given show is null.
        /// Thrown, if the given show ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given show has no valid ids set.
        /// Thrown, if the given show has an year set, which has more or less than four digits.
        /// </exception>
        public TraktSyncHistoryPostBuilder AddShow(TraktShow show, DateTime watchedAt)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            return AddShowOrIgnore(show, watchedAt);
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the history post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="season">
        /// A season number for a season in the given show. The complete season will be added to the history.
        /// </param>
        /// <param name="seasons">
        /// An optional array of season numbers for seasons in the given show.
        /// The complete seasons will be added to the history.
        /// </param>
        /// <returns>The current <see cref="TraktSyncHistoryPostBuilder" /> instance.</returns>
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
        public TraktSyncHistoryPostBuilder AddShow(TraktShow show, int season, params int[] seasons)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(season, seasons);
            CreateOrSetShow(show, showSeasons);

            return this;
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the history post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="seasons">
        /// An array of season numbers for seasons in the given show.
        /// The complete seasons will be added to the history.
        /// </param>
        /// <returns>The current <see cref="TraktSyncHistoryPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given show is null.
        /// Thrown, if the given show ids are null.
        /// Thrown, if the given seasons array is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given show has no valid ids set.
        /// Thrown, if the given show has an year set, which has more or less than four digits.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if at least one of the given season numbers is below zero.
        /// </exception>
        public TraktSyncHistoryPostBuilder AddShow(TraktShow show, int[] seasons)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(seasons);
            CreateOrSetShow(show, showSeasons);

            return this;
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the history post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="watchedAt">The datetime, when the given show was watched. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <param name="season">
        /// A season number for a season in the given show. The complete season will be added to the history.
        /// </param>
        /// <param name="seasons">
        /// An optional array of season numbers for seasons in the given show.
        /// The complete seasons will be added to the history.
        /// </param>
        /// <returns>The current <see cref="TraktSyncHistoryPostBuilder" /> instance.</returns>
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
        public TraktSyncHistoryPostBuilder AddShow(TraktShow show, DateTime watchedAt, int season, params int[] seasons)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(season, seasons);
            CreateOrSetShow(show, showSeasons, watchedAt);

            return this;
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the history post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="watchedAt">The datetime, when the given show was watched. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <param name="seasons">
        /// An array of season numbers for seasons in the given show.
        /// The complete seasons will be added to the history.
        /// </param>
        /// <returns>The current <see cref="TraktSyncHistoryPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given show is null.
        /// Thrown, if the given show ids are null.
        /// Thrown, if the given seasons array is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given show has no valid ids set.
        /// Thrown, if the given show has an year set, which has more or less than four digits.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if at least one of the given season numbers is below zero.
        /// </exception>
        public TraktSyncHistoryPostBuilder AddShow(TraktShow show, DateTime watchedAt, int[] seasons)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(seasons);
            CreateOrSetShow(show, showSeasons, watchedAt);

            return this;
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the history post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="seasons">
        /// An <see cref="PostHistorySeasons" /> instance, containing season and episode numbers.<para />
        /// If it contains episode numbers, only the episodes with the given episode numbers will be added to the history.
        /// </param>
        /// <returns>The current <see cref="TraktSyncHistoryPostBuilder" /> instance.</returns>
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
        public TraktSyncHistoryPostBuilder AddShow(TraktShow show, PostHistorySeasons seasons)
        {
            ValidateShow(show);

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(seasons);
            CreateOrSetShow(show, showSeasons);

            return this;
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the history post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="watchedAt">The datetime, when the given show was watched. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <param name="seasons">
        /// An <see cref="PostHistorySeasons" /> instance, containing season and episode numbers.<para />
        /// If it contains episode numbers, only the episodes with the given episode numbers will be added to the history.
        /// </param>
        /// <returns>The current <see cref="TraktSyncHistoryPostBuilder" /> instance.</returns>
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
        public TraktSyncHistoryPostBuilder AddShow(TraktShow show, DateTime watchedAt, PostHistorySeasons seasons)
        {
            ValidateShow(show);

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(seasons);
            CreateOrSetShow(show, showSeasons, watchedAt);

            return this;
        }

        /// <summary>Adds a <see cref="TraktEpisode" />, which will be added to the history post.</summary>
        /// <param name="episode">The Trakt episode, which will be added.</param>
        /// <returns>The current <see cref="TraktSyncHistoryPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given episode is null.
        /// Thrown, if the given episode ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">Thrown, if the given episode has no valid ids set.</exception>
        public TraktSyncHistoryPostBuilder AddEpisode(TraktEpisode episode)
        {
            ValidateEpisode(episode);
            EnsureEpisodesListExists();

            return AddEpisodeOrIgnore(episode);
        }

        /// <summary>Adds a <see cref="TraktEpisode" />, which will be added to the history post.</summary>
        /// <param name="episode">The Trakt episode, which will be added.</param>
        /// <param name="watchedAt">The datetime, when the given episode was watched. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <returns>The current <see cref="TraktSyncHistoryPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given episode is null.
        /// Thrown, if the given episode ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">Thrown, if the given episode has no valid ids set.</exception>
        public TraktSyncHistoryPostBuilder AddEpisode(TraktEpisode episode, DateTime watchedAt)
        {
            ValidateEpisode(episode);
            EnsureEpisodesListExists();

            return AddEpisodeOrIgnore(episode, watchedAt) as TraktSyncHistoryPostBuilder;
        }

        /// <summary>Removes all already added movies, shows, seasons and episodes from the builder.</summary>
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
        }

        /// <summary>
        /// Returns an <see cref="TraktSyncHistoryPost" /> instance, which contains all
        /// added movies, shows, seasons and episodes, including watched at UTC datetimes.
        /// </summary>
        /// <returns>An <see cref="TraktSyncHistoryPost" /> instance.</returns>
        public TraktSyncHistoryPost Build() => _historyPost;

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

        protected TraktSyncHistoryPostBuilder AddMovieOrIgnore(TraktMovie movie, DateTime? watchedAt = null)
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

        protected TraktSyncHistoryPostBuilder AddShowOrIgnore(TraktShow show, DateTime? watchedAt = null)
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

        protected TraktSyncHistoryPostBuilder AddEpisodeOrIgnore(TraktEpisode episode, DateTime? watchedAt = null)
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

        protected IEnumerable<TraktSyncHistoryPostShowSeason> CreateShowSeasons(int[] seasons)
        {
            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            var showSeasons = new List<TraktSyncHistoryPostShowSeason>();

            for (int i = 0; i < seasons.Length; i++)
            {
                if (seasons[i] < 0)
                    throw new ArgumentOutOfRangeException("at least one season number not valid");

                showSeasons.Add(new TraktSyncHistoryPostShowSeason { Number = seasons[i] });
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
