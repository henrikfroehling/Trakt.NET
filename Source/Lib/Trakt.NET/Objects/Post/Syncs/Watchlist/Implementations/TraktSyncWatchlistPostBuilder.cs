namespace TraktNet.Objects.Post.Syncs.Watchlist
{
    using Get.Episodes;
    using Get.Movies;
    using Get.Shows;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// This is a helper class to build a <see cref="ITraktSyncWatchlistPost" />.
    /// <para>
    /// It is recommended to use this class to build a watchlist post.<para /> 
    /// An instance of this class can be obtained with <see cref="TraktSyncWatchlistPost.Builder()" />.
    /// </para>
    /// </summary>
    public class TraktSyncWatchlistPostBuilder
    {
        private readonly ITraktSyncWatchlistPost _watchlistPost;

        /// <summary>Initializes a new instance of the <see cref="TraktSyncWatchlistPostBuilder" /> class.</summary>
        public TraktSyncWatchlistPostBuilder()
        {
            _watchlistPost = new TraktSyncWatchlistPost();
        }

        /// <summary>Adds a <see cref="ITraktMovie" />, which will be added to the watchlist post.</summary>
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
        public TraktSyncWatchlistPostBuilder AddMovie(ITraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            if (movie.Ids == null)
                throw new ArgumentNullException(nameof(movie.Ids));

            if (!movie.Ids.HasAnyId)
                throw new ArgumentException("no movie ids set or valid", nameof(movie.Ids));

            if (!movie.Year.HasValue)
                throw new ArgumentException("movie year not valid", nameof(movie.Year));

            EnsureMoviesListExists();

            var existingMovie = _watchlistPost.Movies.FirstOrDefault(m => m.Ids == movie.Ids);

            if (existingMovie != null)
                return this;

            (_watchlistPost.Movies as List<ITraktSyncWatchlistPostMovie>)?.Add(
                new TraktSyncWatchlistPostMovie
                {
                    Ids = movie.Ids,
                    Title = movie.Title,
                    Year = movie.Year
                });

            return this;
        }

        /// <summary>Adds a collection of <see cref="ITraktMovie" />s, which will be added to the watchlist post.</summary>
        /// <param name="movies">A collection of Trakt movies, which will be added.</param>
        /// <returns>The current <see cref="TraktSyncWatchlistPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given movies collection is null.
        /// Thrown, if one of the given movies is null.
        /// Thrown, if one of the given movies' ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if one of the given movies has no valid ids set.
        /// Thrown, if one of the given movies has an year set, which has more or less than four digits.
        /// </exception>
        public TraktSyncWatchlistPostBuilder AddMovies(IEnumerable<ITraktMovie> movies)
        {
            if (movies == null)
                throw new ArgumentNullException(nameof(movies));

            if (!movies.Any())
                return this;

            foreach (var movie in movies)
                AddMovie(movie);

            return this;
        }

        /// <summary>Adds a <see cref="ITraktShow" />, which will be added to the watchlist post.</summary>
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
        public TraktSyncWatchlistPostBuilder AddShow(ITraktShow show)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            var existingShow = _watchlistPost.Shows.FirstOrDefault(s => s.Ids == show.Ids);

            if (existingShow != null)
                return this;

            (_watchlistPost.Shows as List<ITraktSyncWatchlistPostShow>)?.Add(
                new TraktSyncWatchlistPostShow
                {
                    Ids = show.Ids,
                    Title = show.Title,
                    Year = show.Year
                });

            return this;
        }

        /// <summary>Adds a collection of <see cref="ITraktShow" />s, which will be added to the watchlist post.</summary>
        /// <param name="shows">A collection of Trakt shows, which will be added.</param>
        /// <returns>The current <see cref="TraktSyncWatchlistPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given shows collection is null.
        /// Thrown, if one of the given shows is null.
        /// Thrown, if one of the given shows' ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if one of the given shows has no valid ids set.
        /// Thrown, if one of the given shows has an year set, which has more or less than four digits.
        /// </exception>
        public TraktSyncWatchlistPostBuilder AddShows(IEnumerable<ITraktShow> shows)
        {
            if (shows == null)
                throw new ArgumentNullException(nameof(shows));

            if (!shows.Any())
                return this;

            foreach (var show in shows)
                AddShow(show);

            return this;
        }

        /// <summary>Adds a <see cref="ITraktShow" />, which will be added to the watchlist post.</summary>
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
        public TraktSyncWatchlistPostBuilder AddShow(ITraktShow show, int season, params int[] seasons)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            var seasonsToAdd = new int[seasons.Length + 1];
            seasonsToAdd[0] = season;
            seasons.CopyTo(seasonsToAdd, 1);

            var showSeasons = new List<ITraktSyncWatchlistPostShowSeason>();

            for (int i = 0; i < seasonsToAdd.Length; i++)
            {
                if (seasonsToAdd[i] < 0)
                    throw new ArgumentOutOfRangeException("at least one season number not valid");

                showSeasons.Add(new TraktSyncWatchlistPostShowSeason { Number = seasonsToAdd[i] });
            }

            var existingShow = _watchlistPost.Shows.FirstOrDefault(s => s.Ids == show.Ids);

            if (existingShow != null)
            {
                existingShow.Seasons = showSeasons;
            }
            else
            {
                var watchlistShow = new TraktSyncWatchlistPostShow
                {
                    Ids = show.Ids,
                    Title = show.Title,
                    Year = show.Year,
                    Seasons = showSeasons
                };

                (_watchlistPost.Shows as List<ITraktSyncWatchlistPostShow>)?.Add(watchlistShow);
            }

            return this;
        }

        /// <summary>Adds a <see cref="ITraktShow" />, which will be added to the watchlist post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="seasons">
        /// An array of season numbers for seasons in the given show.
        /// All seasons numbers will be added to the ratings.
        /// </param>
        /// <returns>The current <see cref="TraktSyncWatchlistPostBuilder" /> instance.</returns>
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
        public TraktSyncWatchlistPostBuilder AddShow(ITraktShow show, int[] seasons)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            var showSeasons = new List<ITraktSyncWatchlistPostShowSeason>();

            for (int i = 0; i < seasons.Length; i++)
            {
                if (seasons[i] < 0)
                    throw new ArgumentOutOfRangeException("at least one season number not valid");

                showSeasons.Add(new TraktSyncWatchlistPostShowSeason { Number = seasons[i] });
            }

            var existingShow = _watchlistPost.Shows.FirstOrDefault(s => s.Ids == show.Ids);

            if (existingShow != null)
            {
                existingShow.Seasons = showSeasons;
            }
            else
            {
                var watchlistShow = new TraktSyncWatchlistPostShow
                {
                    Ids = show.Ids,
                    Title = show.Title,
                    Year = show.Year,
                    Seasons = showSeasons
                };

                (_watchlistPost.Shows as List<ITraktSyncWatchlistPostShow>)?.Add(watchlistShow);
            }

            return this;
        }

        /// <summary>Adds a <see cref="ITraktShow" />, which will be added to the watchlist post.</summary>
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
        public TraktSyncWatchlistPostBuilder AddShow(ITraktShow show, PostSeasons seasons)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            if (_watchlistPost.Shows == null)
                _watchlistPost.Shows = new List<ITraktSyncWatchlistPostShow>();

            List<ITraktSyncWatchlistPostShowSeason> showSeasons = null;

            if (seasons.Any())
            {
                showSeasons = new List<ITraktSyncWatchlistPostShowSeason>();

                foreach (PostSeason season in seasons)
                {
                    if (season.Number < 0)
                        throw new ArgumentOutOfRangeException("at least one season number not valid", nameof(season));

                    var showSingleSeason = new TraktSyncWatchlistPostShowSeason
                    {
                        Number = season.Number
                    };

                    if (season.Episodes?.Count() > 0)
                    {
                        var showEpisodes = new List<ITraktSyncWatchlistPostShowEpisode>();

                        foreach (PostEpisode episode in season.Episodes)
                        {
                            if (episode.Number < 0)
                                throw new ArgumentOutOfRangeException("at least one episode number not valid", nameof(seasons));

                            showEpisodes.Add(new TraktSyncWatchlistPostShowEpisode
                            {
                                Number = episode.Number
                            });
                        }

                        showSingleSeason.Episodes = showEpisodes;
                    }

                    showSeasons.Add(showSingleSeason);
                }
            }

            ITraktSyncWatchlistPostShow existingShow = _watchlistPost.Shows.FirstOrDefault(s => s.Ids == show.Ids);

            if (existingShow != null)
            {
                existingShow.Seasons = showSeasons;
            }
            else
            {
                var watchlistShow = new TraktSyncWatchlistPostShow
                {
                    Ids = show.Ids,
                    Title = show.Title,
                    Year = show.Year,
                    Seasons = showSeasons
                };

                (_watchlistPost.Shows as List<ITraktSyncWatchlistPostShow>)?.Add(watchlistShow);
            }

            return this;
        }

        /// <summary>Adds a <see cref="ITraktEpisode" />, which will be added to the watchlist post.</summary>
        /// <param name="episode">The Trakt episode, which will be added.</param>
        /// <returns>The current <see cref="TraktSyncWatchlistPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given episode is null.
        /// Thrown, if the given episode ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">Thrown, if the given episode has no valid ids set.</exception>
        public TraktSyncWatchlistPostBuilder AddEpisode(ITraktEpisode episode)
        {
            if (episode == null)
                throw new ArgumentNullException(nameof(episode));

            if (episode.Ids == null)
                throw new ArgumentNullException(nameof(episode.Ids));

            if (!episode.Ids.HasAnyId)
                throw new ArgumentException("no episode ids set or valid", nameof(episode.Ids));

            EnsureEpisodesListExists();

            var existingEpisode = _watchlistPost.Episodes.FirstOrDefault(e => e.Ids == episode.Ids);

            if (existingEpisode != null)
                return this;

            (_watchlistPost.Episodes as List<ITraktSyncWatchlistPostEpisode>)?.Add(
                new TraktSyncWatchlistPostEpisode
                {
                    Ids = episode.Ids
                });

            return this;
        }

        /// <summary>Adds a collection of <see cref="ITraktEpisode" />s, which will be added to the watchlist post.</summary>
        /// <param name="episodes">A collection of Trakt episodes, which will be added.</param>
        /// <returns>The current <see cref="TraktSyncWatchlistPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given episodes collection is null.
        /// Thrown, if one of the given episodes is null.
        /// Thrown, if one of the given episodes' ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">Thrown, if one of the given episodes has no valid ids set.</exception>
        public TraktSyncWatchlistPostBuilder AddEpisodes(IEnumerable<ITraktEpisode> episodes)
        {
            if (episodes == null)
                throw new ArgumentNullException(nameof(episodes));

            if (!episodes.Any())
                return this;

            foreach (var episode in episodes)
                AddEpisode(episode);

            return this;
        }

        /// <summary>Removes all already added movies, shows, seasons and episodes.</summary>
        public void Reset()
        {
            if (_watchlistPost.Movies != null)
            {
                (_watchlistPost.Movies as List<ITraktSyncWatchlistPostMovie>)?.Clear();
                _watchlistPost.Movies = null;
            }

            if (_watchlistPost.Shows != null)
            {
                (_watchlistPost.Shows as List<ITraktSyncWatchlistPostShow>)?.Clear();
                _watchlistPost.Shows = null;
            }

            if (_watchlistPost.Episodes != null)
            {
                (_watchlistPost.Episodes as List<ITraktSyncWatchlistPostEpisode>)?.Clear();
                _watchlistPost.Episodes = null;
            }
        }

        /// <summary>
        /// Returns an <see cref="ITraktSyncWatchlistPost" /> instance, which contains all
        /// added movies, shows, seasons and episodes.
        /// </summary>
        /// <returns>An <see cref="ITraktSyncWatchlistPost" /> instance.</returns>
        public ITraktSyncWatchlistPost Build() => _watchlistPost;

        private void ValidateShow(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            if (show.Ids == null)
                throw new ArgumentNullException(nameof(show.Ids));

            if (!show.Ids.HasAnyId)
                throw new ArgumentException("no show ids set or valid", nameof(show.Ids));

            if (!show.Year.HasValue)
                throw new ArgumentException("show year not valid", nameof(show.Year));
        }

        private void EnsureMoviesListExists()
        {
            if (_watchlistPost.Movies == null)
                _watchlistPost.Movies = new List<ITraktSyncWatchlistPostMovie>();
        }

        private void EnsureShowsListExists()
        {
            if (_watchlistPost.Shows == null)
                _watchlistPost.Shows = new List<ITraktSyncWatchlistPostShow>();
        }

        private void EnsureEpisodesListExists()
        {
            if (_watchlistPost.Episodes == null)
                _watchlistPost.Episodes = new List<ITraktSyncWatchlistPostEpisode>();
        }
    }
}
