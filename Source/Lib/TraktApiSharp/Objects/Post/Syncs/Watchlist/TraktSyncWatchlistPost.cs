namespace TraktApiSharp.Objects.Post.Syncs.Watchlist
{
    using Get.Movies;
    using Get.Shows;
    using Get.Shows.Episodes;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A Trakt watchlist post, containing all movies, shows and / or episodes,
    /// which should be added to the user's watchlist.
    /// </summary>
    public class TraktSyncWatchlistPost
    {
        /// <summary>
        /// An optional list of <see cref="TraktSyncWatchlistPostMovie" />s.
        /// <para>Each <see cref="TraktSyncWatchlistPostMovie" /> must have at least a valid Trakt id.</para>
        /// </summary>
        [JsonProperty(PropertyName = "movies")]
        public IEnumerable<TraktSyncWatchlistPostMovie> Movies { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncWatchlistPostShow" />s.
        /// <para>Each <see cref="TraktSyncWatchlistPostShow" /> must have at least a valid Trakt id.</para>
        /// </summary>
        [JsonProperty(PropertyName = "shows")]
        public IEnumerable<TraktSyncWatchlistPostShow> Shows { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncWatchlistPostEpisode" />s.
        /// <para>Each <see cref="TraktSyncWatchlistPostEpisode" /> must have at least a valid Trakt id.</para>
        /// </summary>
        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktSyncWatchlistPostEpisode> Episodes { get; set; }

        /// <summary>Returns a new <see cref="TraktSyncWatchlistPostBuilder" /> instance.</summary>
        /// <returns>A new <see cref="TraktSyncWatchlistPostBuilder" /> instance.</returns>
        public static TraktSyncWatchlistPostBuilder Builder() => new TraktSyncWatchlistPostBuilder();
    }

    /// <summary>
    /// This is a helper class to build a <see cref="TraktSyncWatchlistPost" />.
    /// <para>
    /// It is recommended to use this class to build a watchlist post.<para /> 
    /// An instance of this class can be obtained with <see cref="TraktSyncWatchlistPost.Builder()" />.
    /// </para>
    /// </summary>
    public class TraktSyncWatchlistPostBuilder
    {
        private TraktSyncWatchlistPost _watchlistPost;

        /// <summary>Initializes a new instance of the <see cref="TraktSyncWatchlistPostBuilder" /> class.</summary>
        public TraktSyncWatchlistPostBuilder()
        {
            _watchlistPost = new TraktSyncWatchlistPost();
        }

        /// <summary>Adds a <see cref="TraktMovie" />, which will be added to the watchlist post.</summary>
        /// <param name="movie">The Trakt movie, which will be added.</param>
        /// <returns>The current <see cref="TraktSyncWatchlistPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given movie is null.
        /// Thrown, if the given movie ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given movie has no valid ids set.
        /// Thrown, if the given movie has an year set, which has more or less than four digits.
        /// </exception>
        public TraktSyncWatchlistPostBuilder AddMovie(TraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            if (movie.Ids == null)
                throw new ArgumentNullException(nameof(movie.Ids));

            if (!movie.Ids.HasAnyId)
                throw new ArgumentException("no movie ids set or valid", nameof(movie.Ids));

            if (movie.Year.HasValue && movie.Year.Value.ToString().Length != 4)
                throw new ArgumentException("movie year not valid", nameof(movie.Year));

            EnsureMoviesListExists();

            var existingMovie = _watchlistPost.Movies.Where(m => m.Ids == movie.Ids).FirstOrDefault();

            if (existingMovie != null)
                return this;

            (_watchlistPost.Movies as List<TraktSyncWatchlistPostMovie>).Add(
                new TraktSyncWatchlistPostMovie
                {
                    Ids = movie.Ids,
                    Title = movie.Title,
                    Year = movie.Year
                });

            return this;
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the watchlist post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <returns>The current <see cref="TraktSyncWatchlistPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given show is null.
        /// Thrown, if the given show ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given show has no valid ids set.
        /// Thrown, if the given show has an year set, which has more or less than four digits.
        /// </exception>
        public TraktSyncWatchlistPostBuilder AddShow(TraktShow show)
        {
            ValidateShow(show);

            EnsureShowsListExists();

            var existingShow = _watchlistPost.Shows.Where(s => s.Ids == show.Ids).FirstOrDefault();

            if (existingShow != null)
                return this;

            (_watchlistPost.Shows as List<TraktSyncWatchlistPostShow>).Add(
                new TraktSyncWatchlistPostShow
                {
                    Ids = show.Ids,
                    Title = show.Title,
                    Year = show.Year
                });

            return this;
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the watchlist post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="season">
        /// A season number for a season in the given show. The complete season will be added to the watchlist.
        /// </param>
        /// <param name="seasons">
        /// An optional array of season numbers for seasons in the given show.
        /// The complete seasons will be added to the watchlist.
        /// </param>
        /// <returns>The current <see cref="TraktSyncWatchlistPostBuilder" /> instance.</returns>
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
        public TraktSyncWatchlistPostBuilder AddShow(TraktShow show, int season, params int[] seasons)
        {
            ValidateShow(show);

            EnsureShowsListExists();

            var seasonsToAdd = new int[seasons.Length + 1];
            seasonsToAdd[0] = season;
            seasons.CopyTo(seasonsToAdd, 1);

            var showSeasons = new List<TraktSyncWatchlistPostShowSeason>();

            for (int i = 0; i < seasonsToAdd.Length; i++)
            {
                if (seasonsToAdd[i] < 0)
                    throw new ArgumentOutOfRangeException("at least one season number not valid");

                showSeasons.Add(new TraktSyncWatchlistPostShowSeason { Number = seasonsToAdd[i] });
            }

            var existingShow = _watchlistPost.Shows.Where(s => s.Ids == show.Ids).FirstOrDefault();

            if (existingShow != null)
                existingShow.Seasons = showSeasons;
            else
            {
                var watchlistShow = new TraktSyncWatchlistPostShow();
                watchlistShow.Ids = show.Ids;
                watchlistShow.Title = show.Title;
                watchlistShow.Year = show.Year;

                watchlistShow.Seasons = showSeasons;
                (_watchlistPost.Shows as List<TraktSyncWatchlistPostShow>).Add(watchlistShow);
            }

            return this;
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the watchlist post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="seasons">
        /// An <see cref="PostSeasons" /> instance, containing season and episode numbers.<para />
        /// If it contains episode numbers, only the episodes with the given episode numbers will be added to the watchlist.
        /// </param>
        /// <returns>The current <see cref="TraktSyncWatchlistPostBuilder" /> instance.</returns>
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
        public TraktSyncWatchlistPostBuilder AddShow(TraktShow show, PostSeasons seasons)
        {
            ValidateShow(show);

            EnsureShowsListExists();

            if (_watchlistPost.Shows == null)
                _watchlistPost.Shows = new List<TraktSyncWatchlistPostShow>();

            List<TraktSyncWatchlistPostShowSeason> showSeasons = null;

            if (seasons.Count() > 0)
            {
                showSeasons = new List<TraktSyncWatchlistPostShowSeason>();

                foreach (var season in seasons)
                {
                    if (season.Number < 0)
                        throw new ArgumentOutOfRangeException("at least one season number not valid", nameof(season));

                    var showSingleSeason = new TraktSyncWatchlistPostShowSeason { Number = season.Number };

                    if (season.Episodes != null && season.Episodes.Count() > 0)
                    {
                        var showEpisodes = new List<TraktSyncWatchlistPostShowEpisode>();

                        foreach (var episode in season.Episodes)
                        {
                            if (episode < 0)
                                throw new ArgumentOutOfRangeException("at least one episode number not valid", nameof(seasons));

                            showEpisodes.Add(new TraktSyncWatchlistPostShowEpisode { Number = episode });
                        }

                        showSingleSeason.Episodes = showEpisodes;
                    }

                    showSeasons.Add(showSingleSeason);
                }
            }

            var existingShow = _watchlistPost.Shows.Where(s => s.Ids == show.Ids).FirstOrDefault();

            if (existingShow != null)
                existingShow.Seasons = showSeasons;
            else
            {
                var watchlistShow = new TraktSyncWatchlistPostShow();
                watchlistShow.Ids = show.Ids;
                watchlistShow.Title = show.Title;
                watchlistShow.Year = show.Year;

                watchlistShow.Seasons = showSeasons;
                (_watchlistPost.Shows as List<TraktSyncWatchlistPostShow>).Add(watchlistShow);
            }

            return this;
        }

        /// <summary>Adds a <see cref="TraktEpisode" />, which will be added to the watchlist post.</summary>
        /// <param name="episode">The Trakt episode, which will be added.</param>
        /// <returns>The current <see cref="TraktSyncWatchlistPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given episode is null.
        /// Thrown, if the given episode ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">Thrown, if the given episode has no valid ids set.</exception>
        public TraktSyncWatchlistPostBuilder AddEpisode(TraktEpisode episode)
        {
            if (episode == null)
                throw new ArgumentNullException(nameof(episode));

            if (episode.Ids == null)
                throw new ArgumentNullException(nameof(episode.Ids));

            if (!episode.Ids.HasAnyId)
                throw new ArgumentException("no episode ids set or valid", nameof(episode.Ids));

            EnsureEpisodesListExists();

            var existingEpisode = _watchlistPost.Episodes.Where(e => e.Ids == episode.Ids).FirstOrDefault();

            if (existingEpisode != null)
                return this;

            (_watchlistPost.Episodes as List<TraktSyncWatchlistPostEpisode>).Add(
                new TraktSyncWatchlistPostEpisode
                {
                    Ids = episode.Ids
                });

            return this;
        }

        /// <summary>Removes all already added movies, shows, seasons and episodes.</summary>
        public void Reset()
        {
            if (_watchlistPost.Movies != null)
            {
                (_watchlistPost.Movies as List<TraktSyncWatchlistPostMovie>).Clear();
                _watchlistPost.Movies = null;
            }

            if (_watchlistPost.Shows != null)
            {
                (_watchlistPost.Shows as List<TraktSyncWatchlistPostShow>).Clear();
                _watchlistPost.Shows = null;
            }

            if (_watchlistPost.Episodes != null)
            {
                (_watchlistPost.Episodes as List<TraktSyncWatchlistPostEpisode>).Clear();
                _watchlistPost.Episodes = null;
            }
        }

        /// <summary>
        /// Returns an <see cref="TraktSyncWatchlistPost" /> instance, which contains all
        /// added movies, shows, seasons and episodes.
        /// </summary>
        /// <returns>An <see cref="TraktSyncWatchlistPost" /> instance.</returns>
        public TraktSyncWatchlistPost Build()
        {
            return _watchlistPost;
        }

        private void ValidateShow(TraktShow show)
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

        private void EnsureMoviesListExists()
        {
            if (_watchlistPost.Movies == null)
                _watchlistPost.Movies = new List<TraktSyncWatchlistPostMovie>();
        }

        private void EnsureShowsListExists()
        {
            if (_watchlistPost.Shows == null)
                _watchlistPost.Shows = new List<TraktSyncWatchlistPostShow>();
        }

        private void EnsureEpisodesListExists()
        {
            if (_watchlistPost.Episodes == null)
                _watchlistPost.Episodes = new List<TraktSyncWatchlistPostEpisode>();
        }
    }
}
