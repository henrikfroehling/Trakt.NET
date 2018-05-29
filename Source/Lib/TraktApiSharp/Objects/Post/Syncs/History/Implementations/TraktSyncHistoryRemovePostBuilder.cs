namespace TraktApiSharp.Objects.Post.Syncs.History
{
    using Get.History;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Shows;

    /// <summary>
    /// This is a helper class to build a <see cref="ITraktSyncHistoryRemovePost" />.
    /// <para>
    /// It is recommended to use this class to build a history remove post.<para /> 
    /// An instance of this class can be obtained with <see cref="TraktSyncHistoryRemovePost.Builder()" />.
    /// </para>
    /// </summary>
    public class TraktSyncHistoryRemovePostBuilder
    {
        private readonly ITraktSyncHistoryRemovePost _historyPost;

        /// <summary>Initializes a new instance of the <see cref="TraktSyncHistoryRemovePostBuilder" /> class.</summary>
        public TraktSyncHistoryRemovePostBuilder()
        {
            _historyPost = new TraktSyncHistoryRemovePost();
        }

        /// <summary>Adds a <see cref="ITraktMovie" />, which will be added to the history remove post.</summary>
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
        public TraktSyncHistoryRemovePostBuilder AddMovie(ITraktMovie movie)
        {
            ValidateMovie(movie);
            EnsureMoviesListExists();

            return AddMovieOrIgnore(movie);
        }

        /// <summary>Adds a collection of <see cref="ITraktMovie" />s, which will be added to the history remove post.</summary>
        /// <param name="movies">A collection of Trakt movies, which will be added.</param>
        /// <returns>The current <see cref="TraktSyncHistoryRemovePostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given movies collection is null.
        /// Thrown, if one of the given movies is null.
        /// Thrown, if one of the given movies' ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if one of the given movies has no valid ids set.
        /// Thrown, if one of the given movies has an year set, which has more or less than four digits.
        /// </exception>
        public TraktSyncHistoryRemovePostBuilder AddMovies(IEnumerable<ITraktMovie> movies)
        {
            if (movies == null)
                throw new ArgumentNullException(nameof(movies));

            if (!movies.Any())
                return this;

            foreach (var movie in movies)
                AddMovie(movie);

            return this;
        }

        /// <summary>Adds a <see cref="ITraktShow" />, which will be added to the history remove post.</summary>
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
        public TraktSyncHistoryRemovePostBuilder AddShow(ITraktShow show)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            return AddShowOrIgnore(show);
        }

        /// <summary>Adds a collection of <see cref="ITraktShow" />s, which will be added to the history remove post.</summary>
        /// <param name="shows">A collection of Trakt shows, which will be added.</param>
        /// <returns>The current <see cref="TraktSyncHistoryRemovePostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given shows collection is null.
        /// Thrown, if one of the given shows is null.
        /// Thrown, if one of the given shows' ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if one of the given shows has no valid ids set.
        /// Thrown, if one of the given shows has an year set, which has more or less than four digits.
        /// </exception>
        public TraktSyncHistoryRemovePostBuilder AddShows(IEnumerable<ITraktShow> shows)
        {
            if (shows == null)
                throw new ArgumentNullException(nameof(shows));

            if (!shows.Any())
                return this;

            foreach (var show in shows)
                AddShow(show);

            return this;
        }

        /// <summary>Adds a <see cref="ITraktShow" />, which will be added to the history remove post.</summary>
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
        public TraktSyncHistoryRemovePostBuilder AddShow(ITraktShow show, int season, params int[] seasons)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(season, seasons);
            CreateOrSetShow(show, showSeasons);

            return this;
        }

        /// <summary>Adds a <see cref="ITraktShow" />, which will be added to the history remove post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="seasons">
        /// An array of season numbers for seasons in the given show.
        /// All seasons numbers will be removed from the history.
        /// </param>
        /// <returns>The current <see cref="TraktSyncHistoryRemovePostBuilder" /> instance.</returns>
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
        public TraktSyncHistoryRemovePostBuilder AddShow(ITraktShow show, int[] seasons)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(seasons);
            CreateOrSetShow(show, showSeasons);

            return this;
        }

        /// <summary>Adds a <see cref="ITraktShow" />, which will be added to the history remove post.</summary>
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
        public TraktSyncHistoryRemovePostBuilder AddShow(ITraktShow show, PostHistorySeasons seasons)
        {
            ValidateShow(show);

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(seasons);
            CreateOrSetShow(show, showSeasons);

            return this;
        }

        /// <summary>Adds a <see cref="ITraktEpisode" />, which will be added to the history remove post.</summary>
        /// <param name="episode">The Trakt episode, which will be added.</param>
        /// <returns>The current <see cref="TraktSyncHistoryRemovePostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given episode is null.
        /// Thrown, if the given episode ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">Thrown, if the given episode has no valid ids set.</exception>
        public TraktSyncHistoryRemovePostBuilder AddEpisode(ITraktEpisode episode)
        {
            ValidateEpisode(episode);
            EnsureEpisodesListExists();

            return AddEpisodeOrIgnore(episode);
        }

        /// <summary>Adds a collection of <see cref="ITraktEpisode" />s, which will be added to the history remove post.</summary>
        /// <param name="episodes">A collection of Trakt episodes, which will be added.</param>
        /// <returns>The current <see cref="TraktSyncHistoryRemovePostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given episodes collection is null.
        /// Thrown, if one of the given episodes is null.
        /// Thrown, if one of the given episodes' ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">Thrown, if one of the given episodes has no valid ids set.</exception>
        public TraktSyncHistoryRemovePostBuilder AddEpisodes(IEnumerable<ITraktEpisode> episodes)
        {
            if (episodes == null)
                throw new ArgumentNullException(nameof(episodes));

            if (!episodes.Any())
                return this;

            foreach (var episode in episodes)
                AddEpisode(episode);

            return this;
        }

        /// <summary>Adds history ids, which will be added to the history remove post.</summary>
        /// <param name="id">A history item id. See also <seealso cref="ITraktHistoryItem" />.</param>
        /// <param name="ids">An optional array of history item ids. See also <seealso cref="ITraktHistoryItem" />.</param>
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

                (_historyPost.HistoryIds as List<ulong>)?.Add(idsToAdd[i]);
            }

            return this;
        }

        /// <summary>Adds history ids, which will be added to the history remove post.</summary>
        /// <param name="ids">An array of history item ids. See also <seealso cref="ITraktHistoryItem" />.</param>
        /// <returns>The current <see cref="TraktSyncHistoryRemovePostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given ids array is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if at least one of the given history ids equals zero.</exception>
        public TraktSyncHistoryRemovePostBuilder AddHistoryIds(ulong[] ids)
        {
            if (ids == null)
                throw new ArgumentNullException(nameof(ids));

            if (ids.Length == 0)
                return this;

            if (_historyPost.HistoryIds == null)
                _historyPost.HistoryIds = new List<ulong>();

            for (int i = 0; i < ids.Length; i++)
            {
                if (ids[i] == 0)
                    throw new ArgumentOutOfRangeException("at least one history id is not valid");

                (_historyPost.HistoryIds as List<ulong>)?.Add(ids[i]);
            }

            return this;
        }

        /// <summary>Removes all already added movies, shows, seasons, episodes and history ids from the builder.</summary>
        public void Reset()
        {
            if (_historyPost.Movies != null)
            {
                (_historyPost.Movies as List<ITraktSyncHistoryPostMovie>)?.Clear();
                _historyPost.Movies = null;
            }

            if (_historyPost.Shows != null)
            {
                (_historyPost.Shows as List<ITraktSyncHistoryPostShow>)?.Clear();
                _historyPost.Shows = null;
            }

            if (_historyPost.Episodes != null)
            {
                (_historyPost.Episodes as List<ITraktSyncHistoryPostEpisode>)?.Clear();
                _historyPost.Episodes = null;
            }

            if (_historyPost.HistoryIds != null)
            {
                (_historyPost.HistoryIds as List<ulong>)?.Clear();
                _historyPost.HistoryIds = null;
            }
        }

        /// <summary>
        /// Returns an <see cref="ITraktSyncHistoryRemovePost" /> instance, which contains all
        /// added movies, shows, seasons and episodes, including watched at UTC datetimes, and history ids,
        /// which should be removed.
        /// </summary>
        /// <returns>An <see cref="ITraktSyncHistoryRemovePost" /> instance.</returns>
        public ITraktSyncHistoryRemovePost Build() => _historyPost;

        protected void ValidateMovie(ITraktMovie movie)
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

        protected void ValidateShow(ITraktShow show)
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

        protected void ValidateEpisode(ITraktEpisode episode)
        {
            if (episode == null)
                throw new ArgumentNullException(nameof(episode));

            if (episode.Ids == null)
                throw new ArgumentNullException(nameof(episode.Ids));

            if (!episode.Ids.HasAnyId)
                throw new ArgumentException("no episode ids set or valid", nameof(episode.Ids));
        }

        protected bool ContainsMovie(ITraktMovie movie)
            => _historyPost.Movies.FirstOrDefault(m => m.Ids == movie.Ids) != null;

        protected void EnsureMoviesListExists()
        {
            if (_historyPost.Movies == null)
                _historyPost.Movies = new List<ITraktSyncHistoryPostMovie>();
        }

        protected bool ContainsShow(ITraktShow show)
            => _historyPost.Shows.FirstOrDefault(s => s.Ids == show.Ids) != null;

        protected void EnsureShowsListExists()
        {
            if (_historyPost.Shows == null)
                _historyPost.Shows = new List<ITraktSyncHistoryPostShow>();
        }

        protected bool ContainsEpisode(ITraktEpisode episode)
            => _historyPost.Episodes.FirstOrDefault(e => e.Ids == episode.Ids) != null;

        protected void EnsureEpisodesListExists()
        {
            if (_historyPost.Episodes == null)
                _historyPost.Episodes = new List<ITraktSyncHistoryPostEpisode>();
        }

        protected TraktSyncHistoryRemovePostBuilder AddMovieOrIgnore(ITraktMovie movie)
        {
            if (ContainsMovie(movie))
                return this;

            var historyMovie = new TraktSyncHistoryPostMovie
            {
                Ids = movie.Ids,
                Title = movie.Title,
                Year = movie.Year
            };

            (_historyPost.Movies as List<ITraktSyncHistoryPostMovie>)?.Add(historyMovie);

            return this;
        }

        protected TraktSyncHistoryRemovePostBuilder AddShowOrIgnore(ITraktShow show)
        {
            if (ContainsShow(show))
                return this;

            var historyShow = new TraktSyncHistoryPostShow
            {
                Ids = show.Ids,
                Title = show.Title,
                Year = show.Year
            };

            (_historyPost.Shows as List<ITraktSyncHistoryPostShow>)?.Add(historyShow);

            return this;
        }

        protected TraktSyncHistoryRemovePostBuilder AddEpisodeOrIgnore(ITraktEpisode episode)
        {
            if (ContainsEpisode(episode))
                return this;

            var historyEpisode = new TraktSyncHistoryPostEpisode
            {
                Ids = episode.Ids
            };

            (_historyPost.Episodes as List<ITraktSyncHistoryPostEpisode>)?.Add(historyEpisode);
            return this;
        }

        protected void CreateOrSetShow(ITraktShow show, IEnumerable<ITraktSyncHistoryPostShowSeason> showSeasons)
        {
            var existingShow = _historyPost.Shows.FirstOrDefault(s => s.Ids == show.Ids);

            if (existingShow != null)
            {
                existingShow.Seasons = showSeasons;
            }
            else
            {
                var historyShow = new TraktSyncHistoryPostShow
                {
                    Ids = show.Ids,
                    Title = show.Title,
                    Year = show.Year,

                    Seasons = showSeasons
                };

                (_historyPost.Shows as List<ITraktSyncHistoryPostShow>)?.Add(historyShow);
            }
        }

        protected IEnumerable<ITraktSyncHistoryPostShowSeason> CreateShowSeasons(int season, params int[] seasons)
        {
            var seasonsToAdd = new int[seasons.Length + 1];
            seasonsToAdd[0] = season;
            seasons.CopyTo(seasonsToAdd, 1);

            var showSeasons = new List<ITraktSyncHistoryPostShowSeason>();

            for (int i = 0; i < seasonsToAdd.Length; i++)
            {
                if (seasonsToAdd[i] < 0)
                    throw new ArgumentOutOfRangeException("at least one season number not valid");

                showSeasons.Add(new TraktSyncHistoryPostShowSeason { Number = seasonsToAdd[i] });
            }

            return showSeasons;
        }

        protected IEnumerable<ITraktSyncHistoryPostShowSeason> CreateShowSeasons(int[] seasons)
        {
            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            var showSeasons = new List<ITraktSyncHistoryPostShowSeason>();

            for (int i = 0; i < seasons.Length; i++)
            {
                if (seasons[i] < 0)
                    throw new ArgumentOutOfRangeException("at least one season number not valid");

                showSeasons.Add(new TraktSyncHistoryPostShowSeason { Number = seasons[i] });
            }

            return showSeasons;
        }

        protected IEnumerable<ITraktSyncHistoryPostShowSeason> CreateShowSeasons(PostHistorySeasons seasons)
        {
            var showSeasons = new List<ITraktSyncHistoryPostShowSeason>();

            foreach (var season in seasons)
            {
                if (season.Number < 0)
                    throw new ArgumentOutOfRangeException("at least one season number not valid", nameof(season));

                var showSingleSeason = new TraktSyncHistoryPostShowSeason { Number = season.Number };

                if (season.Episodes?.Count() > 0)
                {
                    var showEpisodes = new List<ITraktSyncHistoryPostShowEpisode>();

                    foreach (var episode in season.Episodes)
                    {
                        if (episode.Number < 0)
                            throw new ArgumentOutOfRangeException("at least one episode number not valid", nameof(seasons));

                        var showEpisode = new TraktSyncHistoryPostShowEpisode { Number = episode.Number };

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
